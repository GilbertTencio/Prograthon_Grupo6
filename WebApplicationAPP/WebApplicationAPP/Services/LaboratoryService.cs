using System.Collections.Generic;
using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Services
{
    public class LaboratoryService
    {
        private readonly ILaboratoryRepository _repository;

        public LaboratoryService(ILaboratoryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Laboratory> ListarLaboratorios() =>
            _repository.GetAll();

        public void RegistrarLaboratorio(Laboratory lab)
        {
            // Validaciones mínimas
            if (string.IsNullOrWhiteSpace(lab.Name))
                throw new System.ArgumentException("El nombre del laboratorio es obligatorio.");

            _repository.Add(lab);
        }

        public void ActualizarLaboratorio(Laboratory lab)
        {
            _repository.Update(lab);
        }

        public void EliminarLaboratorio(int id)
        {
            _repository.Delete(id);
        }

        public Laboratory? ObtenerPorId(int id) => _repository.GetById(id);
    }
}
