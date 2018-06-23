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
    public class analisisCostosJornadaControllerTest  
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            analisis_costos_jornadaController controller = new analisis_costos_jornadaController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            analisis_costos_jornadaController controller = new analisis_costos_jornadaController();

            // Act
            ViewResult result = controller.analisisJornada() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}


