using MyCloset.Backend.Domain.Enum;

namespace MyCloset.Backend.Domain.Models
{
    public class Clothing(string name, List<Color> colors, Size size,
        Season season, double prize, Aesthetic aesthetic, ClothingType type, DateOnly? date)
    {
        public uint Id { get; init; }
        public string Name { get; set; } = name;
        public string? Store { get; set; }
        public List<Color> Colors { get; set; } = colors;
        public Size Size { get; set; } = size;
        public DateOnly? Date { get; set; } = date;
        public Season Season { get; set; } = season;
        public double Prize { get; set; } = prize;
        public Aesthetic Aesthetic { get; set; } = aesthetic;
        public ClothingType Type { get; set; } = type;
        public List<Image?> Images { get; set; } = [];
    }
}
