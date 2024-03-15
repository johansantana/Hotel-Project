using Microsoft.AspNetCore.Mvc;



namespace Hotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {
        private readonly IRecepcionRepository _recepcionRepository;

        public RecepcionController(IRecepcionRepository recepcionRepository)
        {
            _recepcionRepository = recepcionRepository ?? throw new ArgumentNullException(nameof(recepcionRepository));
        }

        [HttpGet]
        public IActionResult GetRecepciones()
        {
            var recepciones = _recepcionRepository.GetRecepciones();
            return Ok(recepciones);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecepcion(int id)
        {
            var recepcion = _recepcionRepository.GetRecepcion(id);
            if (recepcion == null)
            {
                return NotFound();
            }
            return Ok(recepcion);
        }

        [HttpPost]
        public IActionResult CreateRecepcion(Recepcion recepcion)
        {
            _recepcionRepository.AddRecepcion(recepcion);
            return CreatedAtAction(nameof(GetRecepcion), new { id = recepcion.Id }, recepcion);
        }

        [HttpPut("{id}")]
       

        [HttpDelete("{id}")]
        public IActionResult DeleteRecepcion(int id)
        {
            var recepcionToDelete = _recepcionRepository.GetRecepcion(id);
            if (recepcionToDelete == null)
            {
                return NotFound();
            }

            _recepcionRepository.DeleteRecepcion(recepcionToDelete);
            return NoContent();
        }
    }
}

   public class Recepcion
{
    public int Id { get; set; }
}


 public interface IRecepcionRepository
{
    void AddRecepcion(Recepcion recepcion);
    void DeleteRecepcion(int id);
        void DeleteRecepcion(Recepcion recepcionToDelete);
        Recepcion? GetRecepcion(int id);
    IEnumerable<Recepcion> GetRecepciones();


}
