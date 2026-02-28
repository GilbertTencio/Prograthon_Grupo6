using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Models;
using WebApplicationAPP.Services;

namespace WebApplicationAPP.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;
        private readonly UserService _userService;
        private readonly LaboratoryService _labService;

        public ReservationController(
            ReservationService reservationService,
            UserService userService,
            LaboratoryService labService)
        {
            _reservationService = reservationService;
            _userService = userService;
            _labService = labService;
        }

        public IActionResult Index()
        {
            ViewBag.Users = _userService.ListarUsuarios();
            ViewBag.Laboratories = _labService.ListarLaboratorios();
            var reservas = _reservationService.ListarReservas();
            return View(reservas);
        }

        [HttpPost]
        public IActionResult Create(DateTime fecha, TimeSpan hora, int idUsuario, int idLaboratorio)
        {
            _reservationService.CrearReserva(fecha, hora, idUsuario, idLaboratorio);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cancel(int id)
        {
            _reservationService.CancelarReserva(id);
            return RedirectToAction("Index");
        }
    }
}