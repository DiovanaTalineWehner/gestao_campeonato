using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using gestao_campeonato.Auth;
using gestao_campeonato.Database;
using gestao_campeonato.Service;
using gestao_campeonato.Models;
using gestao_campeonato.Service.Communication;
using Microsoft.IdentityModel.Tokens;

namespace gestao_campeonato.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var usuarios = await _usuarioService.ListAsync();
            return usuarios;
        }

        /*[HttpPost]
       public async Task<ActionResult> CadastrarUsuario(Usuario usuario)
       {
           await _usuarioService.CadastrarUsuario(usuario);
           return Ok(new { message = "Usuario created" });
       }   */

        [HttpPost]
        [Route("CadastrarUsuario")]
        public async Task<ActionResult> CadastrarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest();
                }
    
                var result = await _usuarioService.CadastrarUsuario(usuario);
    
                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            var user = await _usuarioService.GetUsuarioByEmail(model.UserName);

            if (user is not null && _usuarioService.CheckPasswordAsync(user, model.Password))
            {

                var authClaims = new List<Claim>
                {
                    new (ClaimTypes.Name, user.email_usuario),
                    new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = GetToken(authClaims);

                // Adicione o token como um cookie na resposta
                var cookieOptions = new CookieOptions
                {
                    // é interessante que a data de expiração do cookie seja inferior à do token
                    Expires = DateTime.UtcNow.AddHours(2),
                    HttpOnly = false,
                    Secure = false //usar true só se tiver HTTPS
                };

                Response.Cookies.Append(CookieTokenName.title, token.Token, cookieOptions);

                return Ok(new ResponseModel { Data = token });
            }

            return Unauthorized();
                                                            
        //Enviar a informação para o Front-end
        //if (usuarioAutenticado)
        // {
        // Session["Username"] = username; // Armazena o nome de usuário na sessão
        // Response.Redirect("index.html"); // Redireciona para a página principal do site
        // }
        // else
        // {
        //Login inválido
        // Exibir mensagem de erro
        // }
                                                             




        // protected void Page_Load(object sender, EventArgs e)
        // {
        // if (Session["Username"] != null)
        //   {
        //   string username = Session["Username"].ToString();
        //    userHeader.Text = "Bem-vindo, " + username;
        //   }
        // }



        }

        private TokenModel GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            /*var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddHours(2),
                HttpOnly = true,
                Secure = false
            };

            Response.Cookies.Append(CookieTokenName.title, new JwtSecurityTokenHandler().WriteToken(token), cookieOptions);*/

            return new()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo,
                
            };

        }
        public class CookieTokenName{
            public const string title = "Token"; 
        }

    }
}