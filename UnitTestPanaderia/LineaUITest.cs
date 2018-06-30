using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UITestProject
{

    [TestClass]
    public class LineaUITest
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();


        
        private void _LogearseTest()
        {
            //logearse
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("fantipa");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("login")).Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void CrearTest()
        {
            _LogearseTest();
            //Ir a index Linea y agregar Linea
            driver.Navigate().GoToUrl(url + "/linea");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btn-crear-index")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("nombre")).SendKeys("Tortas mil hojas");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btn-guardar-linea")).Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void ModificarTest()
        {
            //Editar primer registro 
            driver.FindElement(By.Id("btn-editar-index")).Click();
            driver.FindElement(By.Name("nombre")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("nombre")).SendKeys("Tortas de Frambuesa");
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btn-guardar-linea")).Click();
            Thread.Sleep(1000);
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void EliminarTest()
        {
            //Eliminar Registro
            driver.FindElement(By.Id("btn-eliminar-index")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btn-eliminar-linea")).Click();
            Thread.Sleep(1000);
        }

    }


}