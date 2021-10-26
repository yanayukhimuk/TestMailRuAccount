using OpenQA.Selenium;
using System.Threading;

namespace TestMailRuAccount.WebObjects
{
    public class HomePage : BasePage
    {
        private static readonly By HomelBL = By.ClassName("b-titles-outer");
        public HomePage() : base(HomelBL, "Home page") { }

        private readonly BaseElement _mailBoxLogin = new BaseElement (By.XPath("//input[@class='email-input svelte-1tib0qz']"));
        private readonly BaseElement _mailBoxForPass = new BaseElement(By.XPath("//input[@class='email-input svelte-1tib0qz']"));
        private readonly BaseElement _nextButtonToEnterPassword = new BaseElement(By.XPath("//button[@class='button svelte-1tib0qz']"));
        private readonly BaseElement _confirmButton = new BaseElement(By.XPath("//button[@class='second-button svelte-1tib0qz']"));


        public void LoginInMailBox (string Login, string Password)
        {
            //_mailBoxLogin.Click();
            _mailBoxLogin.SendKeys(Login);
            _nextButtonToEnterPassword.Click();
            Thread.Sleep(8000);

           // _mailBoxForPass.Click();
            _mailBoxForPass.SendKeys(Password);
            _confirmButton.Click();
            Thread.Sleep(8000);
        }
    }
}
