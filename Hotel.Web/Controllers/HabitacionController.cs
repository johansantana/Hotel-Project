using Hotel.Application.Dtos;
using Hotel.Web.Services.Habitacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class HabitacionController : Controller
    {
        IHabitacionService habitacionService;

        public HabitacionController(IHabitacionService habitacionService)
        {
            this.habitacionService = habitacionService;
        }

        // GET: HabitacionController
        public async Task<IActionResult> Index()
        {
            var habitaciones = await habitacionService.Get();

            if (!habitaciones.success)
            {
                ViewBag.Message = habitaciones.message;
                return View();
            }

            return View(habitaciones.data);
        }

        // GET: HabitacionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var habitacion = await habitacionService.GetById(id);

            if (!habitacion.success)
            {
                ViewBag.Message = habitacion.message;
                return View();
            }

            return View(habitacion.data);
        }

        // GET: HabitacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HabitacionAddDto habitacionAddDto)
        {
            try
            {
                var habitacion = await habitacionService.Save(habitacionAddDto);

                if (!habitacion.success)
                {
                    ViewBag.Message = habitacion.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HabitacionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var habitacion = await habitacionService.GetById(id);

            if (!habitacion.success)
            {
                ViewBag.Message = habitacion.message;
                return View();
            }

            return View(habitacion.data);
        }

        // POST: HabitacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HabitacionUpdateDto habitacionUpdateDto)
        {
            try
            {
                var habitacion = await habitacionService.Update(id, habitacionUpdateDto);

                if (!habitacion.success)
                {
                    ViewBag.Message = habitacion.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HabitacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HabitacionController/Delete/5
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
