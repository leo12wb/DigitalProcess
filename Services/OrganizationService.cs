using DigitalProcess.Models;

namespace DigitalProcess.Services
{
    public class OrganizationService
    {
        private readonly List<Organization> _organizations = new();

        public List<Organization> GetAll() => _organizations;

        public Organization GetById(int id) =>
            _organizations.FirstOrDefault(o => o.Id == id);

        public void Add(Organization org) =>
            _organizations.Add(org);
    }
}
