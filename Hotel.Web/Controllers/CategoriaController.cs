using Hotel.Aplication.Dtos.Categoria;
using Hotel.Web.Contracts.Categoria;
using Hotel.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace Hotel.Web.Controllers
{
    public class CategoriaController : Controller
    {
        HttpClientHandler httpClientHadler = new HttpClientHandler();

        private readonly ICategoriaServise categoriaServise;
        public CategoriaController(ICategoriaServise categoriaServise)
        {
            this.categoriaServise = categoriaServise;

        }
        // GET: CategoriaController
        public  IActionResult Index()
        {

            var URL = "https://localhost:7234/api/Categoria/GetCategoria";
            var categorias =  categoriaServise.getAsync(URL);

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
            var URL = $"https://localhost:7234/api/Categoria/GetCategoriaById?id={id}";
            var categoria = categoriaServise.getAsyncOne(URL);

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

                var URL = "https://localhost:7234/api/Categoria/SaveCategoria";
                categoriaAdd.FechaCreacion = DateTime.Now;
                 categoria =  categoriaServise.post(URL, categoriaAdd);
 
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
        public async Task<IActionResult> Edit(int id)
        {
            //Despues de ciertos updates deja de funcionar
            var URL = $"https://localhost:7234/api/Categoria/GetCategoriaById?id={id}";

            var categoria =  categoriaServise.getAsyncOne(URL);

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
                var URL = "https://localhost:7234/api/Categoria/UpdateCategoria";
               // categoriaUpdateDto.IdCategoria = id;
                 categoria = categoriaServise.put(URL, categoriaUpdateDto);

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
            var URL = $"https://localhost:7234/api/Categoria/GetCategoriaById?id={id}";
            var categoria =  categoriaServise.getAsyncOne(URL);

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
                var URL = $"https://localhost:7234/api/Categoria/DeleteCategoria?id={id}";

                categoria =  categoriaServise.delete(URL);

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
