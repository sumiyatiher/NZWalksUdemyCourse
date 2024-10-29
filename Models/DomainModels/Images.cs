using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalkz.API.Models.DomainModels
{
    public class Images
    {
        public Guid id { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public string Filename { get; set; }
        public string? FileDesc { get; set; }
        public string FileExt { get; set; }
        public long FileSize { get; set; }
        public  string FilePath { get; set; }
    }
}
