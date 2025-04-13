using DigitalProcess.Data;
using DigitalProcess.Models;

namespace DigitalProcess.Services
{
    public class OrganizationService
    {
        private readonly AppDbContext _context;

        public OrganizationService(AppDbContext context)
        {
            _context = context;
        }

        public List<Organization> GetAll()
        {
            return _context.Organizations.ToList();
        }

        public Organization GetById(int id)
        {
            return _context.Organizations.FirstOrDefault(o => o.Id == id);
        }

        public void Add(Organization org)
        {
            _context.Organizations.Add(org);
            _context.SaveChanges();
        }

        public void Update(Organization org)
        {
            _context.Organizations.Update(org);
            _context.SaveChanges();
        }

        public void Delete(Organization org)
        {
            _context.Organizations.Remove(org);
            _context.SaveChanges();
        }
    }
}
