using Furniture_Management_MVC.Models;
using System.Collections.Generic;

namespace Furniture_Management_MVC.Repository
{
    public interface IFurnitureRepository
    {
        List<Furniture> GetAllFurnitures(string userName);

        Furniture AddFurniture(Furniture furniture);

        Furniture GetFurnitureById(int id);

        Furniture GetFullFurnitureDetailsById(int id);

        void UpdateFurniture(int id, Furniture furniture);

        void RemoveFurniture(int id);

    }
}
