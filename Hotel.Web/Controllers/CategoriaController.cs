using Hotel.Aplication.Dtos.Categoria;
using Hotel.Domain;
using Hotel.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Security;
using System.Text;
using System.Text.Json.Serialization;

namespace Hotel.Web.Controllers
{
    public class CategoriaController : Controller
    {
        HttpClientHandler httpClientHadler = new HttpClientHandler();


        public CategoriaController()
        {

            this.httpClientHadler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };

        }
        // GET: CategoriaController
        public async Task<IActionResult> Index()
        {
            var categoria = new CategoriaDefaultResult();
            using (var httpClient = new HttpClient(this.httpClientHadler))
            {

                var URL = "https://localhost:7234/api/Categoria/GetCategoria";

                using (var response = await httpClient.GetAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categoria = JsonConvert.DeserializeObject<CategoriaDefaultResult>(apiResponse);
                        if (!categoria.success)
                        {
                            ViewBag.Message = categoria.message;
                            return View();
                        }
                    }
                }
            }
            return View(categoria.Data);
        }

        // GET: CategoriaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var categoria = new CategoriaSingleResult();
            using (var httpClient = new HttpClient(this.httpClientHadler))
            {

                var URL = "https://localhost:7234/api/Categoria/GetCategoriaById?id=";

                using (var response = await httpClient.GetAsync(URL + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                        if (!categoria.success)
                        {
                            ViewBag.Message = categoria.message;
                            return View();
                        }
                    }
                }
            }
            return View(categoria.Data);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaAddDto categoria)
        {
            try
            {

                using (var httpClient = new HttpClient(this.httpClientHadler))
                {

                    var URL = "https://localhost:7234/api/Categoria/SaveCategoria";
                    categoria.FechaCreacion = DateTime.Now;
                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoria), Encoding.UTF8, "application/json" );
                    using (var response = await httpClient.PostAsync(URL, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                            //if (!categoria.success)
                            //{
                            //    ViewBag.Message = categoria.message;
                            //    return View();
                            //}
                        }
                    }
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
            var categoria = new CategoriaSingleResult();
            using (var httpClient = new HttpClient(this.httpClientHadler))
            {

                var URL = "https://localhost:7234/api/Categoria/GetCategoriaById?id=";

                using (var response = await httpClient.GetAsync(URL + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                        if (!categoria.success)
                        {
                            ViewBag.Message = categoria.message;
                            return View();
                        }
                    }
                }
            }
            return View(categoria.Data);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( CategoriaUpdateDto categoriaUpdateDto)
        { 
            try
            {
                //Despues de ciertos updates deja de funcionar
                using (var httpClient = new HttpClient(this.httpClientHadler))
                {

                    var URL = "https://localhost:7234/api/Categoria/UpdateCategoria";
                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoriaUpdateDto), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(URL, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                            //if (!categoria.success)
                            //{
                            //    ViewBag.Message = categoria.message;
                            //    return View();
                            //}
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public async Task<ActionResult>  Delete(int id)
        {
            var categoria = new CategoriaSingleResult();
            using (var httpClient = new HttpClient(this.httpClientHadler))
            {

                var URL = "https://localhost:7234/api/Categoria/GetCategoriaById?id=";

                using (var response = await httpClient.GetAsync(URL + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                        if (!categoria.success)
                        {
                            ViewBag.Message = categoria.message;
                            return View();
                        }
                    }
                }
            }
            return View(categoria.Data);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                using (var httpClient = new HttpClient(this.httpClientHadler))
                {

                    var URL = "https://localhost:7234/api/Categoria/DeleteCategoria?id=";
                    using (var response = await httpClient.DeleteAsync(URL + id))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {

                            //string apiResponse = await response.Content.ReadAsStringAsync();
                            //categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                            //if (!categoria.success)
                            //{
                            //    ViewBag.Message = categoria.message;
                            //    return View();
                            //}
                        }
                    }
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
