using Microsoft.AspNetCore.Mvc;
using RequerimientosDTO;
using RequerimientoService;
namespace AplicacionDeRequerimientos
{
    [Route("Requerimientos")]
    [ApiController]
    public class RequerimientoController : ControllerBase
    {

        private Service requerimientoservice = new Service();

        [HttpPost]
        public IActionResult DarDeAltoRequerimiento([FromBody] RequerimientoACrearDTO requerimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultado = requerimientoservice.AgregarRequerimiento(requerimiento);
            return Ok(resultado);
        }
        [HttpGet]
        public IActionResult ObtenerListadoRequerimientos()
        {
            var resultado = requerimientoservice.ObtenerRequerimientos();
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        public IActionResult EliminarRequerimiento(int id)
        {
            var eliminado = requerimientoservice.EliminarRequerimientoPorId(id);
            if (eliminado)
            {
                return Ok(); 
            }
            return NotFound(); 
        }
        
        [HttpPut("{id}/{estado}")]
        public IActionResult ActualizarEstado(int id, Estado estado)
        {
            var resultado = requerimientoservice.ActualizarEstadoPorId(id, estado);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return NotFound();
        }
    }

}
