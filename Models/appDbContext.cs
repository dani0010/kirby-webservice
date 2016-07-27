using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kirby.models
{

    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options)
        :base(options)
        { }
        public DbSet<sweater> sweaters { get; set; }
        public DbSet<pattern> patterns { get; set; }
        public DbSet<formula> formulas { get; set; }
        public DbSet<size> sizes { get; set; }
        public DbSet<needle> needles { get; set; }
        public DbSet<yarn> yarns { get; set; }
        public DbSet<swatch> swatches { get; set; }

    } // class appDbContext

}