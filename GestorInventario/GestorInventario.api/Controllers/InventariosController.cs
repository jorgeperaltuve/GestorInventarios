using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorInventario.api.Models.Dtos;
using GestorInventario.api.Services;
using GestorInventario.model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorInventario.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InventariosController : ControllerBase
    {
        #region Propiedades
        private readonly IElementoService _elementoSRV;
        #endregion

        #region Constructores
        public InventariosController(IElementoService elementoService)
        {
            _elementoSRV = elementoService;
        }

        #endregion

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Elemento>> ObtenerElemento(int id)
        {
            var result = await _elementoSRV.GetbyIdAsync(id);

            if (result != null)
            {
                return result;
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("CrearElementoInventario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Elemento>> CrearElementoInventario(Elemento elemento)
        {
  
            var result = await _elementoSRV.CrearElementoInventarioAsync(elemento);

            return CreatedAtAction(nameof(ObtenerElemento), new { id = elemento.ElementoId }, result);
        }


        [HttpPut("SacarElementoInventario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Elemento>> SacarElementoInventario(int id)
        {

            var result = await _elementoSRV.SacarElementoInventarioAsync(id);
            return Ok(result);
        }

        [HttpGet("ObtenerElementosDisponibles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Elemento>> ObtenerElementosDisponibles()
        {
            var result = await _elementoSRV.ObtenerTodosAsync();
            return Ok(result);
        }

        [HttpGet("ObtenerElementosNoDisponibles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Elemento>> ObtenerElementosNoDisponibles()
        {
            var result = await _elementoSRV.ObtenerTodosAsync(false);
            return Ok(result);
        }

    }
}
