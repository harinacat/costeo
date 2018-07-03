using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;

namespace UITestProject
{
    [TestClass]
    public class PrecioUITest   
    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void _LoginPrecio()   
        {
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("furibe");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();

        }

        [Test]
        public void CrearPrecioTest()       
        {
            //_LoginPrecio();
            MVC_Panderia.Models.pan_dbEntities db = new MVC_Panderia.Models.pan_dbEntities();
            ////Obtiene el numero de precios actuales
            int FilasActuales = db.precio_venta.Count();

            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            driver.FindElement(By.Id("precio-receta")).Click();
            driver.FindElement(By.Id("nuevo-precio")).Click();
            driver.FindElement(By.Id("fecha")).SendKeys("29-06-2018");
            driver.FindElement(By.Id("fecha")).SendKeys(Keys.Return);
            Thread.Sleep(1500);
            //driver.FindElement(By.Id("valor")).Click();
            driver.FindElement(By.Id("valor")).SendKeys("350");
            //driver.FindElement(By.Id("valor")).Click();
           // Thread.Sleep(1500);
            driver.FindElement(By.Id("botonGuardar")).Click();

            ////Valida que se haya insertado el precio
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(FilasActuales + 1, db.precio_venta.Count());


        }

        [Test]
        public void EditarPrecioTest() 
        {
            //_LoginPrecio();
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("precio-receta")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("editar-precio")).Click();
            driver.FindElement(By.Id("nuevo-valor")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("nuevo-valor")).SendKeys("999");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("botonGuardar")).Click();
            Thread.Sleep(2000);

            MVC_Panderia.Models.pan_dbEntities db = new MVC_Panderia.Models.pan_dbEntities();
            string valor = Convert.ToString(db.precio_venta.ToList().OrderByDescending(s => s.cabecera_recetaId).First().valor);
          
            ////Valida que el articulo modificado,
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(valor, "999");
        }

        [Test]
        public void EliminarPrecioTest()    
        {
            _LoginPrecio();
            MVC_Panderia.Models.pan_dbEntities db = new MVC_Panderia.Models.pan_dbEntities();
            ////Obtiene el numero de  actuales
            int FilasActuales = db.precio_venta.Count();

            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            driver.FindElement(By.Id("precio-receta")).Click();
            driver.FindElement(By.Id("eliminar-precio")).Click();
            driver.FindElement(By.Id("boton-eliminar")).Click();
            //driver.Navigate().GoToUrl(url + "/cabecera_receta");
            ////Valida que se haya eliminado 
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(FilasActuales - 1, db.precio_venta.Count());

        }
        [Test]
        public void ListarPrecioTest()  
        {
            //_LoginPrecio();
            driver.Navigate().GoToUrl(url + "/cabecera_receta");
            driver.Close();
            driver.Quit();
        }
    }
}

