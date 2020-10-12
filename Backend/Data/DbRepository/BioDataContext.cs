using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BioData.Data;

namespace BioData.DbRepository
{
    public class BioDataContext : DbContext
    {
        private readonly IConfiguration _config;

        public BioDataContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Biodata> Biodata { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Data.OperatingSystem> OperatingSystem { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<LinkType> LinkType { get; set; }
        public DbSet<ToolType> ToolType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("BioData"));
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors(true);
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Biodata>()
                    .HasMany(c => c.Languages).WithMany(c => c.Biodata);
            bldr.Entity<Biodata>()
                    .HasMany(c => c.Links).WithOne(c => c.Biodata).HasForeignKey(c => c.BiodataId);
            bldr.Entity<Link>()
            .HasMany(c => c.LinkTypes).WithMany(c => c.Link);
            bldr.Entity<Biodata>()
            .HasMany(c => c.OperatingSystems).WithMany(c => c.Biodata);
            bldr.Entity<Biodata>()
            .HasMany(c => c.ToolTypes).WithMany(c => c.Biodata);
        }
    }
}
