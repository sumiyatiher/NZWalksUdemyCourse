using System.ComponentModel.DataAnnotations;

namespace NZWalkz.API.Models.DTOs.Region
{
    public class UpdateRegionReq
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has contains minimum 3 of characters")]
        [MaxLength(3, ErrorMessage = "Code has contains maximum 3 of characters")]
        public String Code { get; set; }

        [Required]
        public String Name { get; set; }
        public String? RegionImageURL { get; set; }
    }
}
