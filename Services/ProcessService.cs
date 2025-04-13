using DigitalProcess.Data;
using DigitalProcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalProcess.Services
{
    public class ProcessService
    {
        private readonly AppDbContext _context;

        public ProcessService(AppDbContext context)
        {
            _context = context;
        }

        public List<Process> GetAll()
        {
            return _context.Processes
                // .Include(p => p.ProcessType)
                // .Include(p => p.OriginSector)
                // .Include(p => p.DestinationSector)
                // .Include(p => p.CreatorUser)
                .ToList();
        }

        public Process GetById(int id)
        {
            return _context.Processes
                // .Include(p => p.ProcessType)
                // .Include(p => p.OriginSector)
                // .Include(p => p.DestinationSector)
                // .Include(p => p.CreatorUser)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(Process process)
        {
            process.ProtocolNumber = GenerateProtocol();
            process.CreatedAt = DateTime.Now;

            _context.Processes.Add(process);
            _context.SaveChanges();
        }

        public void Update(Process process)
        {
            _context.Processes.Update(process);
            _context.SaveChanges();
        }

        public void Delete(Process process)
        {
            _context.Processes.Remove(process);
            _context.SaveChanges();
        }

        private string GenerateProtocol()
        {
            var random = new Random();
            string part1 = random.Next(1000, 9999).ToString();
            string part2 = DateTime.Now.Day.ToString("00");
            string part3 = random.Next(0, 9).ToString();
            string part4 = DateTime.Now.ToString("HHmm");
            string part5 = DateTime.Now.Year.ToString();

            return $"{part1}{part2}{part3}{part4}{part5}";
        }
    }
}
