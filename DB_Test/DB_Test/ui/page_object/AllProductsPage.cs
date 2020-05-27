using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DB_Test
{
    class AllProductsPage
    {
        private IWebDriver driver;
                
        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public EditPage ClickOn(string value)
        {
            driver.FindElement(By.LinkText($"{value}")).Click();
            return new EditPage(driver);
        }
        public int IsExist(string value)
        {
            return driver.FindElements(By.XPath($"//tr/td/a[text()=\"{value}\"]")).Count;
        }
    }
}
