using System;

namespace DefaultInterfaceDemo
{
    public interface IOrder
    {
        DateTime Purchased { get; }
        decimal Cost { get; }
    }
}
