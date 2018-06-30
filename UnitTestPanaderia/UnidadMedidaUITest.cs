﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void nuevaUnidadMedida()  
        {
            //LoginUnidad();
            driver.Navigate().GoToUrl(url + "/unidad_medida");

            //GUARDAR UNIDAD DE MEDIDA
            driver.FindElement(By.Id("botonNuevo")).Click();
            driver.FindElement(By.Id("nombreNuevo")).SendKeys("PRUEBA AGREGAR");
            driver.FindElement(By.Id("guardaNuevo")).Click();
            
                       
        }

        [Test]
        public void editarUnidadMedida()
        {
           // LoginUnidad();
            driver.Navigate().GoToUrl(url + "/unidad_medida");

            //EDITAR UNIDAD DE MEDIDA
            driver.FindElement(By.Id("botonEditar")).Click();
            driver.FindElement(By.Id("nombre")).SendKeys("PRUEBA EDITAR2");
            driver.FindElement(By.Id("botonGuardar")).Click();

          
        }

        [Test]
        public void eliminaUnidadMedida()   
        {
            _LoginUnidad();
            driver.Navigate().GoToUrl(url + "/unidad_medida");

            //BORRAR UNIDAD DE MEDIDA
            driver.FindElement(By.Id("botonEliminar")).Click();

            //CONFIRMAR ELIMINAR
            driver.Navigate().GoToUrl(url + "/unidad_medida/Delete/108");
            driver.FindElement(By.Id("botonEliminar")).Click();
            driver.Navigate().GoToUrl(url + "/unidad_medida");

        }
    }
}
