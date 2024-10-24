namespace NZWalkz.API.Models.DTOs.Region
{
    public class RegionDTO
    {
        public Guid RegionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageURL { get; set; }
    }
}
