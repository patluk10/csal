using OpenQA.Selenium;
using System;

namespace caseStudyAlza.utils
{
    internal class WebDriverManager
    {
        private WebDriverFactory webDriverFactory;

        public WebDriverManager() : this(new WebDriverFactory())
        {
        }

        internal WebDriverManager(WebDriverFactory factory)
        {
            webDriverFactory = factory;
        }
      
        public IWebDriver runWebDriver()
        {
            IWebDriver driver = webDriverFactory.createWebDriverInstance();
            driver.Manage().Window.Maximize();
            return driver;
        }
      
       
    }
}