using MyCloset.Frontend.Blazor.Enums;
using Color = MyCloset.Frontend.Blazor.Enums.Color;
using Size = MyCloset.Frontend.Blazor.Enums.Size;

namespace MyCloset.Frontend.Blazor.Models
{
    public record ClothingFilter(string? Name, List<Color?>? Colors, string? Store, Size? Size,
        Season? Season, double? Prize, Aesthetic? Aesthetic, ClothingType? Type, DateOnly? Date,
        Material? Material);
}
