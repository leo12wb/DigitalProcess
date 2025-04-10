using DigitalProcess.Data;
using DigitalProcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalProcess.Services
{
    public class ProcessMovementService
    {
        private readonly AppDbContext _context;

        public ProcessMovementService(AppDbContext context)
        {
            _context = context;
        }

        public List<ProcessMovement> GetAll()
        {
            return _context.ProcessMovements
                // .Include(m => m.Process)
                // .Include(m => m.OriginSector)
                // .Include(m => m.DestinationSector)
                // .Include(m => m.MovedByUser)
                // .OrderByDescending(m => m.MovementDate)
                .ToList();
        }

        public List<ProcessMovement> GetByProcess(int processId)
        {
            return _context.ProcessMovements
                .Where(m => m.ProcessId == processId)
                // .Include(m => m.OriginSector)
                // .Include(m => m.DestinationSector)
                // .Include(m => m.MovedByUser)
                // .OrderByDescending(m => m.MovementDate)
                .ToList();
        }

        public void Add(ProcessMovement movement)
        {
            // movement.MovementDate = DateTime.Now;
            _context.ProcessMovements.Add(movement);
            _context.SaveChanges();
        }
    }
}
