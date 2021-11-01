using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Data
{
    public class Database_Resource : IdentityDbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserAccess> UserAccesses { get; set; }

        public virtual DbSet<AccessType> AccessTypes { get; set; }

        public virtual DbSet<PhotoMetaData> PhotoMetaDatas {get; set;}

        public virtual DbSet<Photo> Photos { get; set; }


        public Database_Resource(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAccess>()
                .HasKey(nameof(User.UserId), nameof(AccessType.AccessTypeId), nameof(Photo.PhotoId));
            base.OnModelCreating(builder);
        }
    }
}
