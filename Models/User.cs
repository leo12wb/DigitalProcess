namespace DigitalProcess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }

        public List<UserSector> UserSectors { get; set; }
    }

    public class UserSector
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}
