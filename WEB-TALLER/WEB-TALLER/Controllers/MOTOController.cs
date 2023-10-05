using Microsoft.AspNetCore.Mvc;
using WEB_TALLER.Datos;
using WEB_TALLER.Models;

namespace WEB_TALLER.Controllers
{
    public class MOTOController : Controller
    {
        Auto_Moto _vehiculoDato = new Auto_Moto();

        public IActionResult Guardar_moto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar_moto(Moto OMoto)
        {

            var respuesta = _vehiculoDato.Guardar_moto(OMoto);

            if (respuesta)
            {
                return RedirectToAction("Guardar_moto");

            }
            else
            {
                return View();
            }


        }
    }
}
