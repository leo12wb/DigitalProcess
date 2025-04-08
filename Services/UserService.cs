using DigitalProcess.Models;

namespace DigitalProcess.Services
{
    public class UserService
    {
        private readonly List<User> _users = new();

        public List<User> GetAll() => _users;

        public User GetById(int id) =>
            _users.FirstOrDefault(u => u.Id == id);

        public void Add(User user) =>
            _users.Add(user);
    }
}
