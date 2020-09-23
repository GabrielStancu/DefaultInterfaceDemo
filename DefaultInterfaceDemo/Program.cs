using System;
using System.Linq;

namespace DefaultInterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleCustomer c = new SampleCustomer("customer one", new DateTime(2010, 5, 31))
            {
                Reminders =
                {
                    {new DateTime(2010, 08, 12), "child's birthday" },
                    {new DateTime(2012, 11, 15), "anniversary" }
                }
            };

            SampleOrder o = new SampleOrder(new DateTime(2012, 06, 01), 5m);
            c.AddOrder(o);

            o = new SampleOrder(new DateTime(2013, 07, 04), 25m);
            c.AddOrder(o);

            // Check the discount 
            ICustomer theCustomer = c;
            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");

            Console.WriteLine($"Data about {c.Name}");
            Console.WriteLine($"Joined on {c.DateJoined}. Made {c.PreviousOrders.Count()} orders, the last on {c.LastOrder}");
            Console.WriteLine("Reminders:");
            foreach(var item in c.Reminders)
            {
                Console.WriteLine($"\t{item.Value} on {item.Key}");
            }

            foreach(IOrder order in c.PreviousOrders)
            {
                Console.WriteLine($"Order on {order.Purchased} for {order.Cost}");
            }
        }
    }
}
