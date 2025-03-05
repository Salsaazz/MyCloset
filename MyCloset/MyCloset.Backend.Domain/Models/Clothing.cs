using MyCloset.Backend.Domain.Enum;

namespace MyCloset.Backend.Domain.Models
{
    public class Clothing(string name, Color[] colors, Size size, Season season, uint prize, Aesthetic aesthetic, ClothingType type, DateOnly? date)
    {
        public uint Id { get; init; }
        public string Name => name;
        public Color[] Colors => colors;
        public Size Size => size;
        private DateOnly? _date;
        public DateOnly? Date
        {
            get => _date;
            set
            {

                if (_date > DateOnly.FromDateTime(DateTime.Now))
                    throw new ArgumentException("Invalid date. The date cannot be set in the future.");
                _date = date;
            }
        }
        public Season Season => season;
        public uint Prize => prize;
        public Aesthetic Aesthetic => aesthetic;
        public ClothingType Type => type;
    }
}
