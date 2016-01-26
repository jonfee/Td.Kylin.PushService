using KylinPushService.SysEnums;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;

namespace KylinPushService.ConfigManager
{
    public class PushApiConfigManager : IConfigurationSectionHandler
    {
        /// <summary>
        /// 配置项
        /// </summary>
        public static PushApiConfig Config { get; private set; }

        static PushApiConfigManager()
        {
            ConfigurationManager.GetSection("PushApi");
        }

        object IConfigurationSectionHandler.Create(object parent, object configContext, XmlNode section)
        {
            Config = new PushApiConfig();
            Config.ApiConfigs = new List<ApiConfig>();

            foreach (XmlNode node in section.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    var text = node.InnerText;

                    switch (node.Name.ToLower())
                    {
                        case "moduleid":
                            Config.ModuleID = text;
                            break;
                        case "secret":
                            Config.Secret = text;
                            break;
                        case "api":
                            var api = GetApiConfig(node);
                            if (null != api) Config.ApiConfigs.Add(api);
                            break;
                    }
                }
            }

            return Config;
        }

        /// <summary>
        /// 获取指定推送类型的接口信息
        /// </summary>
        /// <param name="pushType"></param>
        /// <returns></returns>
        public static ApiConfig GetApiConfig(PushType pushType)
        {
            return Config.ApiConfigs.Where(p => p.PushType == pushType).FirstOrDefault();
        }

        /// <summary>
        /// 获取接口信息
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static ApiConfig GetApiConfig(XmlNode node)
        {
            var name = GetAttributeValue(node, "name");

            var pushType = (PushType)System.Enum.Parse(typeof(PushType), name);

            if (pushType != default(PushType))
            {
                var url = GetAttributeValue(node, "url");
                var method = GetAttributeValue(node, "method").ToLower();

                if (!string.IsNullOrWhiteSpace(url) && (method == "post" || method == "get"))
                {
                    return new ApiConfig
                    {
                        Url = url,
                        Method = method,
                        PushType = pushType
                    };
                }
            }

            return null;
        }

        /// <summary>
        /// 获取配置节点上的属性值
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetAttributeValue(XmlNode node, string name)
        {
            return null != node.Attributes[name] ? node.Attributes[name].Value : string.Empty;
        }
    }
}
