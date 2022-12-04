using NUnit.Framework;
using OpenQA.Selenium;
using CsSeleniumSpecflowFramework.Drivers;

namespace CsSeleniumSpecflowFramework.Features.Hooks
{
    [Binding]
    public sealed class ContextHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public ContextHooks(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = DriverBuilder.BuildDriver();
            _scenarioContext.Set(driver, "WebDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    string filePath = $"{TestContext.CurrentContext.TestDirectory}\\{TestContext.CurrentContext.Test.MethodName}.jpg";
                    ITakesScreenshot photographer = (ITakesScreenshot)_scenarioContext.Get<IWebDriver>("WebDriver");
                    
                    photographer.GetScreenshot()
                        .SaveAsFile(filePath);
                    TestContext.AddTestAttachment(filePath);

                    Console.WriteLine("Screenshot taken and saved at: " + filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to take Screenshot, error: " + ex);
            }
            finally
            {
                _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
            }
        }
    }
}