using MVC_Panderia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_Panderia.Controllers
{
    [Authorize]
    public class analisis_costos_kilosController : Controller
    {
        pan_dbEntities db = new pan_dbEntities();

        // GET: Linea
        public ActionResult Index()
        {
            ViewBag.familiaId = new SelectList(db.familia, "Id", "nombre");
            return View();
        }


    public ActionResult analisisCostosKilos()
        {

            return View();
        }
    }
}
    