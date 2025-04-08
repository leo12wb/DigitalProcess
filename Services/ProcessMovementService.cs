using DigitalProcess.Models;

namespace DigitalProcess.Services
{
    public class ProcessMovementService
    {
        private readonly List<ProcessMovement> _movements = new();

        public List<ProcessMovement> GetAll() => _movements;

        public List<ProcessMovement> GetByProcess(int processId) =>
            _movements.Where(m => m.ProcessId == processId).ToList();

        public void Add(ProcessMovement movement) =>
            _movements.Add(movement);
    }
}
