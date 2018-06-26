using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Panderia.Models;
using MVC_Panderia.Controllers;
namespace MVC_Panderia.Tests.Datos
{
    [TestClass]
    public class cebeceraProduccionTest
    {
        pan_dbEntities db = new pan_dbEntities();
        String fechaVenta = "" + DateTime.Now;

        [TestMethod]
        public void InsercionLinea()
        {
            int ln_originales = db.cabecera_produccion.Count();
            cabecera_produccion ln = new cabecera_produccion();
            ln.fecha = Convert.ToDateTime(fechaVenta);
            db.cabecera_produccion.Add(ln);
            db.SaveChanges();

            int ln_cambiadas = db.cabecera_produccion.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.cabecera_produccion.Remove(ln);
            db.SaveChanges();
        }
        [TestMethod]
        public void EliminarLinea()
        {
            cabecera_produccion ln = new cabecera_produccion();
            int ln_original = db.cabecera_produccion.Count();
            ln.fecha = Convert.ToDateTime(fechaVenta);
            db.cabecera_produccion.Add(ln);
            db.SaveChanges();
            int ultima_linea_agregada = db.cabecera_produccion.OrderByDescending(x => x.Id).First().Id;
            ln = db.cabecera_produccion.Find(Convert.ToInt16(ultima_linea_agregada));
            db.cabecera_produccion.Remove(ln);
            db.SaveChanges();
            int ln_cambiadas = db.cabecera_produccion.Count();
            Assert.AreEqual(ln_cambiadas, ln_original);

        }

        [TestMethod]
        public void MultipleLinea()
        {
            //insertar
            int ln_originales = db.cabecera_produccion.Count();
            cabecera_produccion ln = new cabecera_produccion();
            ln.fecha = Convert.ToDateTime(fechaVenta);
            db.cabecera_produccion.Add(ln);
            db.SaveChanges();

            //prueba que se ingrese
            int ln_cambiadas = db.cabecera_produccion.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.cabecera_produccion.Remove(ln);
            db.SaveChanges();

            cabecera_produccion ln2 = new cabecera_produccion();
            string nueva_fecha = "10-06-2000";
            ln2.fecha = Convert.ToDateTime(nueva_fecha);     
            db.cabecera_produccion.Add(ln2);
            db.SaveChanges();
            //Prueba de buscar
            Assert.AreEqual(ln2.fecha, Convert.ToDateTime(nueva_fecha) );

            db.cabecera_produccion.Remove(ln2);
            db.SaveChanges();
            int ln_cambiadas_eliminacion = db.cabecera_produccion.Count();
            //Prueba si se eliminó
            Assert.AreEqual(ln_cambiadas - 1, ln_cambiadas_eliminacion);
        }

    }
}
