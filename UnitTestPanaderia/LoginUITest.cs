using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestProject
{
    [TestClass]
    public class UITest
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();


        [Test]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");

            driver.FindElement(By.Name("Id")).SendKeys("rcaro");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");

            driver.FindElement(By.Id("login")).Click();


            //IWebElement element = driver.FindElement(By.XPath("/html/body/div[2]/header/div/a/img"));

            //String src_imagen = element.GetAttribute("src");

            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(url + "/Img/ardilla-meme-panadero.jpg", src_imagen);



            driver.Close();

            driver.Quit();
        }
    }
}
