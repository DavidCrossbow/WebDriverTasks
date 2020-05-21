using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace DB_Test
{
    public class Tests
    {
        private IWebDriver driver;
     
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/");
            // каждый тест начинается  с указанного URL
        }

        [OneTimeTearDown]
        protected void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
        [Test]
        public void Test1_LogIn()
        {
            Assert.That(driver.FindElement(By.XPath("//h2[contains(.,\'Login\')]")).Text, Is.EqualTo("Login"));
            driver.FindElement(By.Id("Name")).Click();
            driver.FindElement(By.Id("Name")).SendKeys(LogIn.Username);
            driver.FindElement(By.Id("Password")).SendKeys(LogIn.Password);
            driver.FindElement(By.XPath("//input[@type=\'submit\']")).Click();
            Assert.That(driver.FindElement(By.XPath("//h2[contains(.,\'Home page\')]")).Text, Is.EqualTo("Home page"));
        }
        [Test]
        public void Test2_InsertNew()
        {
            driver.FindElement(By.CssSelector(".container-fluid:nth-child(3) > div:nth-child(1) > a")).Click();
            Assert.That(driver.FindElement(By.XPath("//h2[contains(.,\'All Products\')]")).Text, Is.EqualTo("All Products"));
            driver.FindElement(By.LinkText("Create new")).Click();
            Assert.That(driver.FindElement(By.CssSelector("h2")).Text, Is.EqualTo("Product editing"));
            driver.FindElement(By.Id("ProductName")).SendKeys(Data.ProductName);
            {
                var dropdown = driver.FindElement(By.Id("CategoryId"));
                dropdown.FindElement(By.XPath("//option[. = 'Confections']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("SupplierId"));
                dropdown.FindElement(By.XPath("//option[. = 'Pavlova, Ltd.']")).Click();
            }
            driver.FindElement(By.Id("UnitPrice")).SendKeys(Data.UnitPriceToInput);
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys(Data.QuantityPerUnit);
            driver.FindElement(By.Id("UnitsInStock")).SendKeys(Data.UnitsInStock);
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys(Data.UnitsOnOrder);
            driver.FindElement(By.Id("ReorderLevel")).SendKeys(Data.ReorderLevel);
            driver.FindElement(By.Id("Discontinued")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            Assert.That(driver.FindElement(By.XPath("//h2[contains(.,\'All Products\')]")).Text, Is.EqualTo("All Products"));
        }
        [Test]
        public void Test3_Open()
        {
            driver.FindElement(By.CssSelector(".container-fluid:nth-child(3) > div:nth-child(1) > a")).Click();
            driver.FindElement(By.LinkText("Biscuits")).Click();
            {
                string value = driver.FindElement(By.Id("ProductName")).GetAttribute("value");
                Assert.That(value, Is.EqualTo(Data.ProductName));
            }
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/option[@selected]")).Text, Is.EqualTo("Confections"));
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/option[@selected]")).Text, Is.EqualTo("Pavlova, Ltd."));
            {
                string value = driver.FindElement(By.Id("UnitPrice")).GetAttribute("value");
                Assert.That(value, Is.EqualTo(Data.UnitPriceToRead));
            }
            {
                string value = driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute("value");
                Assert.That(value, Is.EqualTo(Data.QuantityPerUnit));
            }
            {
                string value = driver.FindElement(By.Id("UnitsInStock")).GetAttribute("value");
                Assert.That(value, Is.EqualTo(Data.UnitsInStock));
            }
            {
                string value = driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute("value");
                Assert.That(value, Is.EqualTo(Data.UnitsOnOrder));
            }
            {
                string value = driver.FindElement(By.Id("ReorderLevel")).GetAttribute("value");
                Assert.That(value, Is.EqualTo(Data.ReorderLevel));
            }
            {
                string value = driver.FindElement(By.Id("Discontinued")).GetAttribute("value");
                Assert.That(value, Is.EqualTo("true"));
            }
        }


        [Test]
        public void Test4_Delete()
        {
            driver.FindElement(By.CssSelector(".container-fluid:nth-child(3) > div:nth-child(1) > a")).Click();
            driver.FindElement(By.XPath("//tr/td/a[text()=\"Biscuits\"]//following::td//a[text()=\"Remove\"]")).Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(100); 
            //C явным/неявным ожиданием проваливается тест, поставил Sleep

            var element = driver.FindElements(By.XPath("//tr[last()]/td/a[text()=\"Biscuits\"]"));
            Assert.True(element.Count == 0);
        }

        [Test]
        public void Test5_LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            Assert.That(driver.FindElement(By.XPath("//h2[contains(.,\'Login\')]")).Text, Is.EqualTo("Login"));
        }
    }
}

