using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Linq;

namespace UITestProject
{

    [TestClass]
    public class FamiliaUITest
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();


       
        private void _Login()
        {
            //logearse
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("gvargas");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();
            }
        

        [Test]
        public void Agregar() {
            _Login();

            //Ir a index familia y agregar familia
            MVC_Panderia.Models.pan_dbEntities db = new MVC_Panderia.Models.pan_dbEntities();
           
            int FilasActuales = db.familia.Count();
            driver.Navigate().GoToUrl(url + "/familia");
            driver.FindElement(By.Id("btn-nuevo-index")).Click();
            driver.FindElement(By.Name("nombre")).SendKeys("Test");
            driver.FindElement(By.Name("lineaId")).Click();
            driver.FindElement(By.Name("lineaId")).SendKeys(Keys.Down);
            driver.FindElement(By.Id("lineaId")).SendKeys(Keys.Enter);
            driver.FindElement(By.Id("btn-guardar-create")).Click();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(FilasActuales + 1, db.familia.Count());
        }

        [Test]
        public void Editar() {

            driver.FindElement(By.Id("btn-editar-index")).Click();
            driver.FindElement(By.Name("nombre")).Clear();
            driver.FindElement(By.Name("nombre")).SendKeys("familiaTest");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("lineaId")).SendKeys(Keys.Down + Keys.Enter);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("lineaId")).SendKeys(Keys.Enter);
            driver.FindElement(By.Id("btn-guardar-editar")).Click();

            MVC_Panderia.Models.pan_dbEntities db = new MVC_Panderia.Models.pan_dbEntities();
            string nombre_familia = db.familia.ToList().OrderByDescending(s => s.Id).First().nombre;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(nombre_familia, "familiaTest");
        }

        [Test]
            public void Eliminar() {
            MVC_Panderia.Models.pan_dbEntities db = new MVC_Panderia.Models.pan_dbEntities();
            ////Obtiene el numero de recetas actuales
            int FilasActuales = db.familia.Count();
            driver.FindElement(By.Id("btn-delete-index")).Click();
            driver.FindElement(By.Id("btn-eliminar-delete")).Click();
            Thread.Sleep(1000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(FilasActuales - 1, db.familia.Count());
        }
            [Test]
            public void Listar() {

            driver.Navigate().GoToUrl(url + "/familia");

            Thread.Sleep(1000);
             }

        [Test]
        public void VerificarImg()
        {
            _Login();
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[2]/div/img"));
            String src_imagen = element.GetAttribute("src");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(url + "/Images/Logo.png", src_imagen);

            driver.Close();
            driver.Quit();
        }

        [Test]
            public void LogOut() {

            driver.Navigate().GoToUrl(url + "/usuario/logOut");
            }

        }
}
       






