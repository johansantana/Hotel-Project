using Hotel.Aplication.Contracts.Categoria;
using Hotel.Aplication.Dtos.Categoria;

using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApp.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly ICategoriaService categoriaServise;
        public CategoriaController(ICategoriaService categoriaServise)
        {
            this.categoriaServise = categoriaServise;
        }
        // GET: CategoriaController
        public ActionResult Index()
        {
            var results = this.categoriaServise.GetEntities();

            if (!results.Success)
            {
                ViewBag.Message = results.Message;
                return View();
            }
            return View(results.Data);

        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.categoriaServise.GetEntity(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return View(result.Data);
            
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaAddDto categoriaAddDto)
        {
            try
            {
                categoriaAddDto.FechaCreacion = DateTime.Now;
                this.categoriaServise.SaveEntity(categoriaAddDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.categoriaServise.GetEntity(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            
            return View(result.Data);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaUpdateDto categoriaUpdateDto)
        {
           
            try
            {
                categoriaUpdateDto.IdCategoria = id;
               var result = this.categoriaServise.UpdateEntity(categoriaUpdateDto);
                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View(result);
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = categoriaServise.GetEntity(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View(result);
            }
            return View(result.Data);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            
            try
            {
                var result = categoriaServise.DeleteEntity(id);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View(result);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
