using MyCloset.Backend.Application.DTOs;
using MyCloset.Backend.Domain.Models;

namespace MyCloset.Backend.Domain.Extensions
{
    public static class ModelExtensions
    {
        public static ClothingDTO ToDTO(this Clothing clothing)
        {
            return new ClothingDTO
            {
                Id = clothing.Id,
                Date = clothing.Date,
                Name = clothing.Name,
                Store = clothing.Store
            };
        }
    }
}
