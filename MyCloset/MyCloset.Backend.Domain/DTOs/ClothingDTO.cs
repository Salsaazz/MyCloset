using MyCloset.Backend.Domain.Models;

namespace MyCloset.Backend.Application.DTOs
{
    public class ClothingDTO
    {
        public required uint Id { get; init; }
        public required string Name { get; init; }
        public string? Store { get; init; }
        public double? Prize { get; init; }
        public DateOnly? Date { get; init; }
        public List<Image?> Images { get; init; } = [];
    }
}
