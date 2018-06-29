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
        public void FamiliaMultiTest()
        {
            
            //logearse
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("gvargas");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("login")).Click();
            Thread.Sleep(2000);

            //Ir a index familia y agregar familia
            driver.Navigate().GoToUrl(url + "/familia");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("btn-nuevo")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("txt_nombre")).SendKeys("test");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("ddl_linea")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("ddl_linea")).SendKeys(Keys.Down );
            Thread.Sleep(2000);
            driver.FindElement(By.Id("ddl_linea")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("btn-guardar")).Click();
            Thread.Sleep(2000);

            //Editar primer registro 
            IWebElement baseTable1 = driver.FindElement(By.TagName("table"));
            IWebElement tableRow1 = baseTable1.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[8]"));
            tableRow1.FindElement(By.Id("btn-editar")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("txt_nombre_editar")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("txt_nombre_editar")).SendKeys("familiaTest");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("ddl_linea_editar")).SendKeys(Keys.Down + Keys.Enter);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("ddl_linea_editar")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            driver.FindElement(By.Id("btn_guardar_edicion")).Click();
            Thread.Sleep(2000);

            
            
            //Eliminar registro N°8 agregado
            IWebElement baseTable = driver.FindElement(By.TagName("table"));
            IWebElement tableRow = baseTable.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[8]"));
            tableRow.FindElement(By.Id("btn-eliminar")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("btn-eliminar2")).Click();
            Thread.Sleep(2000);


        }

    }
       
        
    }

