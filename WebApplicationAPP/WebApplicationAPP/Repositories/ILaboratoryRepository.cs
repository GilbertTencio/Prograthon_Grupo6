using System.Collections.Generic;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface ILaboratoryRepository
    {
        IEnumerable<Laboratory> GetAll();
        Laboratory? GetById(int id);
        void Add(Laboratory lab);
        void Update(Laboratory lab);
        void Delete(int id);
    }
}