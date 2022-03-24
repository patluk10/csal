using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace caseStudyAlza.pages
{
    class JobsListPage : AlzaBasePage
    {
        public JobsListPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public string jobPostXpath = "//ul[@class='job_listings list']//li[contains(@class, 'status-publish')]";
        public JobsListPage ChooseJobCategory(string category)
        {
            Click(By.XPath(string.Format("//div[@class='job-details-inner']//h3[text()='{0}']", category)));
            return new JobsListPage(driver);
        }
        public JobsListPage CheckJobsPageOfChosenCategory(String category)
        {
            CheckElementIsPresent(By.XPath(string.Format("//h1[@class='site-content-page-title'][text()='{0}']", category)));
            return this;
        }

        public JobsListPage GetCountOfPublishedJobAdvertisements()
        {
            this.CountOfJobs(driver);
            return this;
        }

        public JobsListPage CountOfJobs(IWebDriver driver)
        {
            IList<IWebElement> jobs = driver.FindElements(By.XPath(jobPostXpath));
            Console.WriteLine(" -------- There are " + jobs.Count + " job advertisements in this category. --------");
            return this;
        }

        public JobsListPage ClickOnLastJobPost()
        {
            string lastPositionFromListInfo = driver.FindElement(By.XPath(jobPostXpath + "[last()]")).Text;
            Console.WriteLine(" -------- Last item in job advertisements list is: " + lastPositionFromListInfo + " --------");
            Click(By.XPath(jobPostXpath + "[last()]"));
            return new JobsListPage(driver);
        }
    }
}