using NUnit.Framework;
using OpenQA.Selenium;
using CsSeleniumSpecflowFramework.Drivers;
using CsSeleniumSpecflowFramework.Pages;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace CsSeleniumSpecflowFramework.StepDefinitions
{
    [Binding]
    public sealed class BrowserStepDef
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        private ExamplePage examplePage;

        public BrowserStepDef(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user has navigated to the example page")]
        public void GivenTheUserHasNavigatedToTheExamplePage()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            examplePage = new ExamplePage(driver).GoToPage();
        }

        [When(@"the user does an action")]
        public void WhenTheUserDoesAnAction()
        {
            examplePage
                .PerformAction();
        }

        [Then(@"the user should see the result")]
        public void ThenTheUserShouldSeeTheResult()
        {
            examplePage
                .ConfirmExampleActionComplete();
        }

    }
}