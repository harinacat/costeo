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
    public class costoTest
    {
        pan_dbEntities db = new pan_dbEntities();
        String fecha = ""+DateTime.Now;


        [TestMethod]
        public void insercionCosto()
        {
            int ln_originales = db.costo.Count();
            costo ln = new costo();
            ln.cabecera_recetaId = 1;
            //fecha = "27/06/2018";
            int valor = 999;
            ln.fecha = Convert.ToDateTime(fecha);
            ln.valor = valor;
            db.costo.Add(ln);
            db.SaveChanges();

            int ln_cambiadas = db.costo.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.costo.Remove(ln);
            db.SaveChanges();
        }
        [TestMethod]
        public void eliminarCosto()
        {
            String fecha = "" + DateTime.Now;
            int ln_originales = db.costo.Count();
            costo ln = new costo();
            ln.cabecera_recetaId = 1;
            //fecha = "27/06/2018";
            int valor = 999;
            ln.fecha = Convert.ToDateTime(fecha);
            ln.valor = valor;
            db.costo.Add(ln);
            db.SaveChanges();

            int ln_cambiadas = db.costo.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.costo.Remove(ln);
            db.SaveChanges();


            //int ultima_linea_agregada = db.linea.OrderByDescending(x => x.Id).First().Id;
            //ln = db.linea.Find(Convert.ToInt16(ultima_linea_agregada));
            //db.linea.Remove(ln);
            //db.SaveChanges();
            //int ln_cambiadas = db.linea.Count();
            //Assert.AreEqual(ln_cambiadas, ln_original);

        }

        [TestMethod]
        public void multipleCosto()
        {
            // insertar
            costo ln = new costo();
            int ln_originales = db.costo.Count();
            ln.cabecera_recetaId = 1;
            ln.fecha = Convert.ToDateTime(fecha);
            ln.valor = 1;
            db.costo.Add(ln);
            db.SaveChanges();

            //prueba que se ingrese
            int ln_cambiadas = db.costo.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.costo.Remove(ln);
            db.SaveChanges();

            costo ln2 = new costo();
            int nuevo_valor = 2;
            ln2.cabecera_recetaId = 1;
            ln2.fecha = Convert.ToDateTime(fecha);
            ln2.valor = nuevo_valor;
            db.costo.Add(ln2);
            db.SaveChanges();
            //Prueba de buscar
            Assert.AreEqual(ln2.valor, nuevo_valor);

            db.costo.Remove(ln2);
            db.SaveChanges();
            int ln_cambiadas_eliminacion = db.costo.Count();
            //Prueba si se eliminó
            Assert.AreEqual(ln_cambiadas - 1, ln_cambiadas_eliminacion);

        }
}
}
