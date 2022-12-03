using OpenQA.Selenium;
using SpecflowTraining.Drivers;

namespace SpecflowTraining.Features.Hooks
{
    [Binding]
    public sealed class ContextHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public ContextHooks(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}