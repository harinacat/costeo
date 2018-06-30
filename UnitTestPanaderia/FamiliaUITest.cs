using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UITestProject
{

    [TestClass]
    public class FamiliaUITest
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();


        [Test]
        public void Login()
        {

            //logearse
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("gvargas");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();
        }

        [Test]
        public void Agregar() {
            //Ir a index familia y agregar familia
            driver.Navigate().GoToUrl(url + "/familia");
            driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[2]/a")).Click();
            driver.FindElement(By.Name("nombre")).SendKeys("Test");
            driver.FindElement(By.Name("lineaId")).Click();
            driver.FindElement(By.Name("lineaId")).SendKeys(Keys.Down);
            driver.FindElement(By.Id("lineaId")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
        }


        [Test]
        public void Editar() {
            //Editar primer registro 
            //IWebElement baseTable1 = driver.FindElement(By.TagName("table"));
            //IWebElement tableRow1 = baseTable1.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[8]"));
            //tableRow1.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[8]/td[4]/a[1]")).Click();

            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[1]/td[4]/a[1]")).Click();
            driver.FindElement(By.Name("nombre")).Clear();
            driver.FindElement(By.Name("nombre")).SendKeys("familiaTest");
            driver.FindElement(By.Id("lineaId")).SendKeys(Keys.Down + Keys.Enter);
            driver.FindElement(By.Id("lineaId")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
        }
            [Test]
            public void Eliminar() {
            //Eliminar registro N°8 agregado
            //IWebElement baseTable = driver.FindElement(By.TagName("table"));
            //IWebElement tableRow = baseTable.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[8]"));
            //tableRow.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[8]/td[4]/a[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[1]/td[4]/a[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
             
        }

    }
       
        
    }

