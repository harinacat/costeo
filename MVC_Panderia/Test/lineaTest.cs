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
    public class LineaTest
    {
        pan_dbEntities db = new pan_dbEntities();
        String nombre_linea = "";

        [TestMethod]
        public void Insecion()
        {
            int ln_originales = db.linea.Count();
            linea ln = new linea();
            nombre_linea = "Prueba TEST";
            ln.nombre = nombre_linea;
            db.linea.Add(ln);
            db.SaveChanges();

            int ln_cambiadas = db.linea.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.linea.Remove(ln);
            db.SaveChanges();
        }
        [TestMethod]
        public void Eliminar()
        {
            linea ln = new linea();
            int ln_original = db.linea.Count();
            nombre_linea = "Prueba TEST";
            ln.nombre = nombre_linea;
            db.linea.Add(ln);
            db.SaveChanges();
            int ultima_linea_agregada = db.linea.OrderByDescending(x => x.Id).First().Id;
            ln = db.linea.Find(Convert.ToInt16(ultima_linea_agregada));
            db.linea.Remove(ln);
            db.SaveChanges();
            int ln_cambiadas = db.linea.Count();
            Assert.AreEqual(ln_cambiadas, ln_original);

        }

        [TestMethod]
        public void Multiple()
        {
            // insertar
            int ln_originales = db.linea.Count();
            linea ln = new linea();
            nombre_linea = "Prueba TEST";
            ln.nombre = nombre_linea;
            db.linea.Add(ln);
            db.SaveChanges();

            //prueba que se ingrese
            int ln_cambiadas = db.linea.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);

            linea ln2 = new linea();
            int linea_agregada = db.linea.OrderByDescending(x => x.Id).First().Id;
            ln2 = db.linea.Find(Convert.ToInt16(linea_agregada));
            //Prueba de buscar
            Assert.AreEqual(ln2.nombre, nombre_linea);

            db.linea.Remove(ln2);
            db.SaveChanges();
            int ln_cambiadas_eliminacion = db.linea.Count();
            //Prueba si se eliminó
            Assert.AreEqual(ln_cambiadas - 1, ln_cambiadas_eliminacion);
        }

    }
}
