using Microsoft.AspNetCore.Mvc;
using WEB_TALLER.Datos;

namespace WEB_TALLER.Controllers
{
    public class TotalController : Controller
    {
        Auto_Moto _TotalDato = new Auto_Moto();
        public IActionResult TotalL()
        {
            var OTotal = _TotalDato.TotalL();
            return View(OTotal);
        }
    }
}
