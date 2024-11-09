using Microsoft.AspNetCore.Mvc;

namespace Pettapp2.Controllers
{
    public class AccountController : Controller
    {
        // Acción para mostrar la vista de Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Acción para manejar la lógica del Login cuando se envía el formulario
        [HttpPost]
        public IActionResult Login(string usuario, string contraseña, bool remember)
        {
            // Ejemplo de autenticación básica, puedes reemplazarlo con tu lógica
            if (usuario == "admin" && contraseña == "password")
            {
                // Redirige a la página principal o donde desees después del login exitoso
                return RedirectToAction("Index", "Home");
            }

            // Si el login falla, mostramos un mensaje de error
            ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
            return View();
        }

        // Acción para la vista de registro (si tienes una)
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        // Puedes agregar otras acciones aquí si las necesitas, como para "Index" o "Logout"
    }
}
