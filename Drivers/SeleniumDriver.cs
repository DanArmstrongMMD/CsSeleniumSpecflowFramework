using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecflowTraining.Drivers
{
    internal class SeleniumDriver
    {
        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Setup()
        {
            var chromeOptions = new ChromeOptions();

            driver = new ChromeDriver(chromeOptions);
            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
