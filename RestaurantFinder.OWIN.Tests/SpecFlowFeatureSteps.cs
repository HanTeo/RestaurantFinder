using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace RestaurantFinder.OWIN.Tests
{
    [Binding]
    public class SpecFlowFeatureSteps
    {
        readonly IWebDriver driver = new ChromeDriver();

        [Given(@"I have entered (.*) into the webpage")]
        public void GivenIHaveEnteredHttpLocalhostRestaurantsIntoTheWebpage(string p0)
        {
            driver.Navigate().GoToUrl(p0);
        }
        
        [Given(@"I have entered (.*) into the input box")]
        public void GivenIHaveEnteredIntoTheInputBox(string p0)
        {
            driver.FindElement(By.Id("searchTxt")).SendKeys(p0);
        }
        
        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            driver.FindElement(By.Id("myButton")).Click();
        }
        
        [Then(@"I should see a table of restaurants listed on the screen")]
        public void ThenIShouldSeeATableOfRestaurantsListedOnTheScreen()
        {
            IWebElement table = driver.FindElement(By.TagName("table"));
            var rows = table.FindElements(By.TagName("tr"));
            Assert.Greater(rows.Count, 1);
        }
    }
}
