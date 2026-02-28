using System;
using System.Collections.Generic;
using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;

namespace WebApplicationAPP.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILaboratoryRepository _labRepository;

        public ReservationService(
            IReservationRepository reservationRepository,
            IUserRepository userRepository,
            ILaboratoryRepository labRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _labRepository = labRepository;
        }

        public IEnumerable<Reservation> ListarReservas() =>
            _reservationRepository.GetAll();

        public IEnumerable<Reservation> ListarReservasActivas() =>
            _reservationRepository.GetActive();

        public void CrearReserva(DateTime fecha, TimeSpan hora, int idUsuario, int idLaboratorio)
        {
            var usuario = _userRepository.GetById(idUsuario)
                          ?? throw new ArgumentException("Usuario no existe.");
            var laboratorio = _labRepository.GetById(idLaboratorio)
                             ?? throw new ArgumentException("Laboratorio no existe.");

            // Aquí podrías agregar validaciones de choque de horario, capacidad, etc.

            var reserva = new Reservation(0, fecha, hora, idUsuario, idLaboratorio)
            {
                User = usuario,
                Laboratory = laboratorio,
                Status = ReservationStatus.Activa
            };

            _reservationRepository.Add(reserva);
        }

        public void CancelarReserva(int idReserva)
        {
            var reserva = _reservationRepository.GetById(idReserva);
            if (reserva == null) return;

            reserva.Status = ReservationStatus.Cancelada;
            _reservationRepository.Update(reserva);
        }

        public Reservation? ObtenerPorId(int id) =>
            _reservationRepository.GetById(id);
    }
}