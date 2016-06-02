using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KylinPushService.LegworkOrder.Model
{
	/// <summary>
	/// 订单送达推送内容。
	/// </summary>
    public class OrderDeliveryPushContent
    {
		/// <summary>
		/// 需要推送给用户端的推送号。
		/// </summary>
		public string PushCode
		{
			get;
			set;
		}

		/// <summary>
		/// 订单ID。
		/// </summary>
		public long OrderID
		{
			get;
			set;
		}

		/// <summary>
		/// 订单编号。
		/// </summary>
		public string OrderCode
		{
			get;
			set;
		}

		/// <summary>
		/// 订单状态。
		/// </summary>
		public short OrderStatus
		{
			get;
			set;
		}
        /// <summary>
        /// 订单创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get;
            set;
        }
    }
}
