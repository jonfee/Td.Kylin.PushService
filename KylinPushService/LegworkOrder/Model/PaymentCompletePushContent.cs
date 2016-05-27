using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KylinPushService.LegworkOrder.Model
{
	/// <summary>
	/// 用户支付完成推送内容。
	/// </summary>
    public class PaymentCompletePushContent
    {
		/// <summary>
		/// 需要推送给工作端的推送号。
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
		/// 下单人昵称。
		/// </summary>
		public string UserName
		{
			get;
			set;
		}

		/// <summary>
		/// 支付金额。
		/// </summary>
		public decimal Amount
		{
			get;
			set;
		}
    }
}
