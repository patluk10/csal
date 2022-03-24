using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;

namespace caseStudyAlza.pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected Boolean CheckIfElementExists(By by)
        {
            try
            {
                WaitForElementToBeClickable(driver.FindElement(by));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:  " + e);
                return false;
            }

        }
        protected void CheckElementIsPresent(By by)
        {
            WaitForElementToBePresent(driver.FindElement(by));
        }

        protected void WaitForElementToBePresent(IWebElement webElement)
        {
            int counter = 0;
            while (counter < 3)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    if (webElement != null && webElement.Displayed)
                    {
                        // Console.WriteLine("Found element " + webElement);
                        break;
                    }
                }
                catch (Exception e)
                {
                    if (e is NoSuchElementException || e is ElementNotInteractableException || e is WebDriverException)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        counter++;
                        Console.WriteLine("Could not see element ");
                        Console.WriteLine("Exception:  " + e);
                    }
                    else throw new NoSuchElementException("Element " + webElement + " does not exist");
                }
            };
            if (counter >= 3)
            {
                throw new NoSuchElementException("Element " + webElement + " does not exist after wait");
            }
        }

        protected void WaitForElementToBeClickable(IWebElement webElement)
        {
            int counter = 0;
            while (counter < 3)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    if (webElement != null && webElement.Displayed && webElement.Enabled)
                    {
                        // Console.WriteLine("Found element "+webElement);
                        break;
                    }
                }
                catch (Exception e)
                {
                    if (e is StaleElementReferenceException || e is ElementNotInteractableException || e is WebDriverException)
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        counter++;
                        Console.WriteLine("Could not see element ");
                        Console.WriteLine("Exception:  " + e);
                    }
                    else throw new NoSuchElementException("Element " + webElement + " does not exist");
                }
            };
            if (counter >= 3)
            {
                throw new NoSuchElementException("Element " + webElement + " does not exist after wait");
            }
        }


        protected void Click(IWebElement webElement)
        {
            WaitForElementToBeClickable(webElement);
            webElement.Click();
            // Console.WriteLine("Clicked on element " + webElement);
        }

        protected void Click(By by)
        {
            WaitForElementToBeClickable(driver.FindElement(by));
            driver.FindElement(by).Click();
            // Console.WriteLine("Clicked on element " + by);

        }

        protected void SendKeys(IWebElement webElement, String value)
        {
            WaitForElementToBeClickable(webElement);
            webElement.Clear();
            webElement.SendKeys(value);
            Console.WriteLine("Input value " + value + " to element " + webElement);

        }

        protected void checkCurrentUrl(string url)
        {
            String actual_url = driver.Url;
            Assert.That(actual_url, Is.EqualTo(url));
        }
    }
}