﻿using System;
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
    class OrderDeliveryPushService : BaseLegworkService
    {

        /// <summary>
        /// 执行
        /// </summary>
        public override void Execute()
        {
            var ServiceTime = DateTime.Now;

            while (true)
            {
                try
                {
                    //从预约订单推送消息数据链表左边起获取一条数据
                    OrderDeliveryPushContent content = RedisDB.ListLeftPop<OrderDeliveryPushContent>(LegworkConfig.RedisKey.LegworkConfirmDelivery);

                    //不存在，则休眠1秒钟，避免CPU空转
                    if (null == content)
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    //获取预约订单推送接口配置信息
                    var apiConfig = PushApiConfigManager.GetApiConfig(SysEnums.PushType.LegworkConfirmDelivery);

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
                        loger.Success("工作端确定送达，推送给用户端推送时", "推送结果:订单编号为“" + content.OrderCode + "”");
                    }
                }
                catch (Exception ex)
                {
                    if (ServiceTime.AddHours(1) <= DateTime.Now)
                    {
                        ServiceTime = DateTime.Now;
                        //异常处理
                        ExceptionLoger loger = new ExceptionLoger(@"/logs/Error" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                        loger.Write("工作端确定送达，推送给用户端推送时异常", ex);
                    }
                    Thread.Sleep(100);
                    continue;
                }
            }
        }
    }
}
