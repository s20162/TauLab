using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("https://www.zalando.pl/kobiety-home/");
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("q")).Clear();
            driver.FindElement(By.Name("q")).SendKeys("nike air max");
            driver.FindElement(By.CssSelector(".z-navicat-header_searchForm")).Submit();
            driver.Navigate().GoToUrl("https://www.zalando.pl/kobiety/?q=nike+air+max");
            driver.FindElement(By.XPath("//img[@alt='AIR MAX 97 WT UNISEX - Sneakersy niskie - iron grey/white/volt-black']")).Click();
            driver.Navigate().GoToUrl("https://www.zalando.pl/nike-sportswear-air-max-97-wt-unisex-sneakersy-niskie-iron-greywhitevolt-black-ni115o047-c11.html");
            driver.FindElement(By.XPath("//div[@id='main-content']/div/div/div/div[2]/div/x-wrapper-re-1-6/div/div[2]/button/span")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Rozmiary producenta'])[1]/following::span[11]")).Click();
            driver.FindElement(By.XPath("//div[@id='z-navicat-header-root']/header/div/div/div/div/div/div/div/div/div/div[3]/div/div[4]/div/div[2]/div[3]/a/div")).Click();
            driver.Navigate().GoToUrl("https://www.zalando.pl/cart");
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
