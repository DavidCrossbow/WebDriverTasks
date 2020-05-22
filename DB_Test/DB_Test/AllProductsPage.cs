using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DB_Test
{
    class AllProductsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        
        public AllProductsPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        // Используется динамический локатор. Элементы ("ProductName", Create "New"), которые "кликаются" 
        // этим методом открывают EditPage
        public EditPage ClickOn (string value)
        {
            driver.FindElement(By.LinkText($"{value}")).Click();
            return new EditPage(driver);
        }
        public void RemoveProduct(string productName)
        {
            driver.FindElement(By.XPath($"//tr/td/a[text()=\"{productName}\"]//following::td//a[text()=\"Remove\"]")).Click();
            driver.SwitchTo().Alert().Accept();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath($"//tr/td/a[text()=\"{productName}\"]")));
        }
    }
}
