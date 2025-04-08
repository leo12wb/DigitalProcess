namespace DigitalProcess.Models
{
    public class Process
    {
        public int Id { get; set; }
        public string ProtocolNumber { get; set; }

        public int TypeId { get; set; }
        public ProcessType Type { get; set; }

        public int? OriginOrganizationId { get; set; }
        public Organization OriginOrganization { get; set; }

        public int? OriginSectorId { get; set; }
        public Sector OriginSector { get; set; }

        public int? CurrentOrganizationId { get; set; }
        public Organization CurrentOrganization { get; set; }

        public int? CurrentSectorId { get; set; }
        public Sector CurrentSector { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<Document> Documents { get; set; }
        public List<ProcessMovement> Movements { get; set; }
    }
}
