using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FacebookAFK
{
    class FrontPage
    {
        #region Variables
        private IWebElement LoginInput;
        private IWebElement PasswordInput;
        private IWebElement LoginButton;
        private string baseURL;
        #endregion
        public FrontPage()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            WebsiteDriver.driver = new ChromeDriver(options);
            baseURL = @"http://facebook.com/";
            WebsiteDriver.driver.Navigate().GoToUrl(baseURL);
            LoginInput = WebsiteDriver.driver.FindElement(By.XPath(@"//input[@type='email']"));
            PasswordInput = WebsiteDriver.driver.FindElement(By.XPath(@"//input[@type='password']"));
            LoginButton = WebsiteDriver.driver.FindElement(By.XPath(@"//label[@id='loginbutton']"));
        }

        public HomePage Login(string login, string password)
        {
            LoginInput.Clear();
            LoginInput.SendKeys(login);
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
            LoginButton.Click();
            return new HomePage();
        }
    }
}
