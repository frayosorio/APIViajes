using DominioAPIViajes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioAPIViajes.Interfaces;

namespace ControladorAPIViajes.Controllers
{
    [ApiController]
    [Route("api/viajes")]
    public class ViajeController : Controller
    {
        private readonly IViajeServicio service;

        public ViajeController(IViajeServicio service)
        {
            this.service = service;
        }


        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var viajes = service.ObtenerTodos();
            return Ok(viajes);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var viaje = service.ObtenerPorId(id);
            return Ok(viaje);
        }

        [HttpGet("origendestino/{idOrigen}/{idDestino}")]
        public IActionResult ObtenerTodos(int idOrigen, int idDestino)
        {
            var viajes = service.ObtenerPorOrigenDestino(idOrigen, idDestino);
            return Ok(viajes);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] Viaje viaje)
        {
            service.Agregar(viaje);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = viaje.Id }, viaje);
        }

    }
}
