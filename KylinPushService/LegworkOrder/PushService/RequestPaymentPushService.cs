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
    public class RequestPaymentPushService : BaseLegworkService
    {

        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {
            int error = 0;
            while (true)
            {
                try
                {
                    //从预约订单推送消息数据链表左边起获取一条数据
                    RequestPaymentPushContent content = RedisDB.ListLeftPop<RequestPaymentPushContent>(LegworkConfig.RedisKey.LegworkDownPay);

                    //不存在，则休眠1秒钟，避免CPU空转
                    if (null == content)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    //获取预约订单推送接口配置信息
                    var apiConfig = PushApiConfigManager.GetApiConfig(SysEnums.PushType.LegworkDownPay);

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
                        ExceptionLoger loger = new ExceptionLoger(@"/logs/Sccess" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                        loger.Success("工作端选择线上支付，推送给用户端", "推送结果:" + postRst);
                    }
                }
                catch (Exception ex)
                {
                    if (error++ <= 5)
                    {
                        //异常处理
                        ExceptionLoger loger = new ExceptionLoger(@"/logs/Error" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                        loger.Write("工作端选择线上支付，推送给用户端", ex);
                    }
                }
                error = 0;
            }
        }
    }
}