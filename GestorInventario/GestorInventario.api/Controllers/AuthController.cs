using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GestorInventario.api.Configuration;
using GestorInventario.api.Models.Dtos;
using GestorInventario.api.Services;
using GestorInventario.model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GestorInventario.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioSRV;
        private readonly IOptionsSnapshot<TokenManager> _appSettings;
        public AuthController(IUsuarioService usuarioSRV, IOptionsSnapshot<TokenManager> appSettings)
        {
            _usuarioSRV = usuarioSRV;
            _appSettings = appSettings;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public IActionResult Token(UsuarioDTO usuarioDTO)
        {
            var usuario = _usuarioSRV.UsuarioEsValido(usuarioDTO.NombreAcceso, usuarioDTO.Clave);

            if (usuario != null)
            {
                return Ok(new { token = GenerarToken(usuario) });
            }
            else
            {
                return BadRequest(new { message = "Nombre de acceso o clave incorrecta." });
            }

        }

        private string GenerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.UsuarioId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.Value.AccessExpiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}