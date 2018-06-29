using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestProject
{
    [TestClass]
    public class ArticuloCrearUITest
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();


        [Test]
        public void CrearArticuloTest()
        {
            //Acceder a Panaderia Cat a Través de Login
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("jlagos");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();

            //Acceder a contenedor Maestro: Articulo
            driver.Navigate().GoToUrl(url + "/articulo");
            //Accede a Crear nuevo Articulo
            driver.FindElement(By.Id("nuevo-articulo")).Click();
            driver.FindElement(By.Id("nombre-articulo")).SendKeys("PRUEBA NUEVO ARTICULO");
            driver.FindElement(By.Id("familia-tipo")).Click();
            driver.FindElement(By.Id("familia-tipo")).SendKeys("Queques");
            driver.FindElement(By.Id("unidad-medida")).Click();
            driver.FindElement(By.Id("unidad-medida")).SendKeys("Grs");
            driver.FindElement(By.Id("codigo_barra")).SendKeys("PRUEBA-CODIGO-BARRAS");
            driver.FindElement(By.Id("marca_articulo")).SendKeys("PRUEBA HARINA CAT");
            driver.FindElement(By.Id("formato_articulo")).SendKeys("PRUEBA SACO UNITARIO");
            driver.FindElement(By.Id("guardar-articulo")).Click();
        }
    }
}

