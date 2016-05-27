using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KylinPushService.LegworkOrder.Model
{
	/// <summary>
	/// 请求用户端支付推送内容。
	/// </summary>
    public class RequestPaymentPushContent
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
		/// 商品费用。
		/// </summary>
		public decimal GoodsAmount
		{
			get;
			set;
		}

		/// <summary>
		/// 服务费用。
		/// </summary>
		public decimal ServiceCharge
		{
			get;
			set;
		}

		/// <summary>
		/// 实际总额。
		/// </summary>
		public decimal ActualAmount
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
	}
}
