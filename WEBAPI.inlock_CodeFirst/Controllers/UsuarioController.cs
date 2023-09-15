using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codeFirst.manha.Domain;
using WEBAPI.inlock_CodeFirst.Interfaces;
using WEBAPI.inlock_CodeFirst.Repositories;

namespace WEBAPI.inlock_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        
        }
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.cadastrar(usuario);
                return Ok(usuario);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
