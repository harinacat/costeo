using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Panderia;
using MVC_Panderia.Controllers;

namespace MVC_Panderia.Tests.Controllers
{
    [TestClass]
    public class cabeceraRecetaControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //// Arrange
            cabeceraRecetaController controller = new cabeceraRecetaController();

            //// Act
            ViewResult result = controller.Index() as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            //// Arrange
            cabeceraRecetaController controller = new cabeceraRecetaController();

            //// Act
            ViewResult result = controller.Create() as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            //// Arrange
            cabeceraRecetaController controller = new cabeceraRecetaController();

            //// Act
            ViewResult result = controller.Edit(1) as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Delete()
        {
            //// Arrange
            cabeceraRecetaController controller = new cabeceraRecetaController();

            //// Act
            ViewResult result = controller.Delete(1) as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
    }
}

