using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestProject
{
    [TestClass]
    public class PrecioUITest   
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void LoginPrecio()   
        {
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("furibe");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();
        }

        [Test]
        public void CostoCrearTest()
        {
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            driver.FindElement(By.Id("costo-receta")).Click();
            driver.FindElement(By.Id("nuevo-costo")).Click();
            driver.FindElement(By.Id("nueva-fecha")).SendKeys("14-06-2018");
            driver.FindElement(By.Id("nuevo-costo")).SendKeys("1350");
            driver.FindElement(By.Id("guardar-costo")).Click();
        }

        [Test]
        public void CostoEditarTest()
        {
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            driver.FindElement(By.Id("editar-costo")).Click();
            driver.FindElement(By.Id("nuevo-valor")).Clear();
            driver.FindElement(By.Id("nuevo-valor")).SendKeys("1800");
            driver.FindElement(By.Id("guardar-costo")).Click();
        }

        [Test]
        public void CostoEliminarTest()
        {
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            driver.FindElement(By.Id("costo-receta")).Click();
            driver.FindElement(By.Id("eliminar-costo")).Click();
        }
    }
}

