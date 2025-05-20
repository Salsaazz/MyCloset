namespace MyCloset.Frontend.Blazor.Models
{
    public class Image(string contentType, string name, string base64String)
    {
        public string ContentType { get; set; } = contentType;
        //
        // Summary:
        //     Gets the form field name from the Content-Disposition header.
        public string Name { get; set; } = name;

        //
        // Summary:
        //     Gets the file name from the Content-Disposition header.
        public string Base64String { get; set; } = base64String;
    }

     
}
