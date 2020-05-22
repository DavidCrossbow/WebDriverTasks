using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DB_Test
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private MainPage mainPage;
        private AllProductsPage allProductsPage;
        private EditPage editPage;
        private Assertions assertions;
        

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            mainPage = new MainPage(driver, wait);
            assertions = new Assertions(driver);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/");
        }

        [OneTimeTearDown]
        protected void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

        [Test]
        public void Test1_LogIn()
        {
            Assert.That(assertions.ReturnHeader("Login"), Is.EqualTo("Login"));
            mainPage.LogIn(LogInData.Username, LogInData.Password);
            Assert.That(assertions.ReturnHeader("Home page"), Is.EqualTo("Home page"));
        }

        [Test]
        public void Test2_InsertNew()
        {
            allProductsPage = mainPage.AllProductsLink();
            Assert.That(assertions.ReturnHeader("All Products"), Is.EqualTo("All Products"));
            editPage = allProductsPage.ClickOn("Create new");
            Assert.That(assertions.ReturnHeader("Product editing"), Is.EqualTo("Product editing"));
            editPage.Select("ProductName", Data.ProductName);
            editPage.ToDropDown("CategoryId", Data.CategoryId);
            editPage.ToDropDown("SupplierId", Data.SupplierId);
            editPage.Select("UnitPrice", Data.UnitPriceToInput);
            editPage.Select("QuantityPerUnit", Data.QuantityPerUnit);
            editPage.Select("UnitsInStock", Data.UnitsInStock);
            editPage.Select("UnitsOnOrder", Data.UnitsOnOrder);
            editPage.Select("ReorderLevel", Data.ReorderLevel);
            editPage.DiscontinuedCheck();
            editPage.Submit();
            Assert.That(assertions.ReturnHeader("All Products"), Is.EqualTo("All Products"));
        }

        [Test]
        public void Test3_Open()
        {
            allProductsPage = mainPage.AllProductsLink();
            editPage = allProductsPage.ClickOn(Data.ProductName);
            Assert.That(assertions.Check("ProductName"), Is.EqualTo(Data.ProductName));
            Assert.That(assertions.CheckDropDown("CategoryId"), Is.EqualTo(Data.CategoryId));
            Assert.That(assertions.CheckDropDown("SupplierId"), Is.EqualTo(Data.SupplierId));
            Assert.That(assertions.Check("UnitPrice"), Is.EqualTo(Data.UnitPriceToRead));
            Assert.That(assertions.Check("QuantityPerUnit"), Is.EqualTo(Data.QuantityPerUnit));
            Assert.That(assertions.Check("UnitsInStock"), Is.EqualTo(Data.UnitsInStock));
            Assert.That(assertions.Check("UnitsOnOrder"), Is.EqualTo(Data.UnitsOnOrder));
            Assert.That(assertions.Check("ReorderLevel"), Is.EqualTo(Data.ReorderLevel));
            Assert.That(assertions.Check("Discontinued"), Is.EqualTo(Data.Discontinued));
        }

        [Test]
        public void Test4_Delete()
        {
            allProductsPage = mainPage.AllProductsLink();
            allProductsPage.RemoveProduct(Data.ProductName);
            Assert.True(assertions.IsNotExist(Data.ProductName) == 0);
        }

        [Test]
        public void Test5_LogOut()
        {
            mainPage.LogOutLink();
            Assert.That(assertions.ReturnHeader("Login"), Is.EqualTo("Login"));
        }

        
    }
}

