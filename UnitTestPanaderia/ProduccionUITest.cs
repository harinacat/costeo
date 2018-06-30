using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Panderia.Models;
using MVC_Panderia.Controllers;



namespace UITestProject
{
    [TestClass]
    public class ProduccionUITest
    {
        pan_dbEntities db = new pan_dbEntities();

        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();

        private void _Login()
        {
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("rcaro");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();
        }

        [Test]
        public void CrearNuevaProduccionTest()
        {
            _Login();
            driver.Navigate().GoToUrl(url + "/cabecera_produccion");
            driver.FindElement(By.Id("nueva-produccion")).Click();
            driver.FindElement(By.Id("input-fecha")).SendKeys("01-01-2010");
            driver.FindElement(By.Id("fecha-guardar")).Click();

        }


        [Test]
        public void EditarRecetaTest()
        {
            _Login();
            int ultima_id = db.cabecera_produccion.OrderByDescending(x => x.Id).First().Id;
            driver.Navigate().GoToUrl(url + "/cabecera_produccion/edit/"+ultima_id);
            driver.FindElement(By.Id("editar-fecha")).Clear();
            driver.FindElement(By.Id("editar-fecha")).SendKeys("01-01-2012");
            driver.FindElement(By.Id("editar-fecha-guardar")).Click();
        }

        //[Test]
        //public void EliminarRecetaTest()
        //{
        //    //Acceder a contenedor Maestro: Receta
        //    driver.Navigate().GoToUrl(url + "/cabecera_receta");
        //    //Accede a eliminar Receta
        //    driver.FindElement(By.Id("eliminar-receta")).Click();
        //    driver.FindElement(By.Id("eliminar-receta")).Click();
        //}

        //[Test]
        //public void ListaCostoRecetaTest()
        //{
        //    //Acceder a contenedor Maestro: Receta
        //    driver.Navigate().GoToUrl(url + "/cabecera_receta");
        //    //Accede a eliminar Receta
        //    driver.FindElement(By.Id("costo-receta")).Click();
        //}

    }
}
