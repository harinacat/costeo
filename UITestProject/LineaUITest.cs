using System;
using System.Threading.Tasks;
using System.Linq;
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
        public void _Login()
        {
            //Accede a Panaderia a traves del Login
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("fantipa");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("boton")).Click();
            /*
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("Id")).SendKeys("fantipa");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();
            */
        }
        
        [TestMethod]
        public void crearLineaTest()
        {
            //Accede al contenedor Linea
            driver.Navigate().GoToUrl(url + "/linea");
            // Accede a crear Nueva Linea
            driver.Navigate().GoToUrl(url + "/linea/Create?Length=5");
            IWebElement input = driver.FindElement(By.Id("form-control"));
            input.SendKeys("Tortas de Naraja");
            //Guarda la Linea
            IWebElement btnguardar = driver.FindElement(By.Id("btn btn-success"));
            btnguardar.Click();
        }

        [TestMethod]
        public void EditarLineaTest()
        {
            //Accede al contenedor Linea
            driver.Navigate().GoToUrl(url + "/linea");
            // Accede a Modificar Linea
            driver.Navigate().GoToUrl(url + "/linea/Edit/189");
            IWebElement input = driver.FindElement(By.Id("form-control text-box single-line"));
            input.SendKeys("Tortas de Avellana");
            //Guarda Modificación de la Linea
            IWebElement btnguardaredit = driver.FindElement(By.Id("btn btn-success pl-2"));
            btnguardaredit.Click();

        }

        [TestMethod]
        public void EliminarLineaTest()
        {
            //Accede al contenedor Linea
            driver.Navigate().GoToUrl(url + "/linea");
            driver.Navigate().GoToUrl(url + "/linea/Delete/40");
            // Accede a Eliminar Linea
            IWebElement btndelete = driver.FindElement(By.Id("btn btn-danger  pl-2"));
            btndelete.Click();

        }

        [TestMethod]
        public void DesloginLineaTest()
        {
            IWebElement btndeslogin = driver.FindElement(By.Id("navbarDropdownMenuLink"));
            btndeslogin.Click();
            driver.Navigate().GoToUrl(url + "/usuario/logOut");

        }
        
    }
}
