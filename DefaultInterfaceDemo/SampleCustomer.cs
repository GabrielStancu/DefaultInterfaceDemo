using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultInterfaceDemo
{
    public class SampleCustomer : ICustomer
    {
        public string Name { get; }
        public DateTime DateJoined { get; }
        public DateTime? LastOrder { get; private set; }

        private Dictionary<DateTime, string> reminders = new Dictionary<DateTime, string>();
        public IDictionary<DateTime, string> Reminders => reminders;

        private List<IOrder> allOrders = new List<IOrder>();
        public IEnumerable<IOrder> PreviousOrders => allOrders;

        public SampleCustomer(string name, DateTime dateJoined) =>
            (Name, DateJoined) = (name, dateJoined);

        public void AddOrder(IOrder order)
        {
            if(order.Purchased > (LastOrder ?? DateTime.MinValue))
            {
                LastOrder = order.Purchased;
            }
            allOrders.Add(order);
        }

        public decimal ComputeLoyaltyDiscount()
        {
            if(PreviousOrders.Any() == false)
            {
                return 0.5m;
            }
            else
            {
                return ICustomer.DefaultLoyaltyDiscount(this);
            }
        }
    }
}
