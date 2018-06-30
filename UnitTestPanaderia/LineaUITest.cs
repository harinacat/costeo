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


        [Test]
        public void LogearseTest()
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
            //Ir a index Linea y agregar Linea
            driver.Navigate().GoToUrl(url + "/linea");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[2]/a")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("nombre")).SendKeys("PAN CON QUESITO");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void ModificarTest()
        {
            //Editar primer registro 
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[6]/td[3]/a[1]")).Click();
            driver.FindElement(By.Name("nombre")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("nombre")).SendKeys("PAN CON CHANCO");
            Thread.Sleep(1000);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void EliminarTest()
        {
            //Eliminar Registro
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[7]/td[3]/a[2]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
            Thread.Sleep(1000);
        }

    }


}