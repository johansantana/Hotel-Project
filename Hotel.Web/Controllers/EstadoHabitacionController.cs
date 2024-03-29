using Hotel.Application.Dtos;
using Hotel.Web.Services.EstadoHabitacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class EstadoHabitacionController : Controller
    {
        IEstadoHabitacionService estadoHabitacionService;

        public EstadoHabitacionController(IEstadoHabitacionService estadoHabitacionService)
        {
            this.estadoHabitacionService = estadoHabitacionService;
        }

        // GET: EstadoHabitacionController
        public async Task<IActionResult> Index()
        {
            var estadosHabitacion = await estadoHabitacionService.Get();

            if (!estadosHabitacion.success)
            {
                ViewBag.Message = estadosHabitacion.message;
                return View();
            }

            return View(estadosHabitacion.data);
        }

        // GET: EstadoHabitacionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var estadoHabitacion = await estadoHabitacionService.GetById(id);

            if (!estadoHabitacion.success)
            {
                ViewBag.Message = estadoHabitacion.message;
                return View();
            }

            return View(estadoHabitacion.data);
        }

        // GET: EstadoHabitacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoHabitacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstadoHabitacionAddDto estadoHabitacionAddDto)
        {
            try
            {
                var estadoHabitacion = await estadoHabitacionService.Save(estadoHabitacionAddDto);

                if (!estadoHabitacion.success)
                {
                    ViewBag.Message = estadoHabitacion.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadoHabitacionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var estadoHabitacion = await estadoHabitacionService.GetById(id);

            if (!estadoHabitacion.success)
            {
                ViewBag.Message = estadoHabitacion.message;
                return View();
            }

            return View(estadoHabitacion.data);
        }

        // POST: EstadoHabitacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EstadoHabitacionUpdateDto estadoHabitacionUpdateDto)
        {
            try
            {
                var estadoHabitacion = await estadoHabitacionService.Update(id, estadoHabitacionUpdateDto);

                if (!estadoHabitacion.success)
                {
                    ViewBag.Message = estadoHabitacion.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadoHabitacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstadoHabitacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
