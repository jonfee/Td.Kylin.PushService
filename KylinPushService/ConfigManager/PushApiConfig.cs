using System.Collections.Generic;

namespace KylinPushService.ConfigManager
{
    /// <summary>
    /// 推送接口配置
    /// </summary>
    public class PushApiConfig
    {
        /// <summary>
        /// API接口配置集合
        /// </summary>
        public List<ApiConfig> ApiConfigs { get; set; }

        /// <summary>
        /// 当前模块ID
        /// </summary>
        public string ModuleID { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string Secret { get; set; }
    }
}
