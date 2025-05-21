using MyCloset.Backend.Domain.DTOs;

namespace MyCloset.Backend.Domain.Models
{
    public class Image(byte[] data, string contentType, string fileName)
    {
        public int Id { get; init; }
        public byte[] Data { get; set; } = data;
        public string ContentType { get; set; } = contentType;
        public string FileName { get; set; } = fileName;
        public uint ClothingId { get; set; }

        public Clothing Clothing { get; set; }
    }
}
