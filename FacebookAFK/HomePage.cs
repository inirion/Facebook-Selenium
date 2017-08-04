using OpenQA.Selenium;

namespace FacebookAFK
{
    class HomePage
    {
        #region Variables
        private IWebElement MessageButton;
        private bool SendedFirstMessage;
        #endregion
        public HomePage()
        {
            MessageButton = WebsiteDriver.driver.FindElement(By.XPath(@"//a[contains(@data-tooltip-content,'Wiadomości')]"));
            SendedFirstMessage = false;
        }

        public IWebElement SelectPersonToMessage(string name)
        {
            return WebsiteDriver.driver.FindElement(By.XPath(@"//a[div//span[text()='" + name + "']]"));
        }

        public void SendMessage(string person, string message)
        {
            if (!SendedFirstMessage)
            {
                MessageButton.Click();
                Sleep(1);
                SelectPersonToMessage(person).Click();
                Sleep(1);
                SendedFirstMessage = true;
            }
            GetActiveElement().Clear();
            GetActiveElement().SendKeys(message);
            GetActiveElement().SendKeys(Keys.Enter);
            Sleep(1);
        }

        public void Logout()
        {

        }

        private void Sleep(int secounds)
        {
            System.Threading.Thread.Sleep(secounds * 1000);
        }

        private IWebElement GetActiveElement()
        {
            return WebsiteDriver.driver.SwitchTo().ActiveElement();
        }
    }
}
