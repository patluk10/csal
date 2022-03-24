using OpenQA.Selenium;

namespace caseStudyAlza.pages
{
    class CareerMainPage : AlzaBasePage
    {
        public CareerMainPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        public DepartmentJobsPage ChooseDepartmentCategory(string department)
        {
            Click(By.XPath(string.Format("//li[@class='job-category']//h4[text()='{0}']", department)));
            return new DepartmentJobsPage(driver);
        }
    }
}