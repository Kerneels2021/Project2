using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Data.Entities
{
    public class User
    {

        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public ICollection<PhotoMetaData> PhotoMetaDatas { get; set; }
    }
}
