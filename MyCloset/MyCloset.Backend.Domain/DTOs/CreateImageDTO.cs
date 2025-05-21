
namespace MyCloset.Backend.Domain.DTOs
{
    public class CreateImageDTO(string data, string contentType, string fileName)
    {
        public string Data { get; set; } = data;
        public string ContentType { get; set; } = contentType;
        public string FileName { get; set; } = fileName;
    }
}
