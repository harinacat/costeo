//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UITestProject
//{
//    [TestClass]
//    public class UITest
//    {
//        String url = "http://localhost:58102";
//        IWebDriver driver = new ChromeDriver();



//        [Test]
//        public void LoginTest()
//        {
//            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");

//            driver.FindElement(By.Name("Id")).SendKeys("rcaro");
//            driver.FindElement(By.Name("contrasena")).SendKeys("test");

//            driver.FindElement(By.Id("login")).Click();




//        }
        
//    }
//}
