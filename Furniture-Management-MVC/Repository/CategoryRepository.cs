using Furniture_Management_MVC.DBContext;
using Furniture_Management_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Furniture_Management_MVC.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        FurnitureDbContext _furnitureDbContext;
        public CategoryRepository(FurnitureDbContext furnitureDbContext)
        {
            _furnitureDbContext = furnitureDbContext;
        }
        public List<Category> GetAllCategories()
        {
            return _furnitureDbContext.ItemCategory.ToList();
        }
    }

}
