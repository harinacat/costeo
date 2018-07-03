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
    public class UnidadMedidaUITest    

    {
        String url = "http://localhost:58102";
        IWebDriver driver = new ChromeDriver();
        
        [Test]
        public void _LoginUnidad()

        {
            driver.Navigate().GoToUrl(url + "/usuario/Login?ReturnUrl=%2f");
            driver.FindElement(By.Name("Id")).SendKeys("furibe");
            driver.FindElement(By.Name("contrasena")).SendKeys("test");
            driver.FindElement(By.Id("login")).Click();
        }

        [Test]
        public void CrearUnidadMedida()   
        {
            _LoginUnidad();

            driver.Navigate().GoToUrl(url + "/unidad_medida");
            MVC_Panderia.Models.pan_dbEntities db = new MVC_Panderia.Models.pan_dbEntities();
            ////Obtiene el numero de recetas actuales
            int FilasActuales = db.unidad_medida.Count();

            //GUARDAR UNIDAD DE MEDIDA
            driver.FindElement(By.Id("botonNuevo")).Click();
            driver.FindElement(By.Id("nombreNuevo")).SendKeys("PRUEBA AGREGAR");
            driver.FindElement(By.Id("guardaNuevo")).Click();

            ////Valida que se haya insertado la receta
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(FilasActuales + 1, db.unidad_medida.Count());


        }

        [Test]
        public void EditarUnidadMedida()    
        {
           // LoginUnidad();
            driver.Navigate().GoToUrl(url + "/unidad_medida");

            //EDITAR UNIDAD DE MEDIDA
            driver.FindElement(By.Id("botonEditar")).Click();
            driver.FindElement(By.Id("nombre")).SendKeys("PRUEBA EDITAR2");
            driver.FindElement(By.Id("botonGuardar")).Click();

          
        }

        [Test]
        public void EliminaUnidadMedida()      
        {
            //_LoginUnidad();
            driver.Navigate().GoToUrl(url + "/unidad_medida");

            //BORRAR UNIDAD DE MEDIDA
            driver.FindElement(By.Id("botonEliminar")).Click();

            //CONFIRMAR ELIMINAR
            driver.Navigate().GoToUrl(url + "/unidad_medida");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("botonEliminar")).Click();
            Thread.Sleep(1000);
            // driver.Navigate().GoToUrl(url + "/unidad_medida");

            driver.Close();
            driver.Quit();
        }
    }
}
