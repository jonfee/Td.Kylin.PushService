using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KylinPushService.Core;
using Td.Kylin.Redis;

namespace KylinPushService.MerchantOrder
{
    public abstract class BaseMerchantOrderService
    {
        /// <summary>
        /// 商家订单推送信息在Redis中所在的数据库
        /// </summary>
        protected IDatabase RedisDB
        {
            get
            {
                return RedisContext.RedisMultiplexer?.GetDatabase(MerchantOrderConfig.DbIndex);
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
