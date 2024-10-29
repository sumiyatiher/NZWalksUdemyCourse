using NZWalkz.API.Models.DomainModels;
using NZWalkz.API.Models.DTOs.Images;

namespace NZWalkz.API.Repo.ImagesRepo
{
    public interface IImagesRepo
    {
        Task<Images> Upload(Images image);
    }
}
