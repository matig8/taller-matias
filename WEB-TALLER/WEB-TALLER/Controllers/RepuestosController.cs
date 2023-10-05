using Microsoft.AspNetCore.Mvc;
using WEB_TALLER.Datos;
using WEB_TALLER.Models;

namespace WEB_TALLER.Controllers
{
    public class RepuestosController : Controller
    {

        Auto_Moto _repuestoDato = new Auto_Moto();
        public IActionResult Lrepuesto()
        {
            var OLrpuesto = _repuestoDato.RepuestoL();
            return View(OLrpuesto);
        }

        public IActionResult Grepuesto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Grepuesto(Grepuesto ORepuesto)
        {
            var respuesta = _repuestoDato.Cargar_repuesto(ORepuesto);

            if (respuesta)
            {
                return RedirectToAction("Cargar_repuesto");

            }
            else
            {
                return View();
            }

        }
    }
}
