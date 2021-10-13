using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Trabajo_VentaEntradas.BaseDato;
using Trabajo_VentaEntradas.Models;

namespace Trabajo_VentaEntradas.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly EntradasDbContext _context;
        private const string _Return_Url = "ReturnUrl";

        public LoginController(EntradasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            // Guardamos la url de retorno para que una vez concluído el login del 
            // usuario lo podamos redirigir a la página en la que se encontraba antes
            TempData[_Return_Url] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string dni, string contrasenia, Rol rol)
        {
            string returnUrl = TempData[_Return_Url] as string;

            if (!string.IsNullOrWhiteSpace(dni) && !string.IsNullOrWhiteSpace(contrasenia))
            {
                Usuario usuario = null;

                if (rol == Rol.Cliente)
                {
                    usuario = _context.Cliente.FirstOrDefault(o => o.dni.ToUpper() == dni.ToUpper() && contrasenia == o.contrasenia);
                }
                else if (rol == Rol.Administrador)
                {
                    usuario = _context.Administrador.FirstOrDefault(o => o.dni.ToUpper() == dni.ToUpper() && contrasenia == o.contrasenia);
                }

                if (usuario != null)
                {
                    // Se crean las credenciales del usuario que serán incorporadas al contexto
                    ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                    // El lo que luego obtendré al acceder a User.Identity.Name
                    identity.AddClaim(new Claim(ClaimTypes.Name, usuario.nombre));

                    // Se utilizará para la autorización por roles
                    identity.AddClaim(new Claim(ClaimTypes.Role, usuario.Rol.ToString()));

                    // Lo utilizaremos para acceder al Id del usuario que se encuentra en el sistema.
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.dni.ToString()));

                    // Lo utilizaremos cuando querramos mostrar el nombre del usuario logueado en el sistema.
                    identity.AddClaim(new Claim(ClaimTypes.GivenName, usuario.nombre));

                    //identity.AddClaim(new Claim(nameof(Usuario.Foto), usuario.Foto ?? string.Empty));

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    // En este paso se hace el login del usuario al sistema
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                    TempData["LoggedIn"] = true;

                    //if (!string.IsNullOrWhiteSpace(returnUrl))
                    //    return Redirect(returnUrl);

                    if (rol == Rol.Cliente)
                    {
                        return RedirectToAction(nameof(ClienteController.Home), "Cliente");
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }


                }
            }

            // Completo estos dos campos para poder retornar a la vista en caso de errores.
            ViewBag.Error = "Usuario o contraseña incorrectos";
            ViewBag.dni = dni;
            TempData[_Return_Url] = returnUrl;

            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult NoAutorizado()
        {
            return View();
        }
    }
}
