using Microsoft.AspNetCore.Mvc;
using WEB_TALLER.Datos;
using WEB_TALLER.Models;

namespace WEB_TALLER.Controllers
{
    public class MantenedorController : Controller   
    {

        Auto_Moto _PresupuestoDato = new Auto_Moto();

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Auto OAuto)
        {

            var respuesta = _PresupuestoDato.Guardar(OAuto);

            if (respuesta)
            {
                return RedirectToAction("Guardar");

            }
            else { 
                return View();
            }

            
        }
    }
}

