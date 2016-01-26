using KylinPushService.ConfigManager;
using KylinPushService.Core;
using KylinPushService.Core.Loger;
using System;
using System.Threading;
using Td.Cache.Redis;

namespace KylinPushService.Appoint.Allot
{
    /// <summary>
    /// 上门预约订单指派推送服务
    /// </summary>
    public class AppointAllotPushService : BaseAppointService
    {
        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {
            while (true)
            {
                try
                {
                    //从订单指派推送消息数据链表左边起获取一条数据
                    AppointOrderAllotContent content = RedisDB.ListLeftPop<AppointOrderAllotContent>(AppointConfig.RedisKey.OrderAllot);

                    //不存在，则休眠1秒钟，避免CPU空转
                    if (null == content)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    //获取订单指派推送接口配置信息
                    var apiConfig = PushApiConfigManager.GetApiConfig(SysEnums.PushType.OrderAllot);

                    if (null == apiConfig) continue;

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
                }
                catch (Exception ex)
                {
                    //异常处理
                    ExceptionLoger loger = new ExceptionLoger();
                    loger.Write("上门预约订单指派消息推送异常", ex);
                }
            }
        }
    }
}
