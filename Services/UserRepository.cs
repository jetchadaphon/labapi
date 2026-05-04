using LABAPI.Models;

namespace LABAPI.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        private readonly object _lock = new();

        public UserRepository()
        {
            _users.Add(new User { Name = "Alice", Email = "alice@example.com", Age = 30 });
            _users.Add(new User { Name = "Bob", Email = "bob@example.com", Age = 25 });
        }

        public IEnumerable<User> GetAll()
        {
            lock (_lock)
            {
                return _users.Select(u => u).ToList();
            }
        }

        public User? Get(Guid id)
        {
            lock (_lock)
            {
                return _users.FirstOrDefault(u => u.Id == id);
            }
        }

        public User Create(User user)
        {
            lock (_lock)
            {
                user.Id = Guid.NewGuid();
                _users.Add(user);
                return user;
            }
        }

        public bool Update(Guid id, User user)
        {
            lock (_lock)
            {
                var existing = _users.FirstOrDefault(u => u.Id == id);
                if (existing == null) return false;
                existing.Name = user.Name;
                existing.Email = user.Email;
                existing.Age = user.Age;
                return true;
            }
        }

        public bool Delete(Guid id)
        {
            lock (_lock)
            {
                var existing = _users.FirstOrDefault(u => u.Id == id);
                if (existing == null) return false;
                _users.Remove(existing);
                return true;
            }
        }
    }
}
