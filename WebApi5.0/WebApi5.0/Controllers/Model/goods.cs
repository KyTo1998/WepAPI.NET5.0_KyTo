using System;

namespace WebApi5._0.Controllers.Model
{
    public class goodsTec
    {
        public string nameGoodsTec { get; set; }
        public double riceGoodsTec { get; set; }
    }

    public  class goods : goodsTec
    {
        public Guid idGoods { get; set; }
    }
}
