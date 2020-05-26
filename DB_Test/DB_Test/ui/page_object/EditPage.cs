using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DB_Test
{
    public class EditPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        
        public EditPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        //private IWebElement Discontinued => driver.FindElement(By.Id("Discontinued"));
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
        public AllProductsPage Submit()
        {
            new Actions(driver).SendKeys(Keys.Enter).Build().Perform();
            return new AllProductsPage(driver, wait);
        }
    }
}

;