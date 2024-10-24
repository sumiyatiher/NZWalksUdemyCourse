using NZWalkz.API.Models.DomainModels;
using NZWalkz.API.Models.DTOs.Region;

namespace NZWalkz.API.Repo.RegionRepo
{
    public interface IRegionRepo
    {
        Task<List<Region>> GetAllRegionAsyc();

        Task<Region?> GetRegionById(Guid RegId);

        Task<Region> CreateNewRegion(Region region);

        Task<Region?> UpdateRegion(Guid RegId, Region region);

        Task<Region?> DeleteRegion(Guid RegId);
    }
}
