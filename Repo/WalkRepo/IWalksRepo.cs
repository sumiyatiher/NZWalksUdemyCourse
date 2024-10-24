using NZWalkz.API.Models.DomainModels;

namespace NZWalkz.API.Repo.WalkRepo
{
    public interface IWalksRepo
    {
        Task<Walks> CreateWalkAsync(Walks walks);
        Task<List<Walks>> GetAllAsyc(string? filterOn = null, string? filterQuery = null,string? sortBy = null,bool isAsc = true, int pNumber = 1, int pSize = 1000);
        Task<Walks?> GetWalkById(Guid id);
        Task<Walks?> UpdateWalk(Guid id,Walks walk);
        Task<Walks?> DeleteWalk(Guid id);

    }
}
