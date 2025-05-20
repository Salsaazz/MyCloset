
namespace MyCloset.Backend.Domain.DTOs
{
    public class UploadImageDTO(string data, string contentType, string fileName)
    {
        public int Id { get; init; }
        public string Data { get; set; } = data;
        public string ContentType { get; set; } = contentType;
        public string FileName { get; set; } = fileName;
    }
}
