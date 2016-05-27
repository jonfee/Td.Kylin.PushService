using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Td.Kylin.Push.WebApi.JPushMessage.Legwork
{
	/// <summary>
	/// 订单确认推送内容。
	/// </summary>
    public class OrderConfirmPushContent
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
		/// 订单状态。
		/// </summary>
		public short OrderStatus
		{
			get;
			set;
		}
    }
}
