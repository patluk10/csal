using OpenQA.Selenium;
using System;

namespace caseStudyAlza.pages
{
    class JobDescriptionPage : AlzaBasePage
    {
        public JobDescriptionPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement ApplicationBtn => driver.FindElement(By.XPath("//input[@class='button application_button']"));
        private IWebElement NameInput => driver.FindElement(By.Id("applicationFormName"));
        private IWebElement EmailInput => driver.FindElement(By.Id("applicationFormEmail"));
        private IWebElement PhoneInput => driver.FindElement(By.Id("applicationFormPhone"));
        private IWebElement LinkedinInput => driver.FindElement(By.Id("applicationFormLinkedIn"));
        private IWebElement LetterInput => driver.FindElement(By.Id("applicationFormLetter"));

        public JobDescriptionPage ClickOnApplicationButton()
        {
            Click(ApplicationBtn);
            return this;
        }

        public JobDescriptionPage SetName(String name)
        {
            SendKeys(NameInput, name);
            return this;
        }

        public JobDescriptionPage SetEmail(String email)
        {
            SendKeys(EmailInput, email);
            return this;
        }

        public JobDescriptionPage SetPhone(String phone)
        {
            SendKeys(PhoneInput, phone);
            return this;
        }

        public JobDescriptionPage SetLinkedin(String url)
        {
            SendKeys(LinkedinInput, url);
            return this;
        }

        public JobDescriptionPage SetLetter(String letterText)
        {
            SendKeys(LetterInput, letterText);
            return this;
        }

        public JobDescriptionPage CheckInsertedData(String insertedData)
        {
            CheckElementIsPresent(By.XPath(string.Format("//input[@type='text' or 'email'][@value='{0}']", insertedData)));
            return this;
        }
    }
}