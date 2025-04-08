using DigitalProcess.Models;

namespace DigitalProcess.Services
{
    public class DocumentService
    {
        private readonly List<Document> _documents = new();

        public List<Document> GetAll() => _documents;

        public List<Document> GetByProcess(int processId) =>
            _documents.Where(d => d.ProcessId == processId).ToList();

        public void Add(Document doc) =>
            _documents.Add(doc);
    }
}
