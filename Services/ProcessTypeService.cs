using DigitalProcess.Data;
using DigitalProcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalProcess.Services
{
    public class ProcessTypeService
    {
        private readonly AppDbContext _context;

        public ProcessTypeService(AppDbContext context)
        {
            _context = context;
        }

        public List<ProcessType> GetAll()
        {
            return _context.ProcessTypes.ToList();
        }

        public ProcessType GetById(int id)
        {
            return _context.ProcessTypes.FirstOrDefault(t => t.Id == id);
        }

        public void Add(ProcessType type)
        {
            _context.ProcessTypes.Add(type);
            _context.SaveChanges();
        }
    }
}
