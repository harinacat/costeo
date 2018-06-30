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
    public class usuarioTest
    {
        pan_dbEntities db = new pan_dbEntities();
        String nombre_linea = "";

        [TestMethod]
        public void InsecionUsuario()
        {
            int ln_originales = db.usuario.Count();
            usuario ln = new usuario();
            nombre_linea = "Prueba TEST";
            ln.Id = "123456789";
            ln.nombre_usuario = nombre_linea;
            ln.contraseña = nombre_linea;
            ln.email = nombre_linea;
            ln.rolId = 1;
            db.usuario.Add(ln);
            db.SaveChanges();

            int ln_cambiadas = db.usuario.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);
            db.usuario.Remove(ln);
            db.SaveChanges();
        }
        [TestMethod]
        public void EliminarLinea()
        {
            usuario ln = new usuario();
            int ln_original = db.usuario.Count();
            nombre_linea = "Prueba TEST";
            ln.Id = "1";
            ln.nombre_usuario = nombre_linea;
            ln.contraseña = nombre_linea;
            ln.email = nombre_linea;
            ln.rolId = 1;
            db.usuario.Add(ln);
            db.SaveChanges();
            string ultima_linea_agregada = db.usuario.OrderBy(x => x.Id).First().Id;
            ln = db.usuario.Find(Convert.ToString(ultima_linea_agregada));
            db.usuario.Remove(ln);
            db.SaveChanges();
            int ln_cambiadas = db.usuario.Count();
            Assert.AreEqual(ln_cambiadas, ln_original);

        }

        [TestMethod]
        public void MultipleLinea()
        {
            // insertar
            int ln_originales = db.usuario.Count();
            usuario ln = new usuario();
            nombre_linea = "Prueba TEST";
            ln.Id = "1";
            ln.nombre_usuario = nombre_linea;
            ln.contraseña = nombre_linea;
            ln.email = nombre_linea;
            ln.rolId = 1;
            db.usuario.Add(ln);
            db.SaveChanges();

            //prueba que se ingrese
            int ln_cambiadas = db.usuario.Count();
            Assert.AreEqual(ln_originales + 1, ln_cambiadas);

            usuario ln2 = new usuario();
            string linea_agregada = db.usuario.OrderBy(x => x.Id).First().Id;
            ln2 = db.usuario.Find(Convert.ToString(linea_agregada));
            //Prueba de buscar
            Assert.AreEqual(ln2.nombre_usuario, nombre_linea);

            db.usuario.Remove(ln2);
            db.SaveChanges();
            int ln_cambiadas_eliminacion = db.usuario.Count();
            //Prueba si se eliminó
            Assert.AreEqual(ln_cambiadas - 1, ln_cambiadas_eliminacion);
        }

    }
}
