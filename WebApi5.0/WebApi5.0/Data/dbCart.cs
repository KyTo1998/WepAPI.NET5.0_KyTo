using System;

namespace WebApi5._0.Data
{
    public class dbCart
    {
        public Guid cartId { get; set; }
        public string goodsName { get; set; }
        public int number { get; set; }
        public decimal price { get; set; }
    }
}
