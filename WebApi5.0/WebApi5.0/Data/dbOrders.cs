using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace WebApi5._0.Data
{
    public enum orderStatus
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }
    public class dbOrders
    {
       public Guid orderId { get; set; }
       public Guid userId { get; set; }
       public string orderName { get; set; }
       public DateTime orderDate { get; set; }
       public DateTime deliveryDate { get; set; }
       public string consignee { get; set; }
       public orderStatus orStatus { get; set; }
       public String  address { get; set; }
       public String numberPhone { get; set; }
       public  dbUser user { set; get; }
        public ICollection<dbDetailOrder> detailorders { get; set; } 
       public dbOrders()
        {
            detailorders = new HashSet<dbDetailOrder>();
        }
    }
}
