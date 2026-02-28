using System.Collections.Generic;
using System.Linq;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        public InMemoryUserRepository()
        {
            // Datos de ejemplo
            _users.Add(new User(_nextId++, "Ana Ramírez", UserType.Estudiante, "ana@correo.com"));
            _users.Add(new User(_nextId++, "Carlos Soto", UserType.Profesor, "carlos@correo.com"));
        }

        public IEnumerable<User> GetAll() => _users;

        public User? GetById(int id) =>
            _users.FirstOrDefault(u => u.IdUser == id);

        public void Add(User user)
        {
            user.IdUser = _nextId++;
            _users.Add(user);
        }

        public void Update(User user)
        {
            var existing = GetById(user.IdUser);
            if (existing == null) return;

            existing.Name = user.Name;
            existing.Type = user.Type;
            existing.Email = user.Email;
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
                _users.Remove(existing);
        }
    }
}
