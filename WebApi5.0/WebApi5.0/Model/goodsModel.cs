using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi5._0.Model
{
    public class goodsModel
    {
        [Key]
        public Guid goodsId { get; set; }
        public string goodsName { get; set; }
        public string goodsDescribe { get; set; }
        public string goodsCategory { get; set; }
        [Range(0, double.MaxValue)]
        public double goodsPrice { get; set; }
        public byte goodsSaleOff { get; set; }

        public string CategoriesName { get; set; }
    }
}
