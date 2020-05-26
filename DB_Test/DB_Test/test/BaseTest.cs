using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Test.test
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected MainPage mainPage;
        protected AllProductsPage allProductsPage;
        protected EditPage editPage;
        protected Results results;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            mainPage = new MainPage(driver, wait);
            results = new Results(driver);
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

    }
}
