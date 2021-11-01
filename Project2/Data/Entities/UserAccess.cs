using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Data.Entities
{
    public class UserAccess
    {

        [Column(Order =0), Key, ForeignKey("UserId")]
        public int UserId { get; set; }


        [Column(Order = 1), Key, ForeignKey("AccessTypeId")]
        public int AccessTypeId { get; set; }


        [Column(Order = 2), Key, ForeignKey("PhotoId")]
        public int PhotoId { get; set; }

        public DateTime UserAccessDate { get; set; }



    }
}
