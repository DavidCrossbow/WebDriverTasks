using DB_Test.business_object;
using DB_Test.service.iu;
using DB_Test.test;
using Newtonsoft.Json;
using NUnit.Framework;
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
            Assert.That(mainPage.ReturnHeader("Login"), Is.EqualTo("Login"));
            mainPage.LogIn(login.Username, login.Password);
            Assert.That(mainPage.ReturnHeader("Home page"), Is.EqualTo("Home page"));
        }

        [Test]
        public void Test2_InsertNew()
        {
            allProductsPage = Service.CreateNew(product, driver, wait);
            Assert.That(allProductsPage.ReturnHeader("All Products"), Is.EqualTo("All Products"));
        }

        [Test]
        public void Test3_Open()
        {
            editPage = Service.EditPage(product, driver, wait);
            Assert.That(editPage.Check("ProductName"), Is.EqualTo(product.ProductName));
            Assert.That(editPage.CheckDropDown("CategoryId"), Is.EqualTo(product.CategoryId));
            Assert.That(editPage.CheckDropDown("SupplierId"), Is.EqualTo(product.SupplierId));
            Assert.That(editPage.Check("UnitPrice"), Is.EqualTo(product.UnitPriceToRead));
            Assert.That(editPage.Check("QuantityPerUnit"), Is.EqualTo(product.QuantityPerUnit));
            Assert.That(editPage.Check("UnitsInStock"), Is.EqualTo(product.UnitsInStock));
            Assert.That(editPage.Check("UnitsOnOrder"), Is.EqualTo(product.UnitsOnOrder));
            Assert.That(editPage.Check("ReorderLevel"), Is.EqualTo(product.ReorderLevel));
            Assert.That(editPage.Check("Discontinued"), Is.EqualTo(product.Discontinued));
        }

        [Test]
        public void Test4_Delete()
        {
            allProductsPage = Service.DeletePage(product, driver, wait);
            Assert.True(allProductsPage.IsNotExist(product.ProductName) == 0);
        }

        [Test]
        public void Test5_LogOut()
        {
            mainPage.LogOutLink();
            Assert.That(mainPage.ReturnHeader("Login"), Is.EqualTo("Login"));
        }
    }
}

