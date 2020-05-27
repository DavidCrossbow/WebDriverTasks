using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DB_Test
{
    class EditPage
    {
        private IWebDriver driver;
        
        public EditPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void Select(string category, string value)
        {
            var element = driver.FindElement(By.Id($"{category}"));
            new Actions(driver).Click(element).SendKeys(value).SendKeys(Keys.Tab).Build().Perform();
        }
        public void ToDropDown(string category, string value)
        {
            driver.FindElement(By.Id($"{category}")).FindElement(By.XPath($"//option[. = '{value}']")).Click();
            new Actions(driver).SendKeys(Keys.Tab).Build().Perform();
            
        }
        public AllProductsPage Submit(string value)
        {
            driver.FindElement(By.XPath($"//input[@type='{value}']")).Click();
            return new AllProductsPage(driver);
        }





    }
}

;