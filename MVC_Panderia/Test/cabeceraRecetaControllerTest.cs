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
    }
}

