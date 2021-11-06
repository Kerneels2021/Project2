using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Project2.Data.Entities
{
    public class Photo
    {
       
        [Key]
        public Guid PhotoId {get; set;}

        public string PhotoName { get; set; }

        public string PhotoUrl { get; set; }

    }

    
}
