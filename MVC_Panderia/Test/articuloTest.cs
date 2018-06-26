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
    public class articuloTest
    {
        pan_dbEntities db = new pan_dbEntities();
        String nombre_articulo = "";
        int testId = 1;

        [TestMethod]
        public void insercionArticulo()
        {
            int ln_originales = db.articulo.Count();
            articulo ln = new articulo();
            nombre_articulo = "Prueba TEST";
            ln.familiaId = testId;
            ln.nombre = nombre_articulo;
            ln.unidad_medidaId = testId;
            ln.codigo_barra = nombre_articulo;
            ln.marca = nombre_articulo;
            ln.formato = nombre_articulo;
            db.articulo.Add(ln);
            db.SaveChanges();

            int ln_cambiadas = db.articulo.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.articulo.Remove(ln);
            db.SaveChanges();
        }
        [TestMethod]
        public void eliminarArticulo()
        {
            articulo ln = new articulo();
            int ln_originales = db.articulo.Count();
            nombre_articulo = "Prueba TEST";
            ln.familiaId = testId;
            ln.nombre = nombre_articulo;
            ln.unidad_medidaId = testId;
            ln.codigo_barra = nombre_articulo;
            ln.marca = nombre_articulo;
            ln.formato = nombre_articulo;
            db.articulo.Add(ln);
            db.SaveChanges();
            int ultima_linea_agregada = db.articulo.OrderByDescending(x => x.Id).First().Id;
            ln = db.articulo.Find(Convert.ToInt16(ultima_linea_agregada));
            db.articulo.Remove(ln);
            db.SaveChanges();
            int ln_cambiadas = db.articulo.Count();
            Assert.AreEqual(ln_cambiadas, ln_originales);

        }

        [TestMethod]
        public void multipleArticulo()
        {
            // insertar
            articulo ln = new articulo();
            int ln_originales = db.articulo.Count();
            nombre_articulo = "Prueba TEST";
            ln.familiaId = testId;
            ln.nombre = nombre_articulo;
            ln.unidad_medidaId = testId;
            ln.codigo_barra = nombre_articulo;
            ln.marca = nombre_articulo;
            ln.formato = nombre_articulo;
            db.articulo.Add(ln);
            db.SaveChanges();

            //prueba que se ingrese
            int ln_cambiadas = db.articulo.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);

            articulo ln2 = new articulo();
            int linea_agregada = db.articulo.OrderByDescending(x => x.Id).First().Id;
            ln2 = db.articulo.Find(Convert.ToInt16(linea_agregada));
            //Prueba de buscar
            Assert.AreEqual(ln2.nombre, nombre_articulo);

            db.articulo.Remove(ln2);
            db.SaveChanges();
            int ln_cambiadas_eliminacion = db.articulo.Count();
            //Prueba si se eliminó
            Assert.AreEqual(ln_cambiadas - 1, ln_cambiadas_eliminacion);
        }

    }
}
