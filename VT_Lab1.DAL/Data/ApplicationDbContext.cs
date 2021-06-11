using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VT_Lab1.DAL.Entities;

namespace VT_Lab1.DAL.Data
{
   
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
            {

            }
        public DbSet<Tile> Tilees { get; set; }
        public DbSet<TileGroup> TileGroups { get; set; }




    }

   
}
