using System.Collections.Generic;
using System.Linq;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class InMemoryLaboratoryRepository : ILaboratoryRepository
    {
        private readonly List<Laboratory> _labs = new();
        private int _nextId = 1;

        public InMemoryLaboratoryRepository()
        {
            // Datos de ejemplo
            _labs.Add(new Laboratory(_nextId++, "Lab Redes", 25, "Ing. Pérez"));
            _labs.Add(new Laboratory(_nextId++, "Lab Bases de Datos", 30, "MSc. López"));
        }

        public IEnumerable<Laboratory> GetAll() => _labs;

        public Laboratory? GetById(int id) =>
            _labs.FirstOrDefault(l => l.IdLaboratory == id);

        public void Add(Laboratory lab)
        {
            lab.IdLaboratory = _nextId++;
            _labs.Add(lab);
        }

        public void Update(Laboratory lab)
        {
            var existing = GetById(lab.IdLaboratory);
            if (existing == null) return;

            existing.Name = lab.Name;
            existing.Capacity = lab.Capacity;
            existing.Responsible = lab.Responsible;
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
                _labs.Remove(existing);
        }
    }
}
