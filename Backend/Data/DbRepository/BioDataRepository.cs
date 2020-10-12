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
        public async Task<string[]> GetCountOfPropertyValues(string property)
        {
            IQueryable<string> query;
            switch (property.ToLower())
            {
                case "operatingsystems":
                    query = (from tbl in _context.OperatingSystem
                             select tbl.Name);
                    break;
                case "tooltypes":
                    query = (from tbl in _context.ToolType
                             select tbl.Name);
                    break;
                default:
                    return null;
            }
            return await query.ToArrayAsync();
        }

        public void AddSeedData<T>(T entity) where T : class
        {

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

        public async Task<object> GetAllBioDataAsync(string search, string property)
        {
            _logger.LogInformation($"Getting all BioDatas");

            if (property.ToLower() != "none")
            {
                return await GetCountOfPropertyValues(property);
            }
            else
            {
                if (search.ToLower() == "all")
                {
                    var query = _context.Biodata
                    .Include(s => s.Languages)
                    .Include(s => s.Links)
                    .Include(s => s.ToolTypes)
                    .Include(s => s.OperatingSystems);

                    return await query.ToArrayAsync();
                }
                else
                {
                    var query = _context.Biodata
                    .Include(s => s.Languages)
                    .Include(s => s.Links)
                    .Include(s => s.ToolTypes)
                    .Include(s => s.OperatingSystems)
                    .Where(s => s.Name == search);

                    return await query.ToArrayAsync();
                }
            }
        }

        public async Task<Biodata> GetBioDataAsync(string biodataid)
        {
            _logger.LogInformation($"Getting a BioData for {biodataid}");

            var query = _context.Biodata
            .Include(s => s.Languages)
                .Include(s => s.Links)
                .Include(s => s.ToolTypes)
                .Include(s => s.OperatingSystems)
                .Where(s => s.Name == biodataid);
            return await query.FirstOrDefaultAsync();
        }
    }
}