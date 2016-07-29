using StackExchange.Redis;
using System.Threading;
using System.Threading.Tasks;
using KylinPushService.Core;
using Td.Kylin.Redis;


namespace KylinPushService.Welfare
{
    /// <summary>
    /// 限时福利推送服务抽象基类
    /// </summary>
    public abstract class BaseWelfareService : IPushService
    {
        /// <summary>
        /// 限时福利推送信息在Redis中所在的数据库
        /// </summary>
        protected IDatabase RedisDB
        {
            get
            {
                return RedisContext.RedisMultiplexer?.GetDatabase(WelfareConfig.DbIndex);
            }
        }

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
