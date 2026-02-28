using System.Collections.Generic;
using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> ListarUsuarios() =>
            _repository.GetAll();

        public void RegistrarUsuario(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new System.ArgumentException("El nombre del usuario es obligatorio.");

            _repository.Add(user);
        }

        public void ActualizarUsuario(User user)
        {
            _repository.Update(user);
        }

        public void EliminarUsuario(int id)
        {
            _repository.Delete(id);
        }

        public User? ObtenerPorId(int id) => _repository.GetById(id);
    }
}