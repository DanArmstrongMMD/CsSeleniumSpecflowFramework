using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace CsSeleniumSpecflowFramework.Drivers
{
    internal static class DriverBuilder
    {
        public static IWebDriver BuildDriver()
        {
            IWebDriver driver;

            // TODO: implement a way to import these from command line/runsettings file
            String browserType = "chrome";
            bool headless = false;

            switch (browserType)
            {
                case "chrome":
                    {
                        ChromeOptions options = new();
                        if (headless)
                        {
                            options.AddArguments("--headless");
                        }
                        options.AddArguments("--window-size=1920,1200");
                        driver = new ChromeDriver(options);
                        break;
                    }
                case "edge":
                    {
                        EdgeOptions options = new();
                        if (headless)
                        {
                            options.AddArguments("--headless");
                        }
                        options.AddArguments("--window-size=1920,1200");
                        driver = new EdgeDriver(options);
                        break;
                    }
                case "firefox":
                    {
                        FirefoxOptions options = new();
                        if (headless)
                        {
                            options.AddArguments("--headless");
                        }
                        options.AddArguments("--window-size=1920,1200");
                        driver = new FirefoxDriver(options);
                        break;
                    }
                case "safari":
                    {
                        SafariOptions options = new();
                        if (headless)
                        {
                            Console.WriteLine("Note: Headless Mode not supported by Safari");
                        }
                        driver = new SafariDriver(options);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Warn: Unsupported browser type selected, defaulting to Chrome...");
                        ChromeOptions options = new();
                        if (headless)
                        {
                            options.AddArguments("--headless");
                        }
                        options.AddArguments("--window-size=1920,1200");
                        driver = new ChromeDriver(options);
                        break;
                    }
            }

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
