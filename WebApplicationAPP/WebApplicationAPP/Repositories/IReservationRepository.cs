using System.Collections.Generic;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        IEnumerable<Reservation> GetActive();
        Reservation? GetById(int id);
        void Add(Reservation reservation);
        void Update(Reservation reservation);
    }
}