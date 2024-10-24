using System.ComponentModel.DataAnnotations;

namespace NZWalkz.API.Models.DTOs.Walks
{
    public class UpdateWalkDTO
    {
        [Required]
        [MaxLength(100)]
        public String Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public String Description { get; set; }
        [Required]
        [Range(0,100)]
        public double LengthInKM { get; set; }
        public String? WalksImageURL { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
