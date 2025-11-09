using System;

namespace Modules.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OrderByAttribute : Attribute
    {
        public int Order { get; }
        public OrderByAttribute(int order) => Order = order;
    }
}
