using DigitalProcess.Models;

namespace DigitalProcess.Services
{
    public class ProcessService
    {
        private readonly List<Process> _processes = new();

        public List<Process> GetAll() => _processes;

        public Process GetById(int id) =>
            _processes.FirstOrDefault(p => p.Id == id);

        public void Add(Process process)
        {
            process.ProtocolNumber = GenerateProtocol();
            _processes.Add(process);
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
