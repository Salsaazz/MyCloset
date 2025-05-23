
namespace MyCloset.Backend.Domain.DTOs
{
    public class CreateImageDTO
    {
        public string Data { get; set; }
        private string _contentType;
        public string ContentType
        {
            get => _contentType;
            set
            {
                if (!allowedExtensions.Contains(value))
                {
                    throw new ArgumentException("Invalid content type.");
                }
                _contentType = value;
            }
        }
        public string FileName { get; set; }
        private static readonly string[] allowedExtensions = ["image/jpeg", "image/jpg", "image/png", "application/pdf"];

        public CreateImageDTO(string data, string contentType, string fileName)
        {
            Data = data;
            ContentType = contentType;
            FileName = fileName;
        }
    }
}