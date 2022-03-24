using NUnit.Framework;
using caseStudyAlza.pages;


namespace caseStudyAlza
{
    public class JobApplicationTest : BaseTest
    {
        public string name = "Automation Tester";
        public string email = "autotest@autotest.cz";
        public string phone = "777123456";
        public string linkedinUrl = "www.linkedin.com/automation.tester";
        public string letterText = "This is my text.";

        [Test]
        public void TestJobApplication()
        {
            AlzaTest(() =>
            {
                AlzaBasePage alzaBasePage = new CareerMainPage(driver)
                    .GoToAlzaCareerPage()
                    .ChooseDepartmentCategory("IT")
                    .CheckChosenDepartment("IT");
                JobsListPage jobsListPage = new JobsListPage(driver)
                    .CheckJobsPageOfChosenCategory("Volná místa")
                    .ChooseJobCategory("Quality Assurance")
                    .CheckJobsPageOfChosenCategory("Quality Assurance")
                    .GetCountOfPublishedJobAdvertisements()
                    .ClickOnLastJobPost();
                JobDescriptionPage jobDescriptionPage = new JobDescriptionPage(driver)
                    .ClickOnApplicationButton()
                    .SetName(name)
                    .CheckInsertedData(name)
                    .SetEmail(email)
                    .CheckInsertedData(email)
                    .SetPhone(phone)
                    .CheckInsertedData(phone)
                    .SetLinkedin(linkedinUrl)
                    .CheckInsertedData(linkedinUrl)
                    .SetLetter(letterText)
                    .CheckInsertedData(letterText);
            });
        }
    }
}