using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Data.Entities
{
    public class AccessType
    {

        [Key]
        public Guid AccessTypeId { get; set; }
        public string UserAccessType { get; set; }
    }
       
}
