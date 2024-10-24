using Microsoft.EntityFrameworkCore;
using NZWalkz.API.Data;
using NZWalkz.API.Models.DomainModels;

namespace NZWalkz.API.Repo.RegionRepo
{
    public class SQLRegionRepo : IRegionRepo
    {
        private readonly NZWalkzDBContext dbContext;
        public SQLRegionRepo(NZWalkzDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateNewRegion(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> DeleteRegion(Guid RegId)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.RegionId == RegId);

            if (existingRegion == null)
            {
                return null;
            }

            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();

            return existingRegion;

        }

        public async Task<List<Region>> GetAllRegionAsyc()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionById(Guid RegId)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.RegionId == RegId);
        }

        public async Task<Region?> UpdateRegion(Guid RegId, Region region)
        {
            var GetRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.RegionId == RegId);

            if (GetRegion == null)
            {
                return null;
            }

            GetRegion.Code = region.Code;
            GetRegion.Name = region.Name;
            GetRegion.RegionImageURL = region.RegionImageURL;

            await dbContext.SaveChangesAsync();

            return GetRegion;

        }
    }
}
