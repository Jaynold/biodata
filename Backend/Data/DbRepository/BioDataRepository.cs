using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BioData.DbRepository
{
    public class BioDataRepository : IBioDataRepository
    {
        private readonly BioDataContext _context;
        private readonly ILogger<BioDataRepository> _logger;

        public BioDataRepository(BioDataContext context, ILogger<BioDataRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {

            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Biodata[]> GetAllBioDataAsync()
        {
            _logger.LogInformation($"Getting all BioDatas");

            IQueryable<Biodata> query = _context.Biodata;

            return await query.ToArrayAsync();
        }

        public async Task<Biodata> GetBioDataAsync(string biodataid)
        {
            _logger.LogInformation($"Getting a BioData for {biodataid}");

            IQueryable<Biodata> query = _context.Biodata;
            return await query.FirstOrDefaultAsync();
        }
    }
}