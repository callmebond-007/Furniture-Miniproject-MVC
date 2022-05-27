using Furniture_Management_MVC.DBContext;
using Furniture_Management_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Furniture_Management_MVC.Repository
{
    public class FurnitureRepository : IFurnitureRepository
    {
        FurnitureDbContext _furnitureDbContext;
        public FurnitureRepository(FurnitureDbContext furnitureDbContext)
        {
            _furnitureDbContext = furnitureDbContext;
        }
        public Furniture AddFurniture(Furniture furniture)
        {
            _furnitureDbContext.Furnitures.Add(furniture);
            _furnitureDbContext.SaveChanges();
            return furniture;
        }

        public List<Furniture> GetAllFurnitures(string userName)
        {
            return _furnitureDbContext.Furnitures.Include(c => c.Category).Where(P => P.CreatedBy == userName).ToList();
        }

        public Furniture GetFullFurnitureDetailsById(int id)
        {
            var existingFurniture = _furnitureDbContext.Furnitures.Include(c => c.Category).FirstOrDefault(e => e.Id == id);
            return existingFurniture;
        }

        public Furniture GetFurnitureById(int id)
        {
            var existingFurniture = _furnitureDbContext.Furnitures.FirstOrDefault(e => e.Id == id);
            return existingFurniture;
        }

        public void RemoveFurniture(int id)
        {
            var existingFurniture = _furnitureDbContext.Furnitures.FirstOrDefault(e => e.Id == id);
            if (existingFurniture == null)
            {
                throw new Exception($"Furniture with Id ={id} is not found for deletion");
            }
            _furnitureDbContext.Furnitures.Remove(existingFurniture);
            _furnitureDbContext.SaveChanges();

        }

        public void UpdateFurniture(int id, Furniture furniture)
        {
            var existingFurniture = _furnitureDbContext.Furnitures.FirstOrDefault(e => e.Id == id);
            if (existingFurniture != null)
            {
                existingFurniture.ItemName = furniture.ItemName;
                existingFurniture.ItemDescription = furniture.ItemDescription;
                existingFurniture.WoodType = furniture.WoodType;
                existingFurniture.ItemPrice = furniture.ItemPrice;
                existingFurniture.CategoryId = furniture.CategoryId;
                _furnitureDbContext.SaveChanges();
            }
        }
    }

}
