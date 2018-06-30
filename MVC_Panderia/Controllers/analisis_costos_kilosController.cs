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

        // GET: Analisis costos por kilos
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReportKilos(FormCollection collection)
        {
            /*var query = from DetProd in db.detalle_produccion
                        join Costo in db.costo on DetProd.cabecera_recetaId equals Costo.cabecera_recetaId*/
            var query = from DetProd in db.detalle_produccion
                        join PreVenta in db.precio_venta on DetProd.cabecera_recetaId equals PreVenta.cabecera_recetaId
                        join Costo in db.costo on DetProd.cabecera_recetaId equals Costo.cabecera_recetaId
                        where DetProd.cabecera_recetaId != 1
                        group DetProd by DetProd.fechacosto >= Convert.ToDateTime(collection.Get("id"));

            return View();
        }

        internal ViewResult analisis_costos_kilos()
        {
            throw new NotImplementedException();
        }
    }
}
