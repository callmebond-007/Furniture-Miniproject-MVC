using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Furniture_Management_MVC.ViewModels.Furniture
{
    public class AddFurnitureViewModel
    {
        [Required(ErrorMessage = "Item Name is Mandatory")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Item Description is Mandatory")]
        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "Wood Type is Mandatory")]
        public string WoodType { get; set; }

        [Required(ErrorMessage = "Item Price is Mandatory")]
        public double ItemPrice { get; set; }

        [Required(ErrorMessage = "Category is Mandatory")]
        public int CategoryId { get; set; }

        public List<SelectListItem> CategoryList { get; set; }

    }
}
