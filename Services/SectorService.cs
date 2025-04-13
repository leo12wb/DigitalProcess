using DigitalProcess.Data;
using DigitalProcess.Models;

namespace DigitalProcess.Services
{
    public class SectorService
    {
        private readonly AppDbContext _context;

        public SectorService(AppDbContext context)
        {
            _context = context;
        }

        public List<Sector> GetAll()
        {
            return _context.Sectors.ToList();
        }

        public Sector GetById(int id)
        {
            return _context.Sectors.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Sector sector)
        {
            _context.Sectors.Add(sector);
            _context.SaveChanges();
        }
        public void Update(Sector sector)
        {
            _context.Sectors.Update(sector);
            _context.SaveChanges();
        }

        public void Delete(Sector sector)
        {
            _context.Sectors.Remove(sector);
            _context.SaveChanges();
        }
    }
}
