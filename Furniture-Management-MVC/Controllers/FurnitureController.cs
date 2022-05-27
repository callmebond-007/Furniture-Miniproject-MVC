using Furniture_Management_MVC.Models;
using Furniture_Management_MVC.Repository;
using Furniture_Management_MVC.ViewModels.Furniture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Furniture_Management_MVC.Controllers
{
    [Authorize]
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
            var furnitures = _furnitureRepository.GetAllFurnitures(User.Identity.Name);

            List<FurnitureDetailsViewModel> furnitureDetailsListViewModel = new List<FurnitureDetailsViewModel>();

            foreach (var furniture in furnitures)
            {
                FurnitureDetailsViewModel furnitureDetailsViewModel = new FurnitureDetailsViewModel
                {
                    Id = furniture.Id,
                    ItemName = furniture.ItemName,
                    ItemDescription = furniture.ItemDescription,
                    WoodType = furniture.WoodType,
                    ItemPrice = furniture.ItemPrice,
                    CategoryName = furniture.Category.CategoryName,
                    CreatedBy = furniture.CreatedBy,
                    CreatedDate = furniture.CreatedDate

                };
                furnitureDetailsListViewModel.Add(furnitureDetailsViewModel);
            }

            return View(furnitureDetailsListViewModel);

        }
        [HttpGet]
        public IActionResult AddFurniture()
        {
            var addFurnitureViewModel = new AddFurnitureViewModel();


            var categories = _categoryRepository.GetAllCategories();
            List<SelectListItem> categorySelectListItems = new List<SelectListItem>();


            foreach (var catg in categories)
            {

                categorySelectListItems.Add(new SelectListItem { Text = catg.CategoryName, Value = catg.CategoryId.ToString() });
            }


            categorySelectListItems.Insert(0, new SelectListItem { Text = "--Select-Category", Value = string.Empty });


            addFurnitureViewModel.CategoryList = categorySelectListItems;

            return View(addFurnitureViewModel);
        }
        [HttpPost]
        public IActionResult AddFurniture(AddFurnitureViewModel furnitureViewModel)
        {
            if (ModelState.IsValid)
            {
                var furniture = new Furniture
                {
                    ItemName = furnitureViewModel.ItemName,
                    ItemDescription = furnitureViewModel.ItemDescription,
                    WoodType = furnitureViewModel.WoodType,
                    ItemPrice = furnitureViewModel.ItemPrice,
                    CategoryId = furnitureViewModel.CategoryId,
                    CreatedBy = HttpContext.User.Identity.Name,
                    CreatedDate = DateTime.Now
                };
                var addedFurniture = _furnitureRepository.AddFurniture(furniture);
                return RedirectToAction("Index");
            }
            return View(furnitureViewModel);
        }
        [HttpGet]
        public IActionResult UpdateFurniture(int id)
        {
            var updateFurnitureViewModel = new UpdateFurnitureViewModel();
            var furnitureToBeEdited = _furnitureRepository.GetFurnitureById(id);



            var categories = _categoryRepository.GetAllCategories();
            List<SelectListItem> categorySelectListItems = new List<SelectListItem>();
            foreach (var catg in categories)
            {
                categorySelectListItems.Add(new SelectListItem { Text = catg.CategoryName, Value = catg.CategoryId.ToString() });
            }
            categorySelectListItems.Insert(0, new SelectListItem { Text = "--Select-Category", Value = string.Empty });
            updateFurnitureViewModel.CategoryList = categorySelectListItems;




            updateFurnitureViewModel.Id = furnitureToBeEdited.Id;
            updateFurnitureViewModel.ItemName = furnitureToBeEdited.ItemName;
            updateFurnitureViewModel.ItemDescription = furnitureToBeEdited.ItemDescription;
            updateFurnitureViewModel.WoodType = furnitureToBeEdited.WoodType;
            updateFurnitureViewModel.ItemPrice = furnitureToBeEdited.ItemPrice;
            updateFurnitureViewModel.CategoryId = furnitureToBeEdited.CategoryId;


            return View(updateFurnitureViewModel);

        }
        [HttpPost]
        public IActionResult UpdateFurniture(int id, UpdateFurnitureViewModel updateFurnitureViewModel)
        {
            if (ModelState.IsValid)
            {
                Furniture furniture = new Furniture
                {
                    ItemName = updateFurnitureViewModel.ItemName,
                    ItemDescription = updateFurnitureViewModel.ItemDescription,
                    WoodType = updateFurnitureViewModel.WoodType,
                    ItemPrice = updateFurnitureViewModel.ItemPrice,
                    CategoryId = updateFurnitureViewModel.CategoryId
                };
                _furnitureRepository.UpdateFurniture(id, furniture);
                return RedirectToAction("Index");
            }
            return View(updateFurnitureViewModel);
        }
        [HttpGet]
        public IActionResult DeleteFurniture(int id)
        {
            var furnitureToBeDeleted = _furnitureRepository.GetFullFurnitureDetailsById(id);
            var deleteFurnitureViewModel = new DeleteFurnitureViewModel
            {
                Id = furnitureToBeDeleted.Id,
                ItemName = furnitureToBeDeleted.ItemName,
                ItemDescription = furnitureToBeDeleted.ItemDescription,
                WoodType = furnitureToBeDeleted.WoodType,
                ItemPrice= furnitureToBeDeleted.ItemPrice,
                CategoryName = furnitureToBeDeleted.Category.CategoryName
            };
            return View(deleteFurnitureViewModel);
        }
        [HttpPost]
        public IActionResult DeleteFurniture(DeleteFurnitureViewModel deleteFurnitureViewModel)
        {
            _furnitureRepository.RemoveFurniture(deleteFurnitureViewModel.Id);
            return RedirectToAction("Index");
        }


    }
}
