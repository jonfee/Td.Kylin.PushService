using System.Configuration;

namespace KylinPushService.LegworkOrder
{
    public class LegworkConfig
    {
        /// <summary>
        /// Redis存储的数据库索引
        /// </summary>
        public static int DbIndex
        {
            get
            {
                int index = 0;

                int.TryParse(ConfigurationManager.AppSettings["RedisLegworkDbIndex"], out index);

                return index;
            }
        }

        /// <summary>
        /// 上门预约在Redis中存储的Key
        /// </summary>
        public static class RedisKey
        {
            /// <summary>
            /// 用户下单推送给工作端数据Key
            /// </summary>
            public static string LegworkUserAddOrder { get { return ConfigurationManager.AppSettings["LegworkUserAddOrder"]; } }

            /// <summary>
            /// 工作端报价，推送给用户端数据Key
            /// </summary>
            public static string LegworkOffer { get { return ConfigurationManager.AppSettings["LegworkOffer"]; } }

            /// <summary>
            /// 用户确认订单,推送给工作端数据Key
            /// </summary>
            public static string LegworkUserConfirmOrder { get { return ConfigurationManager.AppSettings["LegworkUserConfirmOrder"]; } }

            /// <summary>
            /// 工作端确认送达(取送物品)及工作端选择线下支付时(购买物品),推送给用户端数据Key
            /// </summary>
            public static string LegworkConfirmDelivery { get { return ConfigurationManager.AppSettings["LegworkConfirmDelivery"]; } }
            /// <summary>
            /// 工作端选择线上支付,推送给用户端数据Key
            /// </summary>
            public static string LegworkDownPay { get { return ConfigurationManager.AppSettings["LegworkDownPay"]; } }
            /// <summary>
            /// 用户端线上支付成功,推送给工作端数据Key
            /// </summary>
            public static string LegworkUserTopPay { get { return ConfigurationManager.AppSettings["LegworkUserTopPay"]; } }
        }
    }
}
