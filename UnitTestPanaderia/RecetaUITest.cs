using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MVC_Panderia.Controllers;


namespace UITestProject
{
    [TestClass]
    public class RecetaUITest
    {
        

        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void _Login()
        {
            //Acceder a Panaderia Cat a Través de Login
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("jlagos");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();
        }

        [Test]
        public void CrearRecetaTest()
        {
            //MVC_Panderia.Models.pan_dbEntities db = new MVC_Panderia.Models.pan_dbEntities();
            //////Obtiene el numero de recetas actuales
            //int FilasActuales = db.cabecera_receta.co.
            //Acceder a contenedor Maestro: Receta
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            //Accede a Crear Receta
            driver.FindElement(By.Id("nuevo-receta")).Click();
            driver.FindElement(By.Id("articulo-Id")).Click();
            driver.FindElement(By.Id("articulo-Id")).SendKeys("Baguette");
            driver.FindElement(By.Id("guardar-receta")).Click();
            ////Valida que se haya insertado la receta
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(FilasActuales + 1, db.cabecera_receta.Local.Count);

        }


        [Test]
        public void EditarRecetaTest()
        {
            //Acceder a contenedor Maestro: Receta
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            //Accede a Editar Receta
            driver.FindElement(By.Id("editar-receta")).Click();
            driver.FindElement(By.Id("articulo-Id")).Click();
            driver.FindElement(By.Id("articulo-Id")).SendKeys("Pan de molde Integral");
            driver.FindElement(By.Id("guardar-receta")).Click();
        }

        [Test]
        public void EliminarRecetaTest()
        {
            //Acceder a contenedor Maestro: Receta
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            //Accede a eliminar Receta
            driver.FindElement(By.Id("eliminar-receta")).Click();
            driver.FindElement(By.Id("eliminar-receta")).Click();
        }

    }
}
