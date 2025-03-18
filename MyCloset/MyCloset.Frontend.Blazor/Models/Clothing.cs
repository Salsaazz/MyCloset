namespace MyCloset.Frontend.Blazor.Models
{
    public class Clothing
    {
        public string Name { get; set; }
        public string? Store { get; set; }
        public List<Enums.Color> Colors { get; set; } = [];
        public Enums.Size Size { get; set; }
        public Enums.Material Material { get; set; }
        public DateOnly? Date { get; set; }
        public Enums.Season Season { get; set; }
        public double Prize { get; set; }
        public Enums.Aesthetic Aesthetic { get; set; }
        public Enums.ClothingType Type { get; set; }
    }
}
