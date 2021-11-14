using ImageGallery.Data.Models;
using System.Collections.Generic;

namespace Project2.Models
{
    public class GalleryIndexModel
    {
        public IEnumerable<GalleryImage> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}
