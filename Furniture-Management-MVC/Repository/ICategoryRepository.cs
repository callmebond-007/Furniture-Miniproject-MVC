using Furniture_Management_MVC.Models;
using System.Collections.Generic;

namespace Furniture_Management_MVC.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
    }
}
