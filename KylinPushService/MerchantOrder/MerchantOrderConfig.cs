using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylinPushService.MerchantOrder
{
    /// <summary>
    /// 商家订单配置
    /// </summary>
    public class MerchantOrderConfig
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
        /// 商家订单在Redis中存储的Key
        /// </summary>
        public static class RedisKey
        {
            /// <summary>
            /// 商家订单用户付款
            /// </summary>
            public static string PayMerchantOrder { get { return ConfigurationManager.AppSettings["PayMerchantOrder"]; } }
            /// <summary>
            /// 商家订单商家发货
            /// </summary>
            public static string SendMerchantOrder { get { return ConfigurationManager.AppSettings["SendMerchantOrder"]; } }
            /// <summary>
            /// 商家订单用户确认收货
            /// </summary>
            public static string ConfirmMerchantOrder { get { return ConfigurationManager.AppSettings["ConfirmMerchantOrder"]; } }

        }
    }
}
