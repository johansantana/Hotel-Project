using Hotel.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Services.Usuario;

namespace Hotel.Web.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // GET: UsuarioController
        public async Task<IActionResult> Index()
        {
            var usuarios = await usuarioService.Get();

            if (!usuarios.success)
            {
                ViewBag.Message = usuarios.message;
                return View();
            }

            return View(usuarios.data);
        }

        // GET: UsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await usuarioService.GetById(id);

            if (!usuario.success)
            {
                ViewBag.Message = usuario.message;
                return View();
            }

            return View(usuario.data);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioAddDto usuarioAddDto)
        {
            try
            {
                var usuario = await usuarioService.Save(usuarioAddDto);

                if (!usuario.success)
                {
                    ViewBag.Message = usuario.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await usuarioService.GetById(id);

            if (!usuario.success)
            {
                ViewBag.Message = usuario.message;
                return View();
            }

            return View(usuario.data);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioUpdateDto usuarioUpdateDto)
        {
            try
            {
                var usuario = await usuarioService.Update(id, usuarioUpdateDto);

                if (!usuario.success)
                {
                    ViewBag.Message = usuario.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
