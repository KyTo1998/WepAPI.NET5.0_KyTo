using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi5._0.Data
{
    [Table("dbGoods")]
    public class dbGoods
    {
        [Key]
        public Guid goodsId { get; set; }
        [Required]
        [MaxLength(100)]
        public string goodsName { get; set; }
        public string goodsDescribe { get; set; }
        public string goodsCategory { get; set; }
        [Range(0, double.MaxValue)]
        public double goodsPrice { get; set; }
        public byte goodsSaleOff { get; set; }

        public int? CategoriesId { get; set; }
        [ForeignKey("CategoriesId")]
        public dbCategory category { get; set; }
        public ICollection<dbDetailOrder> detailorders { get; set; }

        public dbGoods()
        {
            detailorders = new List<dbDetailOrder>();
        }
    }
}
