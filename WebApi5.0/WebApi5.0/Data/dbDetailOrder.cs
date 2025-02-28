using System;
using System.Collections.Generic;

namespace WebApi5._0.Data
{
    public class dbDetailOrder
    {
        public Guid goodsId { get; set; }
        public Guid orderId { get; set; }
        public Guid userId { get; set; }
        public int orderNumber { get; set; }
        public double goodsPrice { get; set; }
        public byte goodsSaleOff { get; set; }

        //Relationship
        public dbOrders dborders { get; set; }
        public dbGoods dbgoods { get; set; }
    }
}
