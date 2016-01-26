using System;

namespace KylinPushService.Appoint.Accept
{
    /// <summary>
    /// 上门/预约订单已被接单
    /// </summary>
    public class AppointOrderAcceptContent
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
        /// 接单方类型（1商家，2个人服务者）
        /// </summary>
        public int AcceptType { get; set; }

        /// <summary>
        /// 接单方的账号ID
        /// </summary>
        public long AcceptAccountID { get; set; }

        /// <summary>
        /// 接单方的名称
        /// </summary>
        public string AcceptName { get; set; }

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
        /// 下单时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 接单时间
        /// </summary>
        public DateTime AcceptTime { get; set; }
    }
}
