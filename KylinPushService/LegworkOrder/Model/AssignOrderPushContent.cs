using System;
using System.Collections.Generic;

namespace KylinPushService.LegworkOrder.Model
{
	/// <summary>
	/// 指派订单推送内容。
	/// </summary>
    public class AssignOrderPushContent
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
        /// 订单类型。
        /// </summary>
        public short OrderType
        {
            get;
            set;
        }
    }
}