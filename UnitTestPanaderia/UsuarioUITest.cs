using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UITestProject
{

    [TestClass]
    public class UsuarioUITest
    {
        private const string XpathToFind = "/html/body/div[2]/form/button[1]";
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();


        [Test]
        public void _UsuarioLogear()
        {
            //logearse
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("gbarrientos");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("login")).Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void UsuarioCrear()

        {

            //Ir a index usuario y agregar nuevo usuario
            driver.Navigate().GoToUrl(url + "/usuario");
        Thread.Sleep(1000);
            driver.FindElement(By.Id("btnGuardar")).Click();
        Thread.Sleep(1000);
            driver.FindElement(By.Name("Id")).SendKeys("alopezi");
        Thread.Sleep(1000);
            driver.FindElement(By.Name("nombre_usuario")).SendKeys("Andres Lopezi");
        Thread.Sleep(1000);
            driver.FindElement(By.Name("email")).SendKeys("alopez@gmail.com");
        Thread.Sleep(1000);
            driver.FindElement(By.Name("rolId")).SendKeys(Keys.Null);
        Thread.Sleep(1000);
            //Establecer contraseña
            driver.FindElement(By.Id("btnEstablecerContrasena")).Click();
        Thread.Sleep(1000);
            driver.FindElement(By.Id("txt_password_nueva")).SendKeys("1234");
        Thread.Sleep(1000);
            driver.FindElement(By.Id("txt_password_confirmar")).SendKeys("1234");
        Thread.Sleep(1000);
            //Establecer
            driver.FindElement(By.Id("btnEstablece")).Click();
        Thread.Sleep(1000);
            
        }

        [Test]
        public void UsuarioEditar()
        {
            //Editar primer registro

            driver.FindElement(By.Id("btn-Editar-index")).Click();
            Thread.Sleep(1000);
            //driver.FindElement(By.Name("Id")).SendKeys("alopezi");
            //Thread.Sleep(1000);
            driver.FindElement(By.Name("nombre_usuario")).SendKeys("Andres Lopeziti");
            Thread.Sleep(1000);
            //driver.FindElement(By.Name("email")).SendKeys("alopezi@gmail.com");
            //Thread.Sleep(1000);
            //driver.FindElement(By.Name("rolId")).SendKeys(Keys.Down + Keys.Enter);
            //Thread.Sleep(1000);
            driver.FindElement(By.Id("btnGuardar")).Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void UsuarioEliminar()

        {

            //        //Eliminar registro N°8 agregado
            driver.FindElement(By.Id("btnEliminar-index")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnEliminar-index")).Click();
            Thread.Sleep(1000);
            ////driver.FindElement(By.Name("Id")).SendKeys("alopezzi");
            ////Thread.Sleep(1000);
            //driver.FindElement(By.Name("nombre_usuario")).SendKeys("Andrez Lopezite");
            //Thread.Sleep(1000);
            //driver.FindElement(By.Name("email")).SendKeys("alopezi@gmail.com");
            //Thread.Sleep(1000);
            //driver.FindElement(By.Id("btnEliminar")).Click();
            //Thread.Sleep(1000);
        }
    }

    


}