using KylinPushService.Appoint.Accept;
using KylinPushService.Appoint.Allot;
using KylinPushService.Appoint.ShangMen;
using KylinPushService.Appoint.YuYue;
using KylinPushService.Core;
using KylinPushService.Welfare.Lottery;
using System.ServiceProcess;
using KylinPushService.Core.Loger;
using KylinPushService.LegworkOrder.PushService;
using KylinPushService.MerchantOrder.UserMessageBuy;
using Td.Kylin.DataCache;
using Td.Kylin.EnumLibrary;
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
            
            DataCacheInjection.UseDataCache(new CacheInjectionConfig
            {
                CacheItems = new[] { CacheItemType.LegworkAreaConfig, CacheItemType.LegworkGlobalConfig, CacheItemType.LegworkGoodsCategory },
                InitIfNull = false,
                KeepAlive = true,
                RedisConnectionString = Configs.RedisConfiguration,
                SqlConnectionString = Configs.ConnectionString,
                SqlType = SqlProviderType.SqlServer
            });
        }

        #region 服务对象

        /// <summary>
        /// 上门订单推送服务
        /// </summary>
        private ShangMenPushService shangMenService;
        private UserMessageBuyPushService userMessageBuyService;

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

        private AssignOrderPushService _AssignOrderPushService;
        private OrderConfirmPushService _OrderConfirmPushService;
        private OrderDeliveryPushService _OrderDeliveryPushService;
        private OrderOfferPushService _OrderOfferPushService;
        private PaymentCompletePushService _PaymentCompletePushService;
        private RequestPaymentPushService _RequestPaymentPushService;
        private MessageBuyPushService _MessageBuyPushService;

        #endregion

        protected override void OnStart(string[] args)
        {
            //上门订单推送服务开启
            //shangMenService = new ShangMenPushService();
            //shangMenService.Start();

            //预约订单推送服务开启
            //yuyueService = new YuYuePushService();
            //yuyueService.Start();

            //指派订单推送服务开启
            //allotService = new AppointAllotPushService();
            //allotService.Start();

            ////订单接单推送服务开启
            //acceptService = new AppointAcceptPushService();
            //acceptService.Start();

            //福利中奖消息推送服务开启
            lotteryService = new WelfareLotteryService();
            lotteryService.Start();
            userMessageBuyService = new UserMessageBuyPushService();
            userMessageBuyService.Start();

            _AssignOrderPushService = new AssignOrderPushService();
            _AssignOrderPushService.Start();
            _OrderConfirmPushService = new OrderConfirmPushService();
            _OrderConfirmPushService.Start();
            _OrderDeliveryPushService = new OrderDeliveryPushService();
            _OrderDeliveryPushService.Start();
            _OrderDeliveryPushService = new OrderDeliveryPushService();
            _OrderDeliveryPushService.Start();
            _OrderOfferPushService = new OrderOfferPushService();
            _OrderOfferPushService.Start();
            _PaymentCompletePushService = new PaymentCompletePushService();
            _PaymentCompletePushService.Start();
            _RequestPaymentPushService = new RequestPaymentPushService();
            _RequestPaymentPushService.Start();
            _MessageBuyPushService = new MessageBuyPushService();
            _MessageBuyPushService.Start();
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
            userMessageBuyService.Stop();

            _AssignOrderPushService.Stop();
            _OrderConfirmPushService.Stop();
            _OrderDeliveryPushService.Stop();
            _OrderOfferPushService.Stop();
            _PaymentCompletePushService.Stop();
            _RequestPaymentPushService.Stop();
            _MessageBuyPushService.Stop();

        }
    }
}
