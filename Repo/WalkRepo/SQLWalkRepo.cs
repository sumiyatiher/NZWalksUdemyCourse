using Microsoft.EntityFrameworkCore;
using NZWalkz.API.Data;
using NZWalkz.API.Models.DomainModels;

namespace NZWalkz.API.Repo.WalkRepo
{
    public class SQLWalkRepo : IWalksRepo
    {
        private readonly NZWalkzDBContext dbContext;

        public SQLWalkRepo(NZWalkzDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walks> CreateWalkAsync(Walks walks)
        {
            await dbContext.Walks.AddAsync(walks);
            await dbContext.SaveChangesAsync();
            return walks;
        }

        public async Task<Walks?> DeleteWalk(Guid id)
        {
            var data = await dbContext.Walks.FirstOrDefaultAsync(x => x.WalksId == id);

            if (data == null)
            {
                return null;
            }

            dbContext.Walks.Remove(data);
            await dbContext.SaveChangesAsync();

            return data;
        }

        public async Task<List<Walks>> GetAllAsyc(string? filterOn = null, string? filterQuery = null,string? sortBy = null, bool isAsc = true, int pNumber = 1, int pSize = 1000)
        {
            var walks = dbContext.Walks.Include("difficultyNav").Include("regionNav").AsQueryable();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAsc ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("LengthInKM", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAsc ? walks.OrderBy(x => x.LengthInKM) : walks.OrderByDescending(x => x.LengthInKM);
                }
            }

            //Pagination
            var skipResults = (pNumber - 1) * pSize; //skip zero resuts

            return await walks.Skip(skipResults).Take(pSize).ToListAsync();
        }

        public async Task<Walks?> GetWalkById(Guid id)
        {
            return await dbContext.Walks.Include("difficultyNav").Include("regionNav").FirstOrDefaultAsync(x => x.WalksId == id);
            
        }

        public async Task<Walks?> UpdateWalk(Guid id, Walks walk)
        {
            var data = await dbContext.Walks.FirstOrDefaultAsync(x => x.WalksId == id);

            if (data == null)
            {
                return null;
            }

            data.Name = walk.Name;
            data.Description = walk.Description;
            data.LengthInKM = walk.LengthInKM;
            data.WalksImageURL = walk.WalksImageURL;
            data.DifficultyId = walk.DifficultyId;
            data.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();

            return data;
        }
    }
}
