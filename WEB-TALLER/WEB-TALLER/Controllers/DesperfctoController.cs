using Microsoft.AspNetCore.Mvc;
using WEB_TALLER.Datos;
using WEB_TALLER.Models;

namespace WEB_TALLER.Controllers
{
    public class DesperfctoController : Controller
    {
      
        
            Auto_Moto _DesperfectoDato = new Auto_Moto();

            public IActionResult Cargar_desperfecto()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Cargar_desperfecto(Desperfecto ODespefecto)
            {

                var respuesta = _DesperfectoDato.Cargar_desperfecto(ODespefecto);

                if (respuesta)
                {
                    return RedirectToAction("Cargar_desperfecto");

                }
                else
                {
                    return View();
                }


            }
        
    
    }
}
