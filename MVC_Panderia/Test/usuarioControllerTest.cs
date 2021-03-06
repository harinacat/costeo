﻿using System;
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
    public class usuarioControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            usuarioController controller = new usuarioController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Login()
        {
            // Arrange
            usuarioController controller = new usuarioController();

            // Act
            ViewResult result = controller.Login("test") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            usuarioController controller = new usuarioController();

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Edit()
        {
            // Arrange
            usuarioController controller = new usuarioController();

            // Act
            ViewResult result = controller.Edit("1") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Delete()
        {
            // Arrange
            usuarioController controller = new usuarioController();

            // Act
            ViewResult result = controller.Delete("1") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


    }
}

