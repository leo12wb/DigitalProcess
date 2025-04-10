using DigitalProcess.Data;
using DigitalProcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalProcess.Services
{
    public class DocumentService
    {
        private readonly AppDbContext _context;

        public DocumentService(AppDbContext context)
        {
            _context = context;
        }

        public List<Document> GetAll()
        {
            return _context.Documents
                // .Include(d => d.Process)
                // .Include(d => d.CreatedByUser)
                // .OrderByDescending(d => d.CreatedAt)
                .ToList();
        }

        public List<Document> GetByProcess(int processId)
        {
            return _context.Documents
                // .Where(d => d.ProcessId == processId)
                // .Include(d => d.CreatedByUser)
                // .OrderByDescending(d => d.CreatedAt)
                .ToList();
        }

        public void Add(Document doc)
        {
            // doc.CreatedAt = DateTime.Now;
            _context.Documents.Add(doc);
            _context.SaveChanges();
        }
    }
}
