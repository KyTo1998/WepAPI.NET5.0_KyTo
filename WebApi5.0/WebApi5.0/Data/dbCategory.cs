using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi5._0.Data
{
    [Table("Category")]
    public class dbCategory
    {
        [Key]
        public int CategoriesId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoriesName { get; set; }

        public virtual ICollection<dbGoods> dbgoods { get; set; }
    }
}
