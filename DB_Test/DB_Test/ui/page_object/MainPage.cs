using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DB_Test
{
    public class MainPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public MainPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        private IWebElement NameField => driver.FindElement(By.Id("Name"));
        private IWebElement PasswordField => driver.FindElement(By.Id("Password"));
        private IWebElement AllProducts => driver.FindElement(By.CssSelector(".container-fluid:nth-child(3) > div:nth-child(1) > a"));
        private IWebElement LogOut => driver.FindElement(By.LinkText("Logout"));
        public void LogIn (string name, string password)
        {
            new Actions(driver).Click(NameField).SendKeys(name).Build().Perform();
            new Actions(driver).Click(PasswordField).SendKeys(password).Build().Perform();
            new Actions(driver).SendKeys(Keys.Enter).Build().Perform();
        }
        public AllProductsPage AllProductsLink()
        {
            new Actions(driver).Click(AllProducts).Build().Perform();
            return new AllProductsPage(driver, wait);
        }
        public void LogOutLink()
        {
            new Actions(driver).Click(LogOut).Build().Perform();
        }
    }
}
