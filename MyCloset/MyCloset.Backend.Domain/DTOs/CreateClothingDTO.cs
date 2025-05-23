﻿using MyCloset.Backend.Domain.Enum;

namespace MyCloset.Backend.Domain.DTOs
{
    public class CreateClothingDTO
    {
        public uint Id { get; init; }
        public string Name { get; set; }
        public string? Store { get; set; }
        public List<Color> Colors { get; set; } = [];
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
        private double _prize;
        public double Prize
        {
            get => _prize;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid prize. The prize cannot be less than 0.");
                _prize = value;
            }
        }
        public Aesthetic Aesthetic { get; set; }
        public ClothingType Type { get; set; }
        private List<CreateImageDTO?> images = [];
        public List<CreateImageDTO?> Images
        {
            get => images;
            set
            {
                if (value.Count <= 3)
                    images = value;

                else throw new ArgumentOutOfRangeException("Too many images. Upload less than 4.");
            }
        }

        public CreateClothingDTO(string name, List<Color> colors, string store, Size size, Season season, double prize,
            Aesthetic aesthetic, ClothingType type, DateOnly? date, List<CreateImageDTO?>? images)
        {
            Name = name;
            Colors = colors;
            Store = store;
            Size = size;
            Season = season;
            Prize = prize;
            Aesthetic = aesthetic;
            Type = type;
            Date = date;
            Images = images!;
        }
    }
}
