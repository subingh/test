namespace GhumGham.Models.Domain
{
    public class Ride
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKm {  get; set; }
        public string? RidesImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        //Navigation Properties
        public required Difficulty Difficulty { get; set; }
        public required Region Region { get; set; }
    }
}
