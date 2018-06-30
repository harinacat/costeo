using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
namespace UITestProject
{
    [TestClass]
    public class PrecioUITest   
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void _LoginPrecio()   
        {
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("furibe");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();

        }

        [Test]
        public void CrearPrecioTest()       
        {
            //LoginPrecio();
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            driver.FindElement(By.Id("precio-receta")).Click();
            driver.FindElement(By.Id("nuevo-precio")).Click();
            driver.FindElement(By.Id("fecha")).SendKeys("29-06-2018");
            driver.FindElement(By.Id("fecha")).SendKeys(Keys.Return);
            Thread.Sleep(1500);
            //driver.FindElement(By.Id("valor")).Click();
            driver.FindElement(By.Id("valor")).SendKeys("350");
            //driver.FindElement(By.Id("valor")).Click();
           // Thread.Sleep(1500);
            driver.FindElement(By.Id("botonGuardar")).Click();
            
           

        }

        [Test]
        public void EditarPrecioTest() 
        {
            //LoginPrecio();
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("precio-receta")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("editar-precio")).Click();
            driver.FindElement(By.Id("nuevo-valor")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("nuevo-valor")).SendKeys("999");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("botonGuardar")).Click();
            Thread.Sleep(2000);
        }

        [Test]
        public void EliminarPrecioTest()    
        {
            //LoginPrecio();
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            driver.FindElement(By.Id("precio-receta")).Click();
            driver.FindElement(By.Id("eliminar-precio")).Click();
            driver.FindElement(By.Id("boton-eliminar")).Click();
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
        }
        [Test]
        public void ListarPrecioTest()  
        {
            //LoginPrecio();
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            driver.Close();
            driver.Quit();
        }
    }
}

