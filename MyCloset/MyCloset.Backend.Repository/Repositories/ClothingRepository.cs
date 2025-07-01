using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyCloset.Backend.Application.DTOs;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Contexts;
using MyCloset.Backend.Infrastructure.Interfaces;
using System.Linq.Expressions;

namespace MyCloset.Backend.Infrastructure.Repositories
{
    public class ClothingRepository(MyClosetContext dbContext) : IClothingRepository
    {
        private readonly MyClosetContext _dbContext = dbContext;

        public async Task AddClothing(Clothing clothing, CancellationToken cancellationToken)
        {
            var addedClothing = await _dbContext.Clothes
               .AddAsync(clothing, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ClothingDTO?>> GetAllClothing(ClothingFilter? filters, string? sortColumn, string? sortOrder, int page, int pageSize)
        {
            IQueryable<Clothing> clothingQuery = _dbContext.Clothes.AsNoTracking();

            if (filters is not null)
            {
                clothingQuery = ApplyFilters(clothingQuery, filters);
            }

            if (!string.IsNullOrWhiteSpace(sortColumn) && !string.IsNullOrWhiteSpace(sortOrder))
            {
                if (sortOrder == "asc")
                    clothingQuery = clothingQuery.OrderBy(ApplySorting(sortColumn));
                else
                    clothingQuery = clothingQuery.OrderByDescending(ApplySorting(sortColumn));
            }

            var clothes = await clothingQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new ClothingDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Store = c.Store,
                    Prize = c.Prize,
                    Date = c.Date,
                    Images = c.Images
                }).ToListAsync();

            return clothes;
        }

        private static IQueryable<Clothing> ApplyFilters(IQueryable<Clothing> clothingQuery, ClothingFilter filters)
        {
            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                clothingQuery = clothingQuery.Where(c => c.Name.Contains(filters.Name));
            }

            if (!filters.Colors.IsNullOrEmpty())
            {
                clothingQuery = clothingQuery.Where(c => c.Colors.Any(color => filters!.Colors!.Contains(color)));
            }

            if (!string.IsNullOrWhiteSpace(filters.Store))
            {
                clothingQuery = clothingQuery
                    .Where(c => !string.IsNullOrWhiteSpace(c.Store))
                    .Where(c => c.Store!.Contains(filters.Store));
            }

            if (filters.Size != default)
            {
                clothingQuery = clothingQuery.Where(c => c.Size == filters.Size);
            }

            if (filters.Season.HasValue)
            {
                clothingQuery = clothingQuery.Where(c => c.Season == filters.Season);
            }

            if (filters.Prize.HasValue)
            {
                clothingQuery = clothingQuery.Where(c => c.Prize == filters.Prize);
            }

            if (filters.Aesthetic.HasValue)
            {
                clothingQuery = clothingQuery.Where(c => c.Aesthetic == filters.Aesthetic);
            }

            if (filters.Type.HasValue)
            {
                clothingQuery = clothingQuery.Where(c => c.Type == filters.Type);
            }

            if (filters.Date.HasValue)
            {
                clothingQuery = clothingQuery.Where(c => c.Date == filters.Date);
            }

            if (filters.Material.HasValue)
            {
                clothingQuery = clothingQuery.Where(c => c.Material == filters.Material);
            }

            return clothingQuery;
        }

        // Upgrade: Use generics
        private static Expression<Func<Clothing, object>> ApplySorting(string sortColumn) =>
             sortColumn switch
             {
                 "name" => clothing => clothing.Name,
                 "date" => clothing => clothing.Date ?? DateOnly.MinValue,
                 "price" => clothing => clothing.Prize,
                 "store" => clothing => clothing.Store ?? string.Empty,
                 "season" => clothing => clothing.Season,
                 _ => clothing => clothing.Name
             };

        public async Task<Clothing> GetClothingById(uint id, CancellationToken cancellationToken)
        {
            return await _dbContext.Clothes
                .AsQueryable<Clothing>()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken) ?? throw new KeyNotFoundException("Invalid id. Clothing not found.");
        }
    }
}
