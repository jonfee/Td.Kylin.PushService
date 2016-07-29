using KylinPushService.Core;
using System.ServiceProcess;
using Td.Kylin.DataCache;
using Td.Kylin.EnumLibrary;

namespace KylinPushService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            DataCacheInjection.UseDataCache(new CacheInjectionConfig
            {
                CacheItems = new[] { CacheItemType.LegworkAreaConfig, CacheItemType.LegworkGlobalConfig, CacheItemType.LegworkGoodsCategory },
                InitIfNull = false,
                KeepAlive = true,
                RedisConnectionString = Configs.RedisConfiguration,
                SqlConnectionString = Configs.ConnectionString,
                SqlType = SqlProviderType.SqlServer
            });

            ServicesToRun = new ServiceBase[]
            {
                new PushService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
