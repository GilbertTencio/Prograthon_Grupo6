using System.Collections.Generic;
using System.Linq;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Repositories
{
    public class InMemoryReservationRepository : IReservationRepository
    {
        private readonly List<Reservation> _reservations = new();
        private int _nextId = 1;

        public IEnumerable<Reservation> GetAll() => _reservations;

        public IEnumerable<Reservation> GetActive() =>
            _reservations.Where(r => r.Status == ReservationStatus.Activa);

        public Reservation? GetById(int id) =>
            _reservations.FirstOrDefault(r => r.IdReservation == id);

        public void Add(Reservation reservation)
        {
            reservation.IdReservation = _nextId++;
            _reservations.Add(reservation);
        }

        public void Update(Reservation reservation)
        {
            var existing = GetById(reservation.IdReservation);
            if (existing == null) return;

            existing.Date = reservation.Date;
            existing.Time = reservation.Time;
            existing.Status = reservation.Status;
            existing.UserId = reservation.UserId;
            existing.LaboratoryId = reservation.LaboratoryId;
            existing.User = reservation.User;
            existing.Laboratory = reservation.Laboratory;
        }
    }
}

