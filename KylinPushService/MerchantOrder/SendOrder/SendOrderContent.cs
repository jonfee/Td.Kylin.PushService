using System;

namespace KylinPushService.MerchantOrder.SendOrder
{
    /// <summary>
    /// 商家订单商家发货
    /// </summary>
    public class SendOrderContent
    {
        public string PushCode { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public long MerchantID { get; set; }

        ///<summary>
        ///实际订单总金额
        ///</summary>
        public decimal ActualOrderAmount { get; set; }
        ///<summary>
        ///买家用户ID
        ///</summary>
        public long UserID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        ///<summary>
        ///付款时间
        ///</summary>

        public DateTime SendTime { get; set; }
    }
}
