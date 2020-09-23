using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultInterfaceDemo
{
    public interface ICustomer
    {
        IEnumerable<IOrder> PreviousOrders { get; }

        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }

        private static TimeSpan length = new TimeSpan(365 * 2, 0, 0, 0);//two years 
        private static int orderCount = 10;
        private static decimal discountPercent = 0.10m;

        public static void SetLoyaltyThresholds(TimeSpan ago, int minimumOrders = 10, decimal percentDiscount = 0.10m)
        {
            length = ago;
            orderCount = minimumOrders;
            discountPercent = percentDiscount;
        }

        public decimal ComputeLoyaltyDiscount() => DefaultLoyaltyDiscount(this);

        protected static decimal DefaultLoyaltyDiscount(ICustomer c)
        {
            DateTime start = DateTime.Now - length;
            if (c.DateJoined < start && c.PreviousOrders.Count() > orderCount)
            {
                return discountPercent;
            }
            return 0;
        }
    }
}
