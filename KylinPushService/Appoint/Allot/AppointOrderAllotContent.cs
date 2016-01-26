using System;

namespace KylinPushService.Appoint.Allot
{
    /// <summary>
    /// 上门订单指派
    /// </summary>
    public class AppointOrderAllotContent
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderID { get; set; }

        /// <summary>
        /// 下单用户ID
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// 下单用户昵称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 接单的商户ID
        /// </summary>
        public long MerchantID { get; set; }

        /// <summary>
        /// 接单的商户名称
        /// </summary>
        public string MerchantName { get; set; }

        /// <summary>
        /// 补指派的服务人员ID
        /// </summary>
        public long WorkerID { get; set; }

        /// <summary>
        /// 业务ID
        /// </summary>
        public long BusinessID { get; set; }

        /// <summary>
        /// 服务/业务名称
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 服务内容数量（如：2）
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 单位（如：1表示小时）
        /// </summary>
        public int Unit { get; set; }

        /// <summary>
        /// 服务地点
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 服务时间
        /// </summary>
        public DateTime ServiceTime { get; set; }

        /// <summary>
        /// 指派时间
        /// </summary>
        public DateTime AllotTime { get; set; }
    }
}
