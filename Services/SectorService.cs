using DigitalProcess.Models;

namespace DigitalProcess.Services
{
    public class SectorService
    {
        private readonly List<Sector> _sectors = new();

        public List<Sector> GetAll() => _sectors;

        public Sector GetById(int id) =>
            _sectors.FirstOrDefault(s => s.Id == id);

        public void Add(Sector sector) =>
            _sectors.Add(sector);
    }
}
