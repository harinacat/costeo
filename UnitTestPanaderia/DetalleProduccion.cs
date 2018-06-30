using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;




namespace UITestProject
{
    [TestClass]
    public class DetalleProduccionUITest
    {
        
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
        public void CrearDetalleProduccionTest()
        {
            _Login();
            driver.Navigate().GoToUrl(url + "/cabecera_produccion");
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/table/tbody/tr[1]/td[3]/a[3]")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[1]/div[2]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/input")).SendKeys("123");
            driver.FindElement(By.Id("cabecera_recetaId")).Click();
            driver.FindElement(By.Id("cabecera_recetaId")).SendKeys(Keys.Down);
            driver.FindElement(By.Id("cabecera_recetaId")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("/html/body/div[2]/form/button")).Click();


        }


        [Test]
        public void EditarDetalleProduccionTest()
        {
            
            driver.Navigate().GoToUrl(url + "/cabecera_produccion");
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/table/tbody/tr[1]/td[3]/a[3]")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/table/tbody/tr[2]/td[7]/a[1]")).Click();
            driver.FindElement(By.Id("kilos")).Clear();
            driver.FindElement(By.Id("kilos")).SendKeys("56789");
            driver.FindElement(By.Id("cabecera_recetaId")).Click();
            driver.FindElement(By.Id("cabecera_recetaId")).SendKeys(Keys.Up);
            driver.FindElement(By.Id("cabecera_recetaId")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
        }

        [Test]
        public void EliminarDetalleProduccionTest()
        {
           
            driver.Navigate().GoToUrl(url + "/cabecera_produccion");
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/table/tbody/tr[1]/td[3]/a[3]")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/table/tbody/tr[2]/td[7]/a[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
        }

        [Test]
        public void ListarDetalleProduccionTest()
        {
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.Navigate().GoToUrl(url + "/cabecera_produccion");
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/table/tbody/tr[1]/td[3]/a[3]")).Click();
            driver.Navigate().GoToUrl(url + "/cabecera_produccion");
        }


    }
}
