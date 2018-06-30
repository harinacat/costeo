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
        public void LineaMultiTest()
        {

            //logearse
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("fantipa");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("login")).Click();
            Thread.Sleep(1000);
            
            //Ir a index Linea y agregar Linea
            driver.Navigate().GoToUrl(url + "/linea");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[2]/a")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("nombre")).SendKeys("PAN CON QUESITO");
            Thread.Sleep(1000);
            /*driver.FindElement(By.Name("lineaId")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("lineaId")).SendKeys(Keys.Down);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("lineaId")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);*/
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
            Thread.Sleep(1000);

            //Editar primer registro 
            //IWebElement baseTable1 = driver.FindElement(By.TagName("table"));
            //IWebElement tableRow1 = baseTable1.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[8]"));
            //tableRow1.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[8]/td[4]/a[1]")).Click();
            //Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[6]/td[3]/a[1]")).Click();
            driver.FindElement(By.Name("nombre")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("nombre")).SendKeys("PAN CON CHANCO");
            Thread.Sleep(1000);
            //driver.FindElement(By.Id("lineaId")).SendKeys(Keys.Down + Keys.Enter);
            //Thread.Sleep(1000);
            //driver.FindElement(By.Id("lineaId")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
            Thread.Sleep(1000);


            
            //Eliminar registro N°8 agregado
            //IWebElement baseTable = driver.FindElement(By.TagName("table"));
            //IWebElement tableRow = baseTable.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[8]"));
            //tableRow.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[8]/td[4]/a[2]")).Click();
            //Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/table/tbody/tr[7]/td[3]/a[2]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/form/button[1]")).Click();
            Thread.Sleep(1000);

        }

    }


}