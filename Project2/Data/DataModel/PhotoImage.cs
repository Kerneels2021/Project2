using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Data.DataModel
{
    public class PhotoImage
    {
        public string PhotoName { get; set; }
        public string PhotoLocation { get; set; }
        public string PhotoDateCreated { get; set; }
        public string Url { get; set; }
        public virtual IEnumerable<PhotoTag> PhotoTags { get; set; }
        //public string PhotoEditedBy { get; set; }
       


    }
}
