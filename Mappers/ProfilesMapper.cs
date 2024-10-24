using AutoMapper;
using NZWalkz.API.Models.DomainModels;
using NZWalkz.API.Models.DTOs.Difficulty;
using NZWalkz.API.Models.DTOs.Region;
using NZWalkz.API.Models.DTOs.Walks;

namespace NZWalkz.API.Mappers
{
    public class ProfilesMapper: Profile
    {
        public ProfilesMapper()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionReq, Region>().ReverseMap();
            CreateMap<UpdateRegionReq, Region>().ReverseMap();
            CreateMap<AddRequestWalksDTO, Walks>().ReverseMap();
            CreateMap<WalkDTO,Walks>().ReverseMap();
            CreateMap<Difficulty,DifficultyDTO>().ReverseMap();
            CreateMap<UpdateWalkDTO, Walks>().ReverseMap();
        }
    }
}
 