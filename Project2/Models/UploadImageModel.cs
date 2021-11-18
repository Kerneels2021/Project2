using Microsoft.AspNetCore.Http;


namespace Project2.Models
{
    public class UploadImageModel
    {
        public string Title { get; set; }
        public string Geolocation { get; set; }

        public string Tags { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}
