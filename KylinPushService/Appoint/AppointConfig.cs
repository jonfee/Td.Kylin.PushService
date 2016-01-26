using System.Configuration;

namespace KylinPushService.Appoint
{
    /// <summary>
    /// 上门预约相关配置
    /// </summary>
    public class AppointConfig
    {
        /// <summary>
        /// 上门预约Redis存储的数据库索引
        /// </summary>
        public static int DbIndex
        {
            get
            {
                int index = 0;

                int.TryParse(ConfigurationManager.AppSettings["RedisAppointDbIndex"], out index);

                return index;
            }
        }

        /// <summary>
        /// 上门预约在Redis中存储的Key
        /// </summary>
        public static class RedisKey
        {
            /// <summary>
            /// 上门订单下单数据Key
            /// </summary>
            public static string ShangMenCreate { get { return ConfigurationManager.AppSettings["RedisKeyAppointShangMenCreate"]; } }

            /// <summary>
            /// 预约订单下单数据Key
            /// </summary>
            public static string YuYueCreate { get { return ConfigurationManager.AppSettings["RedisKeyAppointYuYueCreate"]; } }

            /// <summary>
            /// 订单指派数据Key
            /// </summary>
            public static string OrderAllot { get { return ConfigurationManager.AppSettings["RedisKeyAppointAllot"]; } }

            /// <summary>
            /// 订单被接单数据Key
            /// </summary>
            public static string OrderAccept { get { return ConfigurationManager.AppSettings["RedisKeyAppointAccept"]; } }
        }
    }
}
