using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DB_Test.test
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected MainPage mainPage;
        protected AllProductsPage allProductsPage;
        protected EditPage editPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            mainPage = new MainPage(driver, wait);
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
