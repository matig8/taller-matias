using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using System.Reflection.Emit;
using System.Reflection;
using System;
using WEB_TALLER.Models;
using WEB_TALLER.Datos;

namespace WEB_TALLER.Controllers
{
    public class PresupuestoController : Controller
    {
        Auto_Moto _PresupuestoDato = new Auto_Moto();
        public IActionResult Cargar_presupuesto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cargar_presupuesto(Presupuesto OPresupuesto)
        {

            var respuesta = _PresupuestoDato.Cargar_presupuesto(OPresupuesto);

            if (respuesta)
            {
                return RedirectToAction("Cargar_presupuesto");

            }
            else
            {
                return View();
            }


        }
    }
}
