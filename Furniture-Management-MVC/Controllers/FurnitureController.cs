using Furniture_Management_MVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Furniture_Management_MVC.Controllers
{
    public class FurnitureController : Controller
    {
        IFurnitureRepository _furnitureRepository;
        ICategoryRepository _categoryRepository;
        public FurnitureController(IFurnitureRepository furnitureRepository, ICategoryRepository categoryRepository)
        {
            _furnitureRepository = furnitureRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
