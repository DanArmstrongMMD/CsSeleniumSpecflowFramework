using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecflowTraining.Pages
{
    internal class ExamplePage : BasePage
    {
        public ExamplePage(IWebDriver driver) : base(driver) {}

        private readonly string _url = "https://www.google.com";
        private bool actionPerformed = false;

        public bool IsLoaded => IsElementDisplayed(_driver.FindElement(By.CssSelector("div[id='exampleId']")));

        public ExamplePage GoToPage()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }

        public ExamplePage PerformAction()
        {
            actionPerformed = true;
            return this;
        }

        public ExamplePage ConfirmExampleActionComplete()
        {
            Assert.True(actionPerformed);
            return this;
        }

    }
}
