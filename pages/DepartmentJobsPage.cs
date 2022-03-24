using OpenQA.Selenium;

namespace caseStudyAlza.pages
{
    class DepartmentJobsPage : AlzaBasePage
    {

        public DepartmentJobsPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public DepartmentJobsPage CheckChosenDepartment(string chosenDepartment)
        {
            CheckElementIsPresent(By.XPath(string.Format("//li[@class='chosen'][span='{0}']", chosenDepartment)));
            return this;
        }

    }
}