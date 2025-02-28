using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi5._0.Data
{
    public enum Decentralization
    {
        Customer = 4, Seller = 3, Staff = 2 , Manage = 1, Admin = 0
    }
    public class dbUser
    {
        [Key]
        public Guid userId { get; set; }
        public Decentralization decentralization { get; set; }
        [Required]
        public string userNameCustomer { get; set; }
        [Required]
        public string passwordCustomer { get; set; }
        public string userName { get; set; }
        public string userDescription { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string numberPhone { get; set; }
        public ICollection<dbOrders> orders { get; set; }
    }
}
