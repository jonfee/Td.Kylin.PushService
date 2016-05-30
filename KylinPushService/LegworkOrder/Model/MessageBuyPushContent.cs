using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KylinPushService.LegworkOrder.Model
{
    public class MessageBuyPushContent
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
