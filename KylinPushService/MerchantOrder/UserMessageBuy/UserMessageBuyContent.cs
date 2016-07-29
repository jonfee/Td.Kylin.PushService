using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylinPushService.MerchantOrder.UserMessageBuy
{
    public class UserMessageBuyContent
    {
        public string PushCode
        {
            get;
            set;
        }
        public long OrderID
        {
            get;
            set;
        }

        public DateTime CreateTime
        {
            get;
            set;
        }

        public string OrderCode
        {
            get;
            set;
        }
    }
}
