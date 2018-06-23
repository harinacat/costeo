using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Panderia;
using MVC_Panderia.Controllers;
using MVC_Panderia.Models;

namespace MVC_Panderia.Tests.Controllers
{
    [TestClass]
    public class cabeceraRecetaControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.Index() as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.Create() as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.Edit(1) as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Delete()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.Delete(0) as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void IndexDetail()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.IndexDetail(1,"test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void IndexDetailCosto()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.IndexDetailCosto(1,"test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void IndexDetailPrecioVenta()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.IndexDetailPrecioVenta(1,"test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateDetail()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.CreateDetail(1,"test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateDetailCosto()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.CreateDetailCosto(1,"test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateDetailPrecioVenta()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.CreateDetailPrecioVenta(1, "test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void EditDetail()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.EditDetail(1,1,"test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void EditDetailCosto()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.EditDetailCosto(Convert.ToDateTime("01/01/2018"),1,"test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void EditDetailPrecioVenta()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.EditDetailPrecioVenta(Convert.ToDateTime("01 / 01 / 2018"), 1, "test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteDetail()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.DeleteDetail(1,1,"test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteDetailCosto()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.DeleteDetailCosto(Convert.ToDateTime("01 / 01 / 2018"),0,"test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteDetailPrecioVenta()
        {
            //// Arrange
            cabecera_recetaController controller = new cabecera_recetaController();

            //// Act
            ViewResult result = controller.DeleteDetailPrecioVenta(Convert.ToDateTime("01 / 01 / 2018"), 0, "test") as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
    }
}

