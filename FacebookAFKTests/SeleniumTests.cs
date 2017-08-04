using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class Buy
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private ChromeOptions options;
        

        [SetUp]
        public void SetupTest()
        {
            options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            driver = new ChromeDriver(options);
            baseURL = "http://facebook.com/";
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
        }

        [Test]
        public void ShouldLoginAndSendMessageToGroup()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.XPath(@"//input[@type='email']")).Clear();
            driver.FindElement(By.XPath(@"//input[@type='email']")).SendKeys("inirion@o2.pl");
            driver.FindElement(By.XPath(@"//input[@type='password']")).Clear();
            driver.FindElement(By.XPath(@"//input[@type='password']")).SendKeys("veer698384844rch");
            driver.FindElement(By.XPath(@"//label[@id='loginbutton']")).Click();

            driver.FindElement(By.XPath(@"//a[contains(@data-tooltip-content,'Wiadomości')]")).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.XPath(@"//a[div//span[text()='Kamil Filipkowski']]")).Click();
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().ActiveElement().Clear();
            driver.SwitchTo().ActiveElement().SendKeys("Bot123");
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(1000);
        }

        private void AcceptAlert()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Dismiss();
            }
            catch (NoAlertPresentException ex)
            {

            }
        }
    }
}
