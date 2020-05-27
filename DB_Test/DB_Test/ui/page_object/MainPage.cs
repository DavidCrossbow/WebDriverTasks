using DB_Test.business_object;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace DB_Test
{
    class MainPage
    {
        private IWebDriver driver;
        
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement NameField => driver.FindElement(By.Id("Name"));
        private IWebElement PasswordField => driver.FindElement(By.Id("Password"));
 
        public MainPage AutorizationData (LogIn login)
        {
            new Actions(driver).Click(NameField).SendKeys(login.Username).Build().Perform();
            new Actions(driver).Click(PasswordField).SendKeys(login.Password).Build().Perform();
            return this;
        }

        public MainPage AutorizationSend()
        {
            new Actions(driver).SendKeys(Keys.Enter).Build().Perform();
            return this;
        }

        public AllProductsPage ClickOn(string value)
        {
            driver.FindElement(By.LinkText($"{value}")).Click();
            return new AllProductsPage(driver);
        }
    }
}
