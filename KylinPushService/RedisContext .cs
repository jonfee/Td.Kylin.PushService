using KylinPushService.Core;
using StackExchange.Redis;

namespace KylinPushService
{
    /// <summary>
    /// 推送的数据队列所在Redis的实例
    /// </summary>
    public class RedisContext
    {
        private readonly static object redisLocker = new object();
        
        private static ConnectionMultiplexer _redisMultiplexer;

        /// <summary>
        /// Redis连接单例
        /// </summary>
        public static ConnectionMultiplexer RedisMultiplexer
        {
            get
            {
                if (null == _redisMultiplexer || !_redisMultiplexer.IsConnected)
                {
                    lock (redisLocker)
                    {
                        if (null == _redisMultiplexer || !_redisMultiplexer.IsConnected)
                        {
                            _redisMultiplexer = ConnectionMultiplexer.Connect(Configs.RedisConfiguration);
                        }
                    }
                }

                return _redisMultiplexer;
            }
        }
    }
}
