namespace DigitalProcess.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }

        public int? ParentSectorId { get; set; }
        public Sector? ParentSector { get; set; }
        public List<Sector>? Children { get; set; }
    }
}
