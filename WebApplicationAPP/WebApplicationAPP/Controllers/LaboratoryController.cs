using Microsoft.AspNetCore.Mvc;
using WebApplicationAPP.Models;
using WebApplicationAPP.Services;

namespace WebApplicationAPP.Controllers
{
    public class LaboratoryController : Controller
    {
        private readonly LaboratoryService _service;

        public LaboratoryController(LaboratoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var labs = _service.ListarLaboratorios();
            return View(labs);
        }

        [HttpPost]
        public IActionResult Create(Laboratory lab)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _service.RegistrarLaboratorio(lab);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.EliminarLaboratorio(id);
            return RedirectToAction("Index");
        }
    }
}