using DigitalProcess.Data;
using DigitalProcess.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalProcess.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users
                .Include(u => u.Organization)
                .Include(u => u.UserSectors)
                    .ThenInclude(us => us.Sector)
                .ToList();
        }

        public User GetById(int id)
        {
            return _context.Users
                .Include(u => u.Organization)
                .Include(u => u.UserSectors)
                    .ThenInclude(us => us.Sector)
                .FirstOrDefault(u => u.Id == id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
