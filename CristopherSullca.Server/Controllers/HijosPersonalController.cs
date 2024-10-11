using Business;
using Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CristopherSullca.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HijosPersonalController : ControllerBase
    {
        private readonly HijosService hijosService;
         
        public HijosPersonalController(HijosService hijosService)
        {
            this.hijosService = hijosService;
        }

        // GET: api/<HijosPersonalController>
        [HttpGet("{idPersonal}")]
        public IActionResult ListarHijosPersonal(int idPersonal)
        {
            var listaHijos = hijosService.ListadoHijos(idPersonal);
            return Ok(listaHijos);
        }

        // POST api/<HijosPersonalController>
        [HttpPost]
        public IActionResult RegistrarHijosPersonal([FromBody] Hijos hijos)
        {
            string mensaje = string.Empty;
            var resultado = hijosService.RegistrarHijos(hijos);

            if (resultado)
            {
                mensaje = "Registro exitoso";
                return Ok(new { message = mensaje });
            }
            else
            {
                mensaje = "Error en el registro";
                return BadRequest(new { message = mensaje });
            }
        }

        // PUT api/<HijosPersonalController>/5
        [HttpPut]
        public IActionResult EditarHijosPersonal([FromBody] Hijos hijos)
        {
            string mensaje = string.Empty;
            var resultado = hijosService.EditarHijos(hijos);

            if (resultado)
            {
                mensaje = "Datos actualizados con exito";
                return Ok(new { message = mensaje });
            }
            else
            {
                mensaje = "Error en la actualización";
                return BadRequest(new { message = mensaje });
            }
        }

        // DELETE api/<HijosPersonalController>/5
        [HttpDelete("{idHijo}")]
        public IActionResult EliminarHijosPersonal(int idHijo)
        {
            string mensaje = string.Empty;
            var resultado = hijosService.EliminarHijos(idHijo);

            if (resultado)
            {
                mensaje = "Registro eliminado";
                return Ok(new { message = mensaje });
            }
            else
            {
                mensaje = "Error en la eliminación";
                return BadRequest(new { message = mensaje });
            }
        }
    }
}
