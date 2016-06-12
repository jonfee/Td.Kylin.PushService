using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KylinPushService.ConfigManager;
using KylinPushService.Core;
using KylinPushService.Core.Loger;
using KylinPushService.LegworkOrder.Model;
using Td.Kylin.Redis;
namespace KylinPushService.LegworkOrder.PushService
{
    public class OrderOfferPushService : BaseLegworkService
    {
        private static List<OrderOfferPushContent> listOfferPushContents = new List<OrderOfferPushContent>();

        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {
            var legworkGlobalConfigCache = Td.Kylin.DataCache.CacheCollection.LegworkGlobalConfigCache.Value()?.FirstOrDefault();
            var lastTime = DateTime.Now;
            var tasktTime = DateTime.Now;
            TimeSpan duetime = new TimeSpan();

            while (true)
            {
                int error = 0;
                try
                {
                    //从预约订单推送消息数据链表左边起获取一条数据
                    OrderOfferPushContent content = RedisDB.ListLeftPop<OrderOfferPushContent>(LegworkConfig.RedisKey.LegworkOffer);

                    //当数据第一次进入 content 和 listOfferPushContents集合同时为空的情况下
                    if (null == content && !listOfferPushContents.Any())
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    else // 接收到推送消息 content 不为空 
                    {
                        if (content != null) // 防止 content 为空时加入list集合中
                        {
                            listOfferPushContents.Add(content);
                            lastTime = content.CreateTime.AddSeconds(legworkGlobalConfigCache.QuotationWaitingTimeout);
                            tasktTime = content.CreateTime.AddSeconds(legworkGlobalConfigCache.QuotationWaitingTime);
                        }
                    }
                    //不存在配置
                    if (null == legworkGlobalConfigCache)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    //超过报价超时时间.存在1人报价立即推送
                    if (lastTime.Subtract(DateTime.Now).Ticks < 0 && listOfferPushContents.Count() > 0)
                    {
                        content = listOfferPushContents.OrderByDescending(q => q.Charge).FirstOrDefault();
                    }
                    //超过等待报价时间
                    else if (tasktTime.Subtract(DateTime.Now).Ticks < 0 && listOfferPushContents.Count() > 0)
                    {
                        //未达到推送人数-继续等待
                        if (listOfferPushContents.Count() != legworkGlobalConfigCache.QuotationWaitingWorkers)
                        {

                            Thread.Sleep(100);
                            continue;
                        }
                        else //达到推送人数，取价格报价最低的立即推送
                        {
                            content = listOfferPushContents.OrderByDescending(q => q.Charge).FirstOrDefault();
                        }
                    }

                    else
                    {
                        Thread.Sleep(100);
                        continue;
                    }


                    //获取预约订单推送接口配置信息
                    var apiConfig = PushApiConfigManager.GetApiConfig(SysEnums.PushType.LegworkOffer);

                    if (null == apiConfig)
                        continue;

                    //将订单数据转换成为字典以便参与接口加密
                    var dic = content.ToMap();

                    if (apiConfig.Method == "get")
                    {
                        DefaultClient.DoGet(apiConfig.Url, dic, PushApiConfigManager.Config.ModuleID, PushApiConfigManager.Config.Secret);
                    }
                    else if (apiConfig.Method == "post")
                    {
                        DefaultClient.DoPost(apiConfig.Url, dic, PushApiConfigManager.Config.ModuleID, PushApiConfigManager.Config.Secret);
                        ExceptionLoger loger = new ExceptionLoger(@"/logs/Sccess" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                        loger.Success("用户下单推送给工作端送时异常", "推送结果:" + content.OrderCode);
                    }
                    listOfferPushContents.Clear();

                }
                catch (Exception ex)
                {
                    if (error++ <= 5)
                    {
                        //异常处理
                        ExceptionLoger loger = new ExceptionLoger(@"/logs/Error" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                        loger.Write("工作端报价，推送给用户端送时异常", ex);
                    }
                }
                error = 0;
            }
        }
    }
}