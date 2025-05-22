using MyCloset.Frontend.Blazor.Enums;
using Color = MyCloset.Frontend.Blazor.Enums.Color;
using Size = MyCloset.Frontend.Blazor.Enums.Size;

namespace MyCloset.Frontend.Blazor.Models
{
    public class Clothing
    {
        public string Name { get; set; }
        public string? Store { get; set; }
        public List<Color> Colors { get; set; } = [];
        public Size Size { get; set; }
        public Material Material { get; set; }
        public DateOnly? Date { get; set; }
        public Season Season { get; set; }
        public double Prize { get; set; }
        public Aesthetic Aesthetic { get; set; }
        public ClothingType Type { get; set; }

        public List<Image?> Images = [];
    }
}
