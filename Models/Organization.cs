namespace DigitalProcess.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public List<Sector>? Sectors { get; set; }
    }
}
