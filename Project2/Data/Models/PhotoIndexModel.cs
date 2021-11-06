
using Project2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class PhotoIndexModel
    {
        public IEnumerable<Photo> Images { get; set; }
        public string SearhForImage { get; set; }

    }
}
