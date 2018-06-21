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
    public class articuloControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            articuloController controller = new articuloController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            articuloController controller = new articuloController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            articuloController controller = new articuloController();

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Delete()
        {
            // Arrange
            articuloController controller = new articuloController();

            // Act
            ViewResult result = controller.Delete(0) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}


