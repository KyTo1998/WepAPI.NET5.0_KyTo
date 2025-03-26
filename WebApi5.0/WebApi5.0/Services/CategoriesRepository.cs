using System.Collections.Generic;
using System.Linq;
using WebApi5._0.Data;
using WebApi5._0.Model;

namespace WebApi5._0.Services
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly myDbContext _context;

        public CategoriesRepository(myDbContext context) {
            _context = context;
        }
        public CategoriesViewModel AddCategories(categoriesModel category)
        {
            var _categories = new dbCategory
            {
                CategoriesName = category.CategoriesName,
            };
            _context.Add(_categories);
            _context.SaveChanges();
            return new CategoriesViewModel
            {
                CategoriesId = _categories.CategoriesId,
                CategoriesName = _categories.CategoriesName,
            };
        }

        public void DeleteCategories(int id)
        {
            var categories = _context.dbCategories.SingleOrDefault(ca => ca.CategoriesId == id);
            if (categories != null) {
                _context.Remove(categories);
                _context.SaveChanges();
            }
        }

        public List<CategoriesViewModel> GetAll()
        {
            var lstCategories = _context.dbCategories.Select(ca => new CategoriesViewModel
            {
                CategoriesId = ca.CategoriesId,
                CategoriesName = ca.CategoriesName,
            });
            return lstCategories.ToList();
        }

        public CategoriesViewModel GetById(int id)
        {
            var categories = _context.dbCategories.SingleOrDefault(ca => ca.CategoriesId == id);
            if (categories != null) {
                return new CategoriesViewModel {
                    CategoriesId = categories.CategoriesId,
                    CategoriesName = categories.CategoriesName,
                };
            }
            else
            {
                return null;
            }
        }

        public void UpdateCategories(CategoriesViewModel category)
        {
            var categories = _context.dbCategories.SingleOrDefault(ca => ca.CategoriesId == category.CategoriesId);
            if (categories != null) { 
                categories.CategoriesName = category.CategoriesName;
                _context.SaveChanges();
            }
        }
    }
}
