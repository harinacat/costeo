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
    public class FamiliaTest
    {
        pan_dbEntities db = new pan_dbEntities();
        String nombre_familia = "";
      

        [TestMethod]
        public void InsercionFamilia()
        {
            int fml_originales = db.familia.Count(); 
            familia fml = new familia();
            nombre_familia = "prueba TEST";
            int id_linea = 1;
            fml.nombre = nombre_familia;
            fml.lineaId = Convert.ToInt16(id_linea);
            db.familia.Add(fml);
            db.SaveChanges();

            int fml_cambiadas = db.familia.Count();
            Assert.AreEqual(fml_originales + 1, fml_cambiadas);
            db.familia.Remove(fml);
            db.SaveChanges();
        }
        [TestMethod]
        public void EliminarFamilia()
        {
            int fml_original = db.familia.Count(); 
            familia fml = new familia();
            nombre_familia = "prueba TEST";
            int id_linea = 1;
            fml.nombre = nombre_familia;
            fml.lineaId = Convert.ToInt16(id_linea);
            db.familia.Add(fml);
            db.SaveChanges();

            int ultima_familia_agregada = db.familia.OrderByDescending(x => x.Id).First().Id;
            fml = db.familia.Find(Convert.ToInt16(ultima_familia_agregada));
            db.familia.Remove(fml);
            db.SaveChanges();
            int fml_cambiadas = db.familia.Count();
            Assert.AreEqual(fml_cambiadas, fml_original);

        }

        [TestMethod]
        public void MultipleFamilia()
        {
            // insertar
            int fml_original = db.familia.Count();
            familia fml = new familia();
            nombre_familia = "prueba TEST";
            int id_linea = 1;
            fml.nombre = nombre_familia;
            fml.lineaId = Convert.ToInt16(id_linea);
            db.familia.Add(fml);
            db.SaveChanges();

            //prueba que se ingrese
            int fml_cambiadas = db.familia.Count();
            Assert.AreEqual(fml_original + 1, fml_cambiadas);

            familia fml2 = new familia();
            int familia_agregada = db.familia.OrderByDescending(x => x.Id).First().Id;
            fml2 = db.familia.Find(Convert.ToInt16(familia_agregada));
            //Prueba de buscar
            Assert.AreEqual(fml2.nombre, nombre_familia);

            db.familia.Remove(fml2);
            db.SaveChanges();
            int fml_cambiadas_eliminacion = db.familia.Count();
            //Prueba si se eliminó
            Assert.AreEqual(fml_cambiadas - 1, fml_cambiadas_eliminacion);
        }

    }
}
