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
        WelfareLottery = 16,
        /// <summary>
        /// 用户下单推送给工作端
        /// </summary>
        LegworkUserAddOrder = 32,
        /// <summary>
        /// 工作端报价，推送给用户端
        /// </summary>
        LegworkOffer = 64,
        /// <summary>
        /// 用户确认订单,推送给工作端
        /// </summary>
        LegworkUserConfirmOrder = 128,
        /// <summary>
        /// 工作端确认送达(取送物品)及工作端选择线下支付时(购买物品),推送给用户端
        /// </summary>
        LegworkConfirmDelivery = 256,
        /// <summary>
        /// 工作端选择线上支付,推送给用户端
        /// </summary>
        LegworkDownPay = 512,
        /// <summary>
        /// 用户端线上支付成功,推送给工作端
        /// </summary>
        LegworkUserTopPay = 1024,
        /// <summary>
        /// 提醒购买
        /// </summary>
        LegworkMessageBuy = 2048,
        /// <summary>
        /// 用户催单
        /// </summary>
        UserMessageBuy = 4096,
        /// <summary>
        /// 商家发货
        /// </summary>
        SendMerchantOrder=8192,

    }
}
