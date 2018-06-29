using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestProject
{
    [TestClass]
    public class ArticuloUITest
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("jlagos");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();
        }

        [Test]
        public void ArticuloCrearTest()
        {
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

        [Test]
        public void ArticuloEditarTest()
        {
            //Acceder a contenedor Maestro: Articulo
            driver.Navigate().GoToUrl(url + "/articulo");
            //Accede a Editar Articulo
            driver.FindElement(By.Id("editar-articulo")).Click();
            driver.FindElement(By.Id("editar-nombre")).Clear();
            driver.FindElement(By.Id("editar-nombre")).SendKeys("PRUEBA EDICION ARTICULO");
            driver.FindElement(By.Id("editar-familia")).Click();
            driver.FindElement(By.Id("editar-familia")).SendKeys("Donuts");
            driver.FindElement(By.Id("editar-medida")).Click();
            driver.FindElement(By.Id("editar-medida")).SendKeys("Grs");
            driver.FindElement(By.Id("editar-barra")).Clear();
            driver.FindElement(By.Id("editar-barra")).SendKeys("PRUEBA-CODIGO-BARRAS");
            driver.FindElement(By.Id("editar-marca")).Clear();
            driver.FindElement(By.Id("editar-marca")).SendKeys("PRUEBA HARINA CAT");
            driver.FindElement(By.Id("editar-formato")).Clear();
            driver.FindElement(By.Id("editar-formato")).SendKeys("PRUEBA SACO UNITARIO");
            driver.FindElement(By.Id("guardar-editar")).Click();
        }

        [Test]
        public void ArticuloEliminarTest()
        {
            //Acceder a contenedor Maestro: Articulo
            driver.Navigate().GoToUrl(url + "/articulo");
            driver.FindElement(By.Id("boton-eliminar")).Click();
            driver.FindElement(By.Id("boton-eliminar2")).Click();
        }
    }
}

