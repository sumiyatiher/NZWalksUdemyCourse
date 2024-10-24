namespace NZWalkz.API.Models.DomainModels
{
    public class Walks
    {
        public Guid WalksId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double LengthInKM { get; set; }
        public String? WalksImageURL { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        //Navigation Properties
        public Difficulty difficultyNav { get; set; }
        public Region regionNav { get; set; }


    }
}
