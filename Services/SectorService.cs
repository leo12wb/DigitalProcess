using DigitalProcess.Data;
using DigitalProcess.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
