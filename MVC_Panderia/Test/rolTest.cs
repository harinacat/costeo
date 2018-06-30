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
    public class rolTest
    {
        pan_dbEntities db = new pan_dbEntities();
        String nombre_linea = "";

        [TestMethod]
        public void InsecionLinea()
        {
            int ln_originales = db.rol.Count();
            rol ln = new rol();
            nombre_linea = "Prueba TEST";
            ln.nombre_rol = nombre_linea;
            db.rol.Add(ln);
            db.SaveChanges();

            int ln_cambiadas = db.rol.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.rol.Remove(ln);
            db.SaveChanges();
        }
        [TestMethod]
        public void EliminarRol()
        {
            rol ln = new rol();
            int ln_original = db.rol.Count();
            nombre_linea = "Prueba TEST";
            ln.nombre_rol = nombre_linea;
            db.rol.Add(ln);
            db.SaveChanges();
            int ultima_linea_agregada = db.rol.OrderByDescending(x => x.Id).First().Id;
            ln = db.rol.Find(Convert.ToInt16(ultima_linea_agregada));
            db.rol.Remove(ln);
            db.SaveChanges();
            int ln_cambiadas = db.rol.Count();
            Assert.AreEqual(ln_cambiadas, ln_original);

        }

        [TestMethod]
        public void MultipleLinea()
        {
            // insertar
            int ln_originales = db.rol.Count();
            rol ln = new rol();
            nombre_linea = "Prueba TEST";
            ln.nombre_rol = nombre_linea;
            db.rol.Add(ln);
            db.SaveChanges();

            //prueba que se ingrese
            int ln_cambiadas = db.rol.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);

            rol ln2 = new rol();
            int linea_agregada = db.rol.OrderByDescending(x => x.Id).First().Id;
            ln2 = db.rol.Find(Convert.ToInt16(linea_agregada));
            //Prueba de buscar
            Assert.AreEqual(ln2.nombre_rol, nombre_linea);

            db.rol.Remove(ln2);
            db.SaveChanges();
            int ln_cambiadas_eliminacion = db.rol.Count();
            //Prueba si se eliminó
            Assert.AreEqual(ln_cambiadas - 1, ln_cambiadas_eliminacion);
        }

    }
}
