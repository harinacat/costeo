using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestProject
{
    [TestClass]
    public class LineaUITest
    {
        string url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();
        //private IWebElement input;

        [TestMethod]
        public void Login()
        {
            //Accede a Panaderia a traves del Login
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("Id")).SendKeys("fantipa");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();
        }
        
        [TestMethod]
        public void crearLineaTest()
        {
            //Accede al contenedor Linea
            driver.Navigate().GoToUrl(url + "/linea");
            // Accede a crear Nueva Linea
            IWebElement btnsearch = driver.FindElement(By.Id("btn btn-primary float-right"));
            btnsearch.Click();
            IWebElement input = driver.FindElement(By.Id("form-control"));
            input.SendKeys("Tortas de Naraja");
            //Guarda la Linea
            IWebElement btnguardar = driver.FindElement(By.Id("btn btn-success"));
            btnguardar.Click();
        }

        [TestMethod]
        public void EditarLineaTest()
        {

        }

        [TestMethod]
        public void EliminarLineaTest()
        {

        }

        [TestMethod]
        public void DesloginLineaTest()
        {

        }
        
    }
}
