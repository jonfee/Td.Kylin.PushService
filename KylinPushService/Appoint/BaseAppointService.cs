using StackExchange.Redis;
using System.Threading;
using System.Threading.Tasks;
using Td.Cache.Redis;

namespace KylinPushService.Appoint
{
    /// <summary>
    /// 上门预约推送服务抽象基类
    /// </summary>
    public abstract class BaseAppointService : IPushService
    {
        static BaseAppointService()
        {
            RedisDB = RedisManager.Redis.GetDatabase(AppointConfig.DbIndex);
        }

        /// <summary>
        /// 上门预约推送信息在Redis中所在的数据库
        /// </summary>
        protected readonly static IDatabase RedisDB;

        /// <summary>
        /// 当前服务启动的线程
        /// </summary>
        protected Thread CurrentThread { get; private set; }

        /// <summary>
        /// 服务启动
        /// </summary>
        public void Start()
        {
            ThreadStart myThreadDelegate = new ThreadStart(Execute);

            CurrentThread = new Thread(myThreadDelegate);

            CurrentThread.Start();
        }

        /// <summary>
        /// 终止线程执行
        /// </summary>
        public void Stop()
        {
            if (null != CurrentThread)
            {
                CurrentThread.Abort();
            }
        }

        /// <summary>
        /// 执行业务
        /// </summary>
        public abstract void Execute();
    }
}
