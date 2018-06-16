using MVC_Panderia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Panderia.Controllers
{
    public class analisis_costos_kilosController : Controller
    {
        pan_dbEntities1 db = new pan_dbEntities1();

        // GET: Linea
        public ActionResult Index()
        {
            ViewBag.familiaId = new SelectList(db.familias, "Id", "nombre");
            return View();
        }
    }
}