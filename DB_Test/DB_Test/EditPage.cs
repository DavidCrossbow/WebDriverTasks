using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DB_Test
{
    class EditPage
    {
        private IWebDriver driver;
        
        public EditPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement Discontinued => driver.FindElement(By.Id("Discontinued"));
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
        public void DiscontinuedCheck()
        {
            new Actions(driver).SendKeys(Keys.Space).Build().Perform();
        }
        public void Submit()
        {
            new Actions(driver).SendKeys(Keys.Enter).Build().Perform();
        }
    }
}

;