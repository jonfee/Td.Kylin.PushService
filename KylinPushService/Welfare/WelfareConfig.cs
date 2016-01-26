using System.Configuration;

namespace KylinPushService.Welfare
{
    /// <summary>
    /// 限时福利相关配置
    /// </summary>
    public class WelfareConfig
    {
        /// <summary>
        /// 限时福利Redis存储的数据库索引
        /// </summary>
        public static int DbIndex
        {
            get
            {
                int index = 0;

                int.TryParse(ConfigurationManager.AppSettings["RedisWelfareDbIndex"], out index);

                return index;
            }
        }

        /// <summary>
        /// 限时福利在Redis中存储的Key
        /// </summary>
        public static class RedisKey
        {
            /// <summary>
            /// 中奖结果数据Key
            /// </summary>
            public static string LotteryResult { get { return ConfigurationManager.AppSettings["RedisKeyWelfareLotteryResult"]; } }
        }
    }
}
