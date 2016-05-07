using KylinPushService.Appoint.Accept;
using KylinPushService.Appoint.Allot;
using KylinPushService.Appoint.ShangMen;
using KylinPushService.Appoint.YuYue;
using KylinPushService.Core;
using KylinPushService.Welfare.Lottery;
using System.ServiceProcess;
using Td.Kylin.Redis;

namespace KylinPushService
{
    /// <summary>
    /// 消息推送服务
    /// </summary>
    public partial class PushService : ServiceBase
    {
        public PushService()
        {
            InitializeComponent();

            //注册Redis
            RedisInjection.UseRedis(Configs.RedisConfiguration);
        }

        #region 服务对象

        /// <summary>
        /// 上门订单推送服务
        /// </summary>
        private ShangMenPushService shangMenService;

        /// <summary>
        /// 预约订单推送服务
        /// </summary>
        private YuYuePushService yuyueService;

        /// <summary>
        /// 指派订单推送服务
        /// </summary>
        private AppointAllotPushService allotService;

        /// <summary>
        /// 订单接单推送服务
        /// </summary>
        private AppointAcceptPushService acceptService;

        /// <summary>
        /// 福利中奖消息推送服务
        /// </summary>
        private WelfareLotteryService lotteryService;

        #endregion

        protected override void OnStart(string[] args)
        {
            //上门订单推送服务开启
            shangMenService = new ShangMenPushService();
            shangMenService.Start();

            //预约订单推送服务开启
            yuyueService = new YuYuePushService();
            yuyueService.Start();

            //指派订单推送服务开启
            allotService = new AppointAllotPushService();
            allotService.Start();

            //订单接单推送服务开启
            acceptService = new AppointAcceptPushService();
            acceptService.Start();

            //福利中奖消息推送服务开启
            lotteryService = new WelfareLotteryService();
            lotteryService.Start();
        }

        protected override void OnStop()
        {
            //上门订单推送服务关闭
            shangMenService.Stop();

            //预约订单推送服务关闭
            yuyueService.Stop();

            //指派订单推送服务关闭
            allotService.Stop();

            //订单接单推送服务关闭
            acceptService.Stop();

            //福利中奖消息推送服务关闭
            lotteryService.Stop();
        }
    }
}
