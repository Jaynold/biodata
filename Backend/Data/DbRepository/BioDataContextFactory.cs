using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace BioData.DbRepository
{
    public class BioDataContextFactory : IDesignTimeDbContextFactory<BioDataContext>
    {
        public BioDataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            return new BioDataContext(new DbContextOptionsBuilder<BioDataContext>().Options, config);
        }
    }
}
