using MyCloset.Frontend.Blazor.Enum;

namespace MyCloset.Frontend.Blazor.Model
{
    public sealed class Clothing
    {
        public uint Id { get; init; }
        public string Name { get; set; }
        public int MyProperty { get; set; }
        public string? Store { get; set; }
        public Enum.Color[] Colors { get; set; }
        public Enum.Size Size { get; set; }
        public DateOnly? Date { get; set; }
        public Season Season { get; set; }
        public double Prize { get; set; }
    }
}
