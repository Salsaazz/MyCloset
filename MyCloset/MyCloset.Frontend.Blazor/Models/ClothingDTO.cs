namespace MyCloset.Frontend.Blazor.Models
{
    public class ClothingDTO
    {
        public required uint Id { get; set; }
        public required string Name { get; set; }
        public string? Store { get; set; }
        public double? Prize { get; set; }
        public DateOnly? Date { get; set; }
        public List<Image?> Images { get; set; } = [];
    }
}
