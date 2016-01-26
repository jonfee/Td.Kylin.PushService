namespace KylinPushService.SysEnums
{
    /// <summary>
    /// 消息推送类型
    /// </summary>
    public enum PushType
    {
        /// <summary>
        /// 上门订单推送
        /// </summary>
        ShangMenCreate = 1,
        /// <summary>
        /// 预约订单推送
        /// </summary>
        YuYueCreate = 2,
        /// <summary>
        /// 订单指派推送
        /// </summary>
        OrderAllot = 4,
        /// <summary>
        /// 订单已被接单推送
        /// </summary>
        OrderAccept = 8,
        /// <summary>
        /// 福利开奖结果推送
        /// </summary>
        WelfareLottery=16
    }
}
