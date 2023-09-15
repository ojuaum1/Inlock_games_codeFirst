using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock.codeFirst.manha.Domain;
using WEBAPI.inlock_CodeFirst.Interfaces;
using WEBAPI.inlock_CodeFirst.Repositories;
using WEBAPI.inlock_CodeFirst.ViewModels;

namespace WEBAPI.inlock_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginControler : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public LoginControler()
        {
            usuarioRepository = new UsuarioRepository();

        }

        [HttpPost]
        public IActionResult Login(LoginViewModels usuario)
        {
            try
            {
                Usuario usuarioBuscado = usuarioRepository.(usuario.Email, usuario.Senha);

                if (usuarioBuscado != null)
                {
                    //Caso encontre o usuario, prossegue oara a criação do token

                    //1º definir as informaçãoes(claims) que serão forncedodas no token (PAYLOAD)

                    var claims = new[]
                    {
                    //formato da Claim 
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario),

                    //existe a possibilidade de criar uma Claim personalizada
                    new Claim("Claim Personalizada", "Valor da Claim Personaizada")

                };

                    //2º Definira a chave de acesso ao token
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Inlock-chave-autenticacao-webapi-dev"));

                    //3º Definir as credencias do token (HEADER)
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //4º Gerar token
                    var token = new JwtSecurityToken
                        (
                            //emissor do token
                            issuer: "inlock_games_codeFirst_manha",

                            //destinatário do token
                            audience: "inlock_games_codeFirst_manha",

                            //dados definidos nas Claims(informações)
                            claims: claims,

                            //tempo de expiração do token
                            expires: DateTime.Now.AddMinutes(5),

                            //Credenciais do Token
                            signingCredentials: creds
                        );



                    //5º retornar o token criado

                    return Ok(new
                    {

                        token = new JwtSecurityTokenHandler().WriteToken(token)

                    });
                }
                return NotFound("Email ou Senha Inválidos!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
