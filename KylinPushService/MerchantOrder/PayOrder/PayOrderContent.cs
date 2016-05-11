using System;

namespace KylinPushService.MerchantOrder.PayOrder
{
    /// <summary>
    /// 上门/预约订单已被接单
    /// </summary>
    public class PayOrderContent
    {
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

        public DateTime PayTime { get; set; }
    }
}
