using System.ComponentModel.DataAnnotations;

namespace NZWalkz.API.Models.DTOs.Region
{
    public class AddRegionReq
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has contains minimum 3 of characters")]
        [MaxLength(3, ErrorMessage = "Code has contains maximum 3 of characters")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public string? RegionImageURL { get; set; }
    }
}
