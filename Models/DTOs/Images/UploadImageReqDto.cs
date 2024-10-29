using System.ComponentModel.DataAnnotations;

namespace NZWalkz.API.Models.DTOs.Images
{
    public class UploadImageReqDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDesc { get; set; }

    }
}
