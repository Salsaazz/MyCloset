using MyCloset.Backend.Domain.Enum;

namespace MyCloset.Backend.Domain.Models
{
    public record ClothingFilter(string? Name, List<Color?>? Colors, string? Store, Size Size,
        Season? Season, double? Prize, Aesthetic? Aesthetic, ClothingType? Type, DateOnly? Date,
        Material? Material);
}
