namespace KylinPushService
{
    /// <summary>
    /// 推送服务接口
    /// </summary>
    public interface IPushService
    {
        /// <summary>
        /// 服务启动
        /// </summary>
        void Start();

        /// <summary>
        /// 服务停止
        /// </summary>
        void Stop();
    }
}
