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
    public class unidadTest
    {
        pan_dbEntities db = new pan_dbEntities();
        String nombre_linea = "";

        [TestMethod]
        public void insecionUnidad()
        {
            int ln_originales = db.unidad_medida.Count();
            unidad_medida ln = new unidad_medida();
            nombre_linea = "Prueba";
            ln.nombre = nombre_linea;
            db.unidad_medida.Add(ln);
            db.SaveChanges();

            int ln_cambiadas = db.unidad_medida.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.unidad_medida.Remove(ln);
            db.SaveChanges();
        }
        [TestMethod]
        public void eliminarUnidad()
        {
            int ln_originales = db.unidad_medida.Count();
            unidad_medida ln = new unidad_medida();
            nombre_linea = "Prueba";
            ln.nombre = nombre_linea;
            db.unidad_medida.Add(ln);
            db.SaveChanges();
            int ultima_linea_agregada = db.unidad_medida.OrderByDescending(x => x.Id).First().Id;
            ln = db.unidad_medida.Find(Convert.ToInt16(ultima_linea_agregada));
            db.unidad_medida.Remove(ln);
            db.SaveChanges();
            int ln_cambiadas = db.unidad_medida.Count();
            Assert.AreEqual(ln_cambiadas, ln_originales);

        }

        [TestMethod]
        public void multipleUnidad()
        {
            // insertar
            int ln_originales = db.unidad_medida.Count();
            unidad_medida ln = new unidad_medida();
            nombre_linea = "Prueba";
            ln.nombre = nombre_linea;
            db.unidad_medida.Add(ln);
            db.SaveChanges();

            //prueba que se ingrese
            int ln_cambiadas = db.unidad_medida.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);

            unidad_medida ln2 = new unidad_medida();
            int linea_agregada = db.unidad_medida.OrderByDescending(x => x.Id).First().Id;
            ln2 = db.unidad_medida.Find(Convert.ToInt16(linea_agregada));
            //Prueba de buscar
            Assert.AreEqual(ln2.nombre, nombre_linea);

            db.unidad_medida.Remove(ln2);
            db.SaveChanges();
            int ln_cambiadas_eliminacion = db.unidad_medida.Count();
            //Prueba si se eliminó
            Assert.AreEqual(ln_cambiadas - 1, ln_cambiadas_eliminacion);
        }

    }
}
