using Hotel.Application.Dtos;
using Hotel.Web.Services.RolUsuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class RolUsuarioController : Controller
    {
        IRolUsuarioService rolUsuarioService;

        public RolUsuarioController(IRolUsuarioService rolUsuarioService)
        {
            this.rolUsuarioService = rolUsuarioService;
        }

        // GET: RolUsuarioController
        public async Task<IActionResult> Index()
        {
            var rolUsuarios = await rolUsuarioService.Get();

            if (!rolUsuarios.success)
            {
                ViewBag.Message = rolUsuarios.message;
                return View();
            }

            return View(rolUsuarios.data);
        }

        // GET: RolUsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rolUsuario = await rolUsuarioService.GetById(id);

            if (!rolUsuario.success)
            {
                ViewBag.Message = rolUsuario.message;
                return View();
            }

            return View(rolUsuario.data);
        }

        // GET: RolUsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolUsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolUsuarioAddDto rolUsuarioAddDto)
        {
            try
            {
                var rolUsuario = await rolUsuarioService.Save(rolUsuarioAddDto);

                if (!rolUsuario.success)
                {
                    ViewBag.Message = rolUsuario.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolUsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var rolUsuario = await rolUsuarioService.GetById(id);

            if (!rolUsuario.success)
            {
                ViewBag.Message = rolUsuario.message;
                return View();
            }

            return View(rolUsuario.data);
        }

        // POST: RolUsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RolUsuarioUpdateDto rolUsuarioUpdateDto)
        {
            try
            {
                var rolUsuario = await rolUsuarioService.Update(id, rolUsuarioUpdateDto);

                if (!rolUsuario.success)
                {
                    ViewBag.Message = rolUsuario.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolUsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolUsuarioController/Delete/5
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
