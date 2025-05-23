namespace MyCloset.Frontend.Blazor.Models
{
    public class Image(string contentType, string name, string base64String)
    {
        public string ContentType { get; set; } = contentType;

        public string FileName { get; set; } = name;

        public string Data { get; set; } = base64String;
    }


}
