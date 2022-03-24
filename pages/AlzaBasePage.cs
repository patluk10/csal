using OpenQA.Selenium;
using System;
using caseStudyAlza.config;

namespace caseStudyAlza.pages
{
    class AlzaBasePage : BasePage
    {

        private String URL = Config.DefaultUrl;

        public AlzaBasePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public CareerMainPage GoToAlzaCareerPage()
        {
            driver.Navigate().GoToUrl(URL);
            this.checkCurrentUrl("https://www.alza.cz/kariera");
            return new CareerMainPage(driver);
        }
    }
}