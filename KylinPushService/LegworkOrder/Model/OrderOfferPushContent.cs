using System;
using System.Collections.Generic;

namespace KylinPushService.LegworkOrder.Model
{
	/// <summary>
	/// 订单报价推送内容。
	/// </summary>
    public class OrderOfferPushContent
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
		/// 服务费用。
		/// </summary>
	    public decimal Charge
	    {
		    get;
		    set;
	    }

		/// <summary>
		/// 服务员ID。
		/// </summary>
		public long WorkerID
	    {
		    get;
		    set;
	    }

		/// <summary>
		/// 服务员名称。
		/// </summary>
	    public string WorkerName
	    {
			get;
			set;
	    }

		/// <summary>
		/// 服务员距离取货地或收获地的距离。
		/// </summary>
		public double Distance
		{
			get;
			set;
		}
    }
}
