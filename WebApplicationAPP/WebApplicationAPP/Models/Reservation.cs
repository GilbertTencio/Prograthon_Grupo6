using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplicationAPP.Models;

namespace WebApplicationAPP.Models
{
    public enum ReservationStatus
    {
        Activa,
        Cancelada
    }

    public class Reservation
    {
        public int IdReservation { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        public ReservationStatus Status { get; set; } = ReservationStatus.Activa;

        [Required]
        public int UserId { get; set; }

        [Required]
        public int LaboratoryId { get; set; }

        public User User { get; set; }
        public Laboratory Laboratory { get; set; }

        public Reservation() { }

        public Reservation(int id, DateTime date, TimeSpan time, int userId, int labId)
        {
            IdReservation = id;
            Date = date;
            Time = time;
            UserId = userId;
            LaboratoryId = labId;
            Status = ReservationStatus.Activa;
        }
    }
}