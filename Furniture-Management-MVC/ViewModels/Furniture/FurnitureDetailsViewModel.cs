using System;

namespace Furniture_Management_MVC.ViewModels.Furniture
{
    public class FurnitureDetailsViewModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string WoodType { get; set; }
        public string CategoryName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
