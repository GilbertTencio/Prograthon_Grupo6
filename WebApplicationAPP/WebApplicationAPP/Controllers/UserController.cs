using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Models;
using WebApplicationAPP.Services;

namespace WebApplicationAPP.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var users = _service.ListarUsuarios();
            return View(users);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _service.RegistrarUsuario(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.EliminarUsuario(id);
            return RedirectToAction("Index");
        }
    }
}