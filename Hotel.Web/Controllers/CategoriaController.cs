using Hotel.Aplication.Dtos.Categoria;
using Hotel.Web.Contracts.Categoria;
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
            //this.httpClientHadler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };

        }
        // GET: CategoriaController
        public async Task<IActionResult> Index()
        {

            var URL = "https://localhost:7234/api/Categoria/GetCategoria";
            var categorias = await categoriaServise.getAsync(URL);

            //var categoria = new CategoriaDefaultResult();
            //using (var httpClient = new HttpClient(this.httpClientHadler))
            //{



            //    using (var response = await httpClient.GetAsync(URL))
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            string apiResponse = await response.Content.ReadAsStringAsync();
            //            categoria = JsonConvert.DeserializeObject<CategoriaDefaultResult>(apiResponse);
            if (!categorias.success)
            {
                ViewBag.Message = categorias.message;
                return View();
            }
            //        }
            //    }
            //}
            return View(categorias.Data);
        }

        // GET: CategoriaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var URL = $"https://localhost:7234/api/Categoria/GetCategoriaById?id={id}";
            var categoria = await categoriaServise.getAsyncOne(URL);

            //using (var httpClient = new HttpClient(this.httpClientHadler))
            //{



            //using (var response = await httpClient.GetAsync(URL + id))
            //{
            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);

            if (!categoria.success)
            {
                ViewBag.Message = categoria.message;
                return View();
            }
            //        }
            //    }
            //}
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
        public IActionResult Create(CategoriaAddDto categoria)
        {
            try
            {

                var URL = "https://localhost:7234/api/Categoria/SaveCategoria";
              categoriaServise.post(URL, categoria);
                //using (var httpClient = new HttpClient(this.httpClientHadler))
                //{


                //    using (var response = await httpClient.DeleteAsync(URL + id))
                //    {
                //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //        {

                //string apiResponse = await response.Content.ReadAsStringAsync();
                //categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                //if (!categoria.success)
                //{
                //    ViewBag.Message = categoria.message;
                //    return View();
                //}
                //        }
                //    }
                //}

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

            var categoria = await categoriaServise.getAsyncOne(URL);
            //using (var httpClient = new HttpClient(this.httpClientHadler))
            //{



            //using (var response = await httpClient.GetAsync(URL + id))
            //{
            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
            if (!categoria.success)
            {
                ViewBag.Message = categoria.message;
                return View();
            }
            //        }
            //    }
            //}
            return View(categoria.Data);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoriaUpdateDto categoriaUpdateDto)
        {
            try
            {
                var URL = "https://localhost:7234/api/Categoria/UpdateCategoria";
                categoriaServise.put(URL, categoriaUpdateDto);


                //Despues de ciertos updates deja de funcionar
                //using (var httpClient = new HttpClient(this.httpClientHadler))
                //{


                //    StringContent content = new StringContent(JsonConvert.SerializeObject(categoriaUpdateDto), Encoding.UTF8, "application/json");
                //    using (var response = await httpClient.PostAsync(URL, content))
                //    {
                //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //        {

                //string apiResponse = await response.Content.ReadAsStringAsync();
                //categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                //if (!categoria.success)
                //{
                //    ViewBag.Message = categoria.message;
                //    return View();
                //}
                //        }
                //    }
                //}

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var URL = $"https://localhost:7234/api/Categoria/GetCategoriaById?id={id}";
            var categoria = await categoriaServise.getAsyncOne(URL);

            //using (var httpClient = new HttpClient(this.httpClientHadler))
            //{



            //using (var response = await httpClient.GetAsync(URL + id))
            //{
            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);

            if (!categoria.success)
            {
                ViewBag.Message = categoria.message;
                return View();
            }
            //        }
            //    }
            //}
            return View(categoria.Data);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var URL = $"https://localhost:7234/api/Categoria/DeleteCategoria?id={id}";

                categoriaServise.delete(URL);
                //using (var httpClient = new HttpClient(this.httpClientHadler))
                //{


                //    using (var response = await httpClient.DeleteAsync(URL + id))
                //    {
                //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //        {

                            //string apiResponse = await response.Content.ReadAsStringAsync();
                            //categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                            //if (!categoria.success)
                            //{
                            //    ViewBag.Message = categoria.message;
                            //    return View();
                            //}
                //        }
                //    }
                //}

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
