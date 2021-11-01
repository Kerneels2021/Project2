using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Data.Entities
{
    public class PhotoMetaData
    {
       
        [Key]
        public Guid PhotoMetaDataId { get; set; }
        public string Geolocation { get; set; }
        public DateTime DateCaptured { get; set; }
        public string Tags { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }
       
    }
}
