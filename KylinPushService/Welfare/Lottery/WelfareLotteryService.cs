using KylinPushService.ConfigManager;
using KylinPushService.Core;
using KylinPushService.Core.Loger;
using System;
using System.Threading;
using Td.Kylin.Redis;

namespace KylinPushService.Welfare.Lottery
{
    /// <summary>
    /// 福利开奖消息推送服务
    /// </summary>
    public class WelfareLotteryService : BaseWelfareService
    {
        public override void Execute()
        {
            while (true)
            {
                try
                {
                    //从福利开奖结果推送消息数据链表左边起获取一条数据
                    WelfareWinnerContent content = RedisDB.ListLeftPop<WelfareWinnerContent>(WelfareConfig.RedisKey.LotteryResult);

                    //不存在，则休眠1秒钟，避免CPU空转
                    if (null == content)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    //获取福利开奖结果推送接口配置信息
                    var apiConfig = PushApiConfigManager.GetApiConfig(SysEnums.PushType.ShangMenCreate);

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
                    ExceptionLoger loger = new ExceptionLoger(@"/logs/Error" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                    loger.Write("福利中奖消息推送异常", ex);
                }
            }
        }
    }
}
