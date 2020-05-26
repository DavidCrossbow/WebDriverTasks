using DB_Test.business_object;
using DB_Test.service.iu;
using DB_Test.test;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace DB_Test
{
    public class Tests : BaseTest
    {
        private LogIn login = JsonConvert.DeserializeObject<LogIn>(File.ReadAllText("LogIn.json"));
        private Product product = JsonConvert.DeserializeObject<Product>(File.ReadAllText("Product.json"));

        [Test]
        public void Test1_LogIn()
        {
            Assert.That(results.ReturnHeader("Login"), Is.EqualTo("Login"));
            mainPage.LogIn(login.Username, login.Password);
            Assert.That(results.ReturnHeader("Home page"), Is.EqualTo("Home page"));
        }

        [Test]
        public void Test2_InsertNew()
        {
            allProductsPage = Service.CreateN(product, driver, wait);
            Assert.That(results.ReturnHeader("All Products"), Is.EqualTo("All Products"));
        }

        [Test]
        public void Test3_Open()
        {
            editPage = Service.EditP(product, driver, wait);
            Assert.That(results.Check("ProductName"), Is.EqualTo(product.ProductName));
            Assert.That(results.CheckDropDown("CategoryId"), Is.EqualTo(product.CategoryId));
            Assert.That(results.CheckDropDown("SupplierId"), Is.EqualTo(product.SupplierId));
            Assert.That(results.Check("UnitPrice"), Is.EqualTo(product.UnitPriceToRead));
            Assert.That(results.Check("QuantityPerUnit"), Is.EqualTo(product.QuantityPerUnit));
            Assert.That(results.Check("UnitsInStock"), Is.EqualTo(product.UnitsInStock));
            Assert.That(results.Check("UnitsOnOrder"), Is.EqualTo(product.UnitsOnOrder));
            Assert.That(results.Check("ReorderLevel"), Is.EqualTo(product.ReorderLevel));
            Assert.That(results.Check("Discontinued"), Is.EqualTo(product.Discontinued));
        }

        [Test]
        public void Test4_Delete()
        {
            allProductsPage = Service.DeleteP(product, driver, wait);
            Assert.True(results.IsNotExist(product.ProductName) == 0);
        }

        [Test]
        public void Test5_LogOut()
        {
            mainPage.LogOutLink();
            Assert.That(results.ReturnHeader("Login"), Is.EqualTo("Login"));
        }
    }
}

