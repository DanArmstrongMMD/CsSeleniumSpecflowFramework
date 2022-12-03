using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace SpecflowTraining.Pages
{
    internal class BasePage
    {
        protected IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly int _maxAttempts = 3;
        private int _attempts = 0;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 10));
        }

        protected bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                WaitUntilElementIsDisplayed(element);
                return true;
            }
            catch (Exception e)
            {
                if (e is NoSuchElementException || e is StaleElementReferenceException)
                {
                    return false;
                }

                throw;
            }
        }

        protected IWebElement WaitUntilElementIsDisplayed(IWebElement element)
        {
            while (_attempts < _maxAttempts)
            {
                try
                {
                    _wait.Until(condition => element.Displayed);
                    break;
                }
                catch (Exception e)
                {
                    if (e is NoSuchElementException || e is StaleElementReferenceException)
                    {
                        if (_attempts > _maxAttempts)
                        {
                            Console.WriteLine("Failed to find element, or lost the reference too many times, failing...");
                            throw;
                        }
                        else
                        {
                            ++_attempts;
                            Console.WriteLine("Failed to find element, or lost the reference, retrying...");
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return element;
        }
    }
}
