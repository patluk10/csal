using System;
using NUnit.Framework;
using OpenQA.Selenium;
using caseStudyAlza.utils;
using caseStudyAlza.config;


namespace caseStudyAlza
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        protected BaseTest()
        {
        }

        [SetUp]
        public void setDriver()
        {
            driver = new WebDriverManager().runWebDriver();
        }

        [TearDown]
        public void TestTearDown()
        {
            driver.Quit();
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMdd-HH-mm-ss-ff");
        }
        public void TakeScreenshot()
        {
            string timestamp = GetTimestamp(DateTime.Now);
            string fileName = ("failureScreenshot_" + timestamp + ".png");
            string filePath = Config.FilePath;
            try
            {
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(filePath + fileName, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        protected void AlzaTest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                this.TakeScreenshot();
                Console.WriteLine("Test failed on exception: " + ex + " -------- Screenshot taken. --------");
                throw;
            }
        }

    }
}
