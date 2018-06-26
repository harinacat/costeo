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
    public class Cabecera_recetaTest
    {
        pan_dbEntities db = new pan_dbEntities();
       
      

        [TestMethod]
        public void InsercionCabeceraReceta()
        {
            int rct_originales = db.cabecera_receta.Count(); 
            cabecera_receta rct = new cabecera_receta();
            int id_articulo = 1;
            rct.articuloId = id_articulo;
            db.cabecera_receta.Add(rct);
            db.SaveChanges();

            int rct_cambiadas = db.cabecera_receta.Count();
            Assert.AreEqual(rct_originales + 1, rct_cambiadas);
            db.cabecera_receta.Remove(rct);
            db.SaveChanges();
        }
        [TestMethod]
        public void EliminarCabeceraReceta()
        {
            int rct_originales = db.cabecera_receta.Count();
            cabecera_receta rct = new cabecera_receta();
            int id_articulo = 1;
            rct.articuloId = id_articulo;
            db.cabecera_receta.Add(rct);
            db.SaveChanges();

            int ultima_cabecera_agregada = db.cabecera_receta.OrderByDescending(x => x.Id).First().Id;
            rct = db.cabecera_receta.Find(Convert.ToInt16(ultima_cabecera_agregada));
            db.cabecera_receta.Remove(rct);
            db.SaveChanges();
            int rct_cambiadas = db.cabecera_receta.Count();
            Assert.AreEqual(rct_cambiadas, rct_originales);

        }

        [TestMethod]
        public void MultipleCabeceraReceta()
        {
            // insertar
            int rct_originales = db.cabecera_receta.Count();
            cabecera_receta rct = new cabecera_receta();
            int id_articulo = 1;
            rct.articuloId = id_articulo;
            db.cabecera_receta.Add(rct);
            db.SaveChanges();

            //prueba que se ingrese
            int rct_cambiadas = db.cabecera_receta.Count();
            Assert.AreEqual(rct_originales + 1, rct_cambiadas);

            cabecera_receta rct2 = new cabecera_receta();
            int cabecera_agregada = db.cabecera_receta.OrderByDescending(x => x.Id).First().Id;
            rct2 = db.cabecera_receta.Find(Convert.ToInt16(cabecera_agregada));
            //Prueba de buscar
            Assert.AreEqual(rct2.articuloId, id_articulo);

            db.cabecera_receta.Remove(rct2);
            db.SaveChanges();
            int rct_cambiadas_eliminacion = db.cabecera_receta.Count();
            //Prueba si se eliminó
            Assert.AreEqual(rct_cambiadas - 1, rct_cambiadas_eliminacion);
        }

    }
}
