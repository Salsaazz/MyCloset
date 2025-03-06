using MyCloset.Backend.Domain.Enum;

namespace MyCloset.Backend.Domain.Models
{
    public class Clothing
    {
        public uint Id { get; init; }
        public required string Name { get; set; }
        public Color[] Colors { get; set; }
        public Size Size { get; set; }
        private DateOnly? _date;
        public DateOnly? Date
        {
            get => _date;
            set
            {

                if (value > DateOnly.FromDateTime(DateTime.Now))
                    throw new ArgumentException("Invalid date. The date cannot be set in the future.");
                _date = value;
            }
        }
        public Season Season { get; set; }
        public uint Prize { get; set; }
        public Aesthetic Aesthetic { get; set; }
        public ClothingType Type { get; set; }

        public Clothing(string name, Color[] colors, Size size, Season season, uint prize,
            Aesthetic aesthetic, ClothingType type, DateOnly? date)
        {
            Name = name;
            Colors = colors;
            Size = size;
            Season = season;
            Prize = prize;
            Aesthetic = aesthetic;
            Type = type;
            Date = date;
        }
    }
}
