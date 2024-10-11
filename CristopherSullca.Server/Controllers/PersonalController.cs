using Business;
using Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CristopherSullca.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly PersonalService personalService;

        public PersonalController(PersonalService personalService)
        {
            this.personalService = personalService;
        }

        // GET: api/<PersonalController>
        [HttpGet]
        public IActionResult ListarPersonal()
        {
            var listado = personalService.ListadoPersonal();
            return Ok(listado);
        }

        // POST api/<PersonalController>
        [HttpPost]
        public IActionResult RegistrarPersonal([FromBody] Personal personal)
        {
            string mensaje = string.Empty;
            var resultado = personalService.RegistrarPersonal(personal);

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

        // PUT api/<PersonalController>/5
        [HttpPut]
        public IActionResult EditarDatosPersonal([FromBody] Personal personal)
        {
            string mensaje = string.Empty;
            var resultado = personalService.EditarDatosPersonal(personal);

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

        // DELETE api/<PersonalController>/5
        [HttpDelete("{IdPersonal}")]
        public IActionResult EliminarPersonal(int idPersonal)
        {
            string mensaje = string.Empty;
            var resultado = personalService.EliminarPersonal(idPersonal);

            if (resultado)
            {
                mensaje = "Registro eliminado";
            }
            else
            {
                mensaje = "Error en la eliminación";
            }

            return Ok(new { message = mensaje });
        }
    }
}
