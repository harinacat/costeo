using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestProject
{
    [TestClass]
    public class ArticuloEliminarUITest
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();


        [Test]
        public void EliminarArticuloTest()
        {
            //Acceder a Panaderia Cat a Través de Login
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("jlagos");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();

            //Acceder a contenedor Maestro: Articulo
            driver.Navigate().GoToUrl(url + "/articulo");
            driver.FindElement(By.Id("boton-eliminar")).Click();
            driver.FindElement(By.Id("boton-eliminar2")).Click();


        }
    }
}

