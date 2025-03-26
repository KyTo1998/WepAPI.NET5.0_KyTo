using System.Collections.Generic;
using WebApi5._0.Model;

namespace WebApi5._0.Services
{
    public interface ICategoriesRepository
    {
        List<CategoriesViewModel> GetAll();
        CategoriesViewModel GetById(int id);
        CategoriesViewModel AddCategories(categoriesModel category);
        void UpdateCategories(CategoriesViewModel category);
        void DeleteCategories(int id);
    }
}
