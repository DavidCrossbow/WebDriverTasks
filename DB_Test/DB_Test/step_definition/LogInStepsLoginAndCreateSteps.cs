using DB_Test.business_object;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using TechTalk.SpecFlow;

namespace DB_Test.step_definition
{
    [Binding]
    class LogInStepsLoginAndCreateSteps
    {
        private IWebDriver driver;
        private LogIn login = JsonConvert.DeserializeObject<LogIn>(File.ReadAllText("LogIn.json"));

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
        }

        [Given(@"I open ""(.*)"" url")]
        public void GivenIOpenUrl(string url)
        {
             driver.Url = url;
        }

        [When("I type my login data")]
        public void WhenITypeMyLoginData()
        {
            new MainPage(driver).AutorizationData(login);
        }

        [When("I press the Enter button")]
        public void WhenIPressTheEnter()
        {
            new MainPage(driver).AutorizationSend();
        }

        [When(@"I click on ""(.*)"" link")]
        public void IClickOnAllProductsLink(string value)
        {
            new MainPage(driver).ClickOn(value);
        }

        [When(@"I click on ""(.*)"" button")]
        public void IClickOnCreateNewButton(string value)
        {
            new AllProductsPage(driver).ClickOn(value);
        }

        [When(@"I fill the first field ""(.*)"" with ""(.*)""")]
        public void IFillTheFirstField(string category, string value)
        {
            new EditPage(driver).Select(category, value);
        }

        [When(@"I pick ""(.*)""  on the first dropdown ""(.*)""")]
        public void IPickOnTheFirstDropdown(string value, string category)
        {
            new EditPage(driver).ToDropDown(category, value);
        }

        [When(@"I pick ""(.*)"" on the second dropdown ""(.*)""")]
        public void IPickOnTheSecondDropdown(string value, string category)
        {
            new EditPage(driver).ToDropDown(category, value);
        }

        [When(@"I fill the second field ""(.*)"" with ""(.*)""")]
        public void IFillTheSecondField(string category, string value)
        {
            new EditPage(driver).Select(category, value);

        }

        [When(@"I click on ""(.*)"" button to create a new product")]
        public void IClickOnSubmitButton (string value)
        {
            new EditPage(driver).Submit(value);
        }

        [Then(@"I check that ""(.*)"" product has been created")]
        public void ICheckThatProductCreated (string value)
        {
            Assert.AreEqual(new AllProductsPage(driver).IsExist(value), 1);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Quit();
        }
    }
}