using MediatR;
using Moq;
using MyCloset.Backend.Application.CQRS.Commands;
using MyCloset.Backend.Domain.DTOs;
using MyCloset.Backend.Domain.Enum;
using MyCloset.Backend.Domain.Models;
using MyCloset.Backend.Infrastructure.Interfaces;

namespace MyClothing.Backend.Testing
{
    public class AddClothing
    {
        private readonly Mock<IMediator> _mediator;
        private readonly string _name;
        private readonly string _store;
        private readonly List<Color> _colors;
        private readonly Size _size;
        private readonly Season _season;
        private readonly double _prize;
        private readonly Aesthetic _aesthetic;
        private readonly ClothingType _clothingType;
        private readonly DateOnly _date;
        private readonly Material _material = Material.SILK;
        private readonly List<CreateImageDTO?> _images;
        private readonly CreateClothingDTO _clothing;
        private readonly Mock<IClothingRepository> _mockRepo;
        private readonly DateTime _currentDate = DateTime.Now;

        public AddClothing()
        {
            _mediator = new Mock<IMediator>();
            _name = "Jane";
            _colors = [Color.PURPLE, Color.PINK];
            _store = "Uniqlo";
            _size = Size.M;
            _season = Season.FALL;
            _prize = 29.99;
            _aesthetic = Aesthetic.BUSSINESS;
            _clothingType = ClothingType.JACKET;
            _date = new DateOnly(_currentDate.Year, _currentDate.Month, _currentDate.Day);
            _images = [new("data", "image/jpg", "blazer")];
            _clothing = new CreateClothingDTO(_name, _colors, _store, _size, _season, _prize, _aesthetic, _clothingType, _date, _material, _images);
            _mockRepo = new Mock<IClothingRepository>();
        }

        [Fact]
        public async Task CreateClothing_ReturnSuccesResult()
        {
            // Arrange
            var command = new CreateClothingCommand() { Clothing = _clothing };
            var commandHandler = new CreateClothingCommandHandler(_mockRepo.Object);

            // Act: verify the handler executes without exceptions
            await commandHandler.Handle(command, new CancellationToken());

            // Accept
            _mockRepo.Verify(x => x.AddClothing(It.IsAny<Clothing>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void CreateClothing_DateInTheFuture_ReturnFailResult()
        {
            // Arrange
            var futureDate = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

            // Act & Assert: exception thrown when setting Date, NOT in Handle()
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var invalidClothing = _clothing;
                invalidClothing.Date = futureDate;
            });

            // Verify the exception message
            Assert.Equal("Invalid date. The date cannot be set in the future.", exception.Message);
        }

        [Fact]
        public void CreateClothing_PriceLessThanZero_ReturnFailResult()
        {
            // Arrange
            var futureDate = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var invalidClothing = _clothing;
                invalidClothing.Prize = -1;
            });

            // Assert
            Assert.Equal("Invalid prize. The prize cannot be less than 0.", exception.Message);
        }

        [Fact]
        public void CreateClothing_ImagesGreaterThanThree_ReturnFailResult()
        {
            // Arrange
            List<CreateImageDTO> tooManyImages = [];

            for (int i = 0; i < 5; i++)
            {
                tooManyImages.Add(new("data", "image/jpg", "blazer"));
            }

            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var invalidClothing = _clothing;
                invalidClothing.Images = tooManyImages!;
            });

            // Assert
            Assert.Contains("Too many images. Upload less than 4.", exception.Message);
        }
    }
}
