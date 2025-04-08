using DigitalProcess.Models;

namespace DigitalProcess.Services
{
    public class ProcessTypeService
    {
        private readonly List<ProcessType> _types = new();

        public List<ProcessType> GetAll() => _types;

        public ProcessType GetById(int id) =>
            _types.FirstOrDefault(t => t.Id == id);

        public void Add(ProcessType type) =>
            _types.Add(type);
    }
}
