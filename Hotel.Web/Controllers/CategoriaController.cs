using Hotel.Aplication.Dtos.Categoria;
using Hotel.ApiConsumption.Contracts.Categoria;

using Hotel.ApiConsumption.Models;
using Microsoft.AspNetCore.Mvc;


namespace Hotel.Web.Controllers
{
    public class CategoriaController : Controller
    {
       private readonly HttpClientHandler httpClientHadler = new HttpClientHandler();

        private readonly ICategoriaServise categoriaServise;
        public CategoriaController(ICategoriaServise categoriaServise)
        {
            this.categoriaServise = categoriaServise;

        }
        // GET: CategoriaController
        public  IActionResult Index()
        {

            var categorias = categoriaServise.getAsync();

            if (!categorias.success)
            {
                ViewBag.Message = categorias.message;
                return View();
            }

            return View(categorias.Data);
        }

        // GET: CategoriaController/Details/5
        public  IActionResult Details(int id)
        {
            var categoria = categoriaServise.getAsyncOne(id);

            if (!categoria.success)
            {
                ViewBag.Message = categoria.message;
                return View();
            }

            return View(categoria.Data);
        }

        // GET: CategoriaController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(CategoriaAddDto categoriaAdd)
        {
            CategoriaSingleResult categoria = new CategoriaSingleResult();
            try
            {
                categoriaAdd.FechaCreacion = DateTime.Now;
                 categoria =  categoriaServise.post(categoriaAdd);
 
                if (!categoria.success)
                {
                    ViewBag.Message = categoria.message;
                    return View();

                }



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public  IActionResult Edit(int id)
        {
            var categoria =  categoriaServise.getAsyncOne(id);

            if (!categoria.success)
            {
                ViewBag.Message = categoria.message;
                return View();
            }
 
            return View(categoria.Data);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(CategoriaUpdateDto categoriaUpdateDto)    
        {
            CategoriaSingleResult categoria = new CategoriaSingleResult();
            try
            {
               // categoriaUpdateDto.IdCategoria = id;
                 categoria = categoriaServise.put(categoriaUpdateDto);

                if (!categoria.success)
                {
                    ViewBag.Message = categoria.message;
                    return View();
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public  IActionResult Delete(int id)
        {
            var categoria =  categoriaServise.getAsyncOne(id);

            if (!categoria.success)
            {
                ViewBag.Message = categoria.message;
                return View();
            }

            return View(categoria.Data);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Delete(int id, IFormCollection collection)
        {
            CategoriaSingleResult categoria = new CategoriaSingleResult();
            try
            {
                categoria =  categoriaServise.delete(id);

                if (!categoria.success)
                {
                    ViewBag.Message = categoria.message;
                    return View();
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
