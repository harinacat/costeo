using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;




namespace UITestProject
{
    [TestClass]
    public class CabeceraProduccionUITest
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
        public void CrearCabeceraProduccionTest()
        {
            _Login();
            driver.Navigate().GoToUrl(url + "/cabecera_produccion");
            driver.FindElement(By.Id("nueva-produccion")).Click();
            driver.FindElement(By.Id("input-fecha")).SendKeys("01-01-2010");
            driver.FindElement(By.Id("fecha-guardar")).Click();


        }


        [Test]
        public void EditarCabeceraProduccionTest()
        {
            _Login();
            driver.Navigate().GoToUrl(url + "/cabecera_produccion");
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/table/tbody/tr[1]/td[3]/a[1]")).Click();
            driver.FindElement(By.Id("editar-fecha")).Clear();
            driver.FindElement(By.Id("editar-fecha")).SendKeys("01-01-2018");
            driver.FindElement(By.Id("editar-fecha-guardar")).Click();
        }

        [Test]
        public void EliminarCabeceraProduccionTest()
        {
            _Login();
            driver.Navigate().GoToUrl(url + "/cabecera_produccion");
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[2]/div/table/tbody/tr[1]/td[3]/a[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
        }

        [Test]
        public void ImagenIndex()
        {
            _Login();
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[2]/div/img"));
            string src_imagen = element.GetAttribute("src");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(url + "/Images/Logo.png", src_imagen);
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.Close();
            driver.Quit();
        }

    }
}