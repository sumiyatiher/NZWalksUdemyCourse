using NZWalkz.API.Models.DTOs.Difficulty;
using NZWalkz.API.Models.DTOs.Region;

namespace NZWalkz.API.Models.DTOs.Walks
{
    public class WalkDTO
    {
        public Guid WalksId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double LengthInKM { get; set; }
        public String? WalksImageURL { get; set; }


        public DifficultyDTO difficultyNav { get; set; }
        public RegionDTO regionNav { get; set; }

    }
}
