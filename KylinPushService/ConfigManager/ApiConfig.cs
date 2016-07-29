using KylinPushService.SysEnums;

namespace KylinPushService.ConfigManager
{
    /// <summary>
    /// 接口配置
    /// </summary>
    public class ApiConfig
    {
        /// <summary>
        /// API对应的推送类型
        /// </summary>
        public PushType PushType { get; set; }

        /// <summary>
        /// 接口URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 请求方式（Get或Post）
        /// </summary>
        public string Method { get; set; }
    }

    
}
