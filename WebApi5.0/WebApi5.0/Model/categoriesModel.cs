using System.ComponentModel.DataAnnotations;

namespace WebApi5._0.Model
{
    public class categoriesModel
    {
        [Required]
        [MaxLength(50)]
        public string CategoriesName { get; set; }
    }
}
