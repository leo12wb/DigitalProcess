namespace DigitalProcess.Models
{
    public class ProcessMovement
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public Process Process { get; set; }

        public int? FromSectorId { get; set; }
        public Sector FromSector { get; set; }

        public int? ToSectorId { get; set; }
        public Sector ToSector { get; set; }

        public DateTime MovedAt { get; set; } = DateTime.UtcNow;

        public string Comment { get; set; }
    }
}
