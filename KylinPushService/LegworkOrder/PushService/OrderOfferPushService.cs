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
                try
                {
                    //从预约订单推送消息数据链表左边起获取一条数据
                    OrderOfferPushContent content = RedisDB.ListLeftPop<OrderOfferPushContent>(LegworkConfig.RedisKey.LegworkOffer);

                    //不存在，则休眠1秒钟，避免CPU空转
                    if (null == content && !listOfferPushContents.Any())
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    //不存在配置
                    if (null == legworkGlobalConfigCache)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (content != null)
                    {
                        listOfferPushContents.Add(content);
                        lastTime = content.CreateTime.AddSeconds(legworkGlobalConfigCache.QuotationWaitingTimeout);

                        tasktTime = content.CreateTime.AddSeconds(legworkGlobalConfigCache.QuotationWaitingTime);
                        duetime = tasktTime.Subtract(DateTime.Now);//延迟执行时间（以毫秒为单位）
                    }



                    //超过等待报价时间
                    if (duetime.Ticks < 0 && listOfferPushContents.Count() > 0)
                    {
                        //未达到推送人数-继续等待
                        if (listOfferPushContents.Count() != legworkGlobalConfigCache.QuotationWaitingWorkers)
                        {
                            Thread.Sleep(1000);
                            continue;
                        }
                        else //达到推送人数，取价格报价最低的立即推送
                        {
                            content = listOfferPushContents.OrderByDescending(q => q.Charge).FirstOrDefault();
                        }
                    }
                    //超过报价超时时间.存在1人报价立即推送
                    else if (lastTime.Subtract(DateTime.Now).Ticks < 0 && listOfferPushContents.Count() > 0)
                    {
                        content = listOfferPushContents.OrderByDescending(q => q.Charge).FirstOrDefault();
                    }
                    else
                    {
                        Thread.Sleep(1000);
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
                        var getRst = DefaultClient.DoGet(apiConfig.Url, dic, PushApiConfigManager.Config.ModuleID, PushApiConfigManager.Config.Secret);
                    }
                    else if (apiConfig.Method == "post")
                    {
                        var postRst = DefaultClient.DoPost(apiConfig.Url, dic, PushApiConfigManager.Config.ModuleID, PushApiConfigManager.Config.Secret);
                    }
                    listOfferPushContents.Clear();
                }
                catch (Exception ex)
                {
                    //异常处理
                    ExceptionLoger loger = new ExceptionLoger();
                    loger.Write("用户下单推送给工作端送时异常", ex);
                }
            }
        }
    }
}