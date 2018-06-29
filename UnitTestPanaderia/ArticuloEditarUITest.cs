using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestProject
{
    [TestClass]
    public class ArticuloEditarUITest
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();


        [Test]
        public void EditarArticuloTest()
        {
            //Acceder a Panaderia Cat a Través de Login
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("jlagos");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();

            //Acceder a contenedor Maestro: Articulo
            driver.Navigate().GoToUrl(url + "/articulo");
            //Accede a Editar Articulo
            driver.FindElement(By.Id("editar-articulo")).Click();
            driver.FindElement(By.Id("editar-nombre")).SendKeys("PRUEBA EDICION ARTICULO");
            driver.FindElement(By.Id("editar-familia")).Click();
            driver.FindElement(By.Id("editar-familia")).SendKeys("Donuts");
            driver.FindElement(By.Id("editar-medida")).Click();
            driver.FindElement(By.Id("editar-medida")).SendKeys("Grs");
            driver.FindElement(By.Id("editar-barra")).SendKeys("PRUEBA-CODIGO-BARRAS");
            driver.FindElement(By.Id("editar-marca")).SendKeys("PRUEBA HARINA CAT");
            driver.FindElement(By.Id("editar-formato")).SendKeys("PRUEBA SACO UNITARIO");
            driver.FindElement(By.Id("guardar-editar")).Click();
        }
    }
}

