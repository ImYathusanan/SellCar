using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SellCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellCar.Persistence
{
    public class SellCarDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }

        public DbSet<Vehile> Vehiles { get; set; }

        public SellCarDbContext(DbContextOptions<SellCarDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehileFeature>().HasKey(vf =>
                        new { vf.VehileId, vf.FeatureId });
        }
       
    }
}
