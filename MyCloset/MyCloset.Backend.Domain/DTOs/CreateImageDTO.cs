
namespace MyCloset.Backend.Domain.DTOs
{
    public class CreateImageDTO(string data, string contentType, string fileName)
    {
        public string Data { get; set; } = data;
        private string _contentType;
        public string ContentType
        {
            get => _contentType;
            set
            {
                if (!allowedExtensions.Contains(contentType))
                {
                    throw new ArgumentException("Invalid content type.");
                }
                _contentType = value;
            }
        }
        public string FileName { get; set; } = fileName;
        private static readonly string[] allowedExtensions = ["jpeg", "png", "pdf"];
    }
}
