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

        public DbSet<Owner> Owner { get; set; }
        public DbSet<Biodata> Biodata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("BioData"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {

        }
    }
}
