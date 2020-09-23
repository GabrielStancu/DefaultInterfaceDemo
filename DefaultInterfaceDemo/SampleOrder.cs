using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultInterfaceDemo
{
    public class SampleOrder : IOrder
    {
        public DateTime Purchased { get; }
        public decimal Cost { get; }
        public SampleOrder(DateTime purchased, decimal cost) =>
            (Purchased, Cost) = (purchased, cost);
    }
}
