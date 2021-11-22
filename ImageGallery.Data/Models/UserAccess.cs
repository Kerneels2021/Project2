using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoImageGallery.Data.Models
{
    public class UserAccess
    {

        [Key, Column(Order = 0), ForeignKey("UserId")]
        public int UserId { get; set; }


        [Key, Column(Order = 1), ForeignKey("AccessTypeId")]
        public int AccessTypeId { get; set; }


        [Key, Column(Order = 2), ForeignKey("PhotoId")]
        public int PhotoId { get; set; }

        public DateTime UserAccessDate { get; set; }

    }
}
