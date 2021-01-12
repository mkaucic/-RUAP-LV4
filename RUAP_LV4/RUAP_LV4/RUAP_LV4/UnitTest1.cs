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
    public class Login
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
        public void TheLoginTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("matakaucic@gmail.com");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("SamirNasri2809");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        [Test]
        public void TheWishlistTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.XPath("//img[@alt='MacBook']")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/button/i")).Click();
            driver.FindElement(By.XPath("//a[@id='wishlist-total']/span")).Click();
        }

        [Test]
        public void ThePretraIvanjeTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.Name("search")).Click();
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys("MacBook");
            driver.FindElement(By.Name("search")).SendKeys(Keys.Enter);
        }
        [Test]
        public void TheKupnjaTest()
        {

            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("matakaucic@gmail.com");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("blabla");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.XPath("//img[@alt='MacBook']")).Click();
            driver.FindElement(By.Id("button-cart")).Click();
            driver.FindElement(By.Id("cart-total")).Click();
            driver.FindElement(By.XPath("//div[@id='cart']/ul/li[2]/div/p/a[2]/strong")).Click();
        }

        [Test]
        public void ThePromjenaZaporkeTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("matakaucic@gmail.com");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("blabla");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'My Account')]")).Click();
            driver.FindElement(By.LinkText("Change your password")).Click();
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("blabla");
            driver.FindElement(By.Id("input-confirm")).Click();
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("blabla");
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
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

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
