using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylinPushService.Core
{
    /// <summary>
    /// 配置项
    /// </summary>
    public class Configs
    {
        /// <summary>
        /// Redis服务器连接配置
        /// </summary>
        public static string RedisConfiguration { get { return ConfigurationManager.AppSettings["RedisConfiguration"]; } }

        /// <summary>
        /// 数据库服务器连接配置
        /// </summary>
        public static string ConnectionString { get { return ConfigurationManager.AppSettings["ConnectionString"]; } }
    }
}
