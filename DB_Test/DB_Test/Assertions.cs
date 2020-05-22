using OpenQA.Selenium;

namespace DB_Test
{
    class Assertions
    {
        private IWebDriver driver;
        public Assertions(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string ReturnHeader(string header)
        {
            return driver.FindElement(By.XPath($"//h2[contains(.,\'{header}\')]")).Text;
        }
        public string Check(string category)
        {
            return driver.FindElement(By.Id($"{category}")).GetAttribute("value");
        }
        public string CheckDropDown(string category)
        {
            return driver.FindElement(By.XPath($"//*[@id=\"{category}\"]/option[@selected]")).Text;
        }
        public int IsNotExist (string productName)
        {
            return driver.FindElements(By.XPath($"//tr/td/a[text()=\"{productName}\"]")).Count;
        }
    }
}
