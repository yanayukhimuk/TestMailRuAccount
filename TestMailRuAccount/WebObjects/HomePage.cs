using OpenQA.Selenium;
namespace TestMailRuAccount.WebObjects
{
    public class HomePage : BasePage
    {
        private static readonly By MailRuLbl = By.XPath("//div[@class='logo svelte-1kkb4qr']");
        

        [System.Obsolete]
        public HomePage() : base(MailRuLbl, "Mail.ru") { }

        static private readonly BaseElement Login = new(By.XPath("//input[@class='email-input svelte-1tib0qz']"));
        static private readonly BaseElement Password = new(By.XPath("//input[@class='password-input svelte-1tib0qz']"));
        private readonly BaseElement NextButtonToEnterPassword = new(By.XPath("//button[@class='button svelte-1tib0qz']"));
        private readonly BaseElement ConfirmButton = new(By.XPath("//button[@class='second-button svelte-1tib0qz']"));

        [System.Obsolete]
        public void LoginInMailBox (string Login, string Password)
        {
            HomePage.Login.WaitForIsVisible();
            HomePage.Login.Click();
            HomePage.Login.SendKeys(Login);
            NextButtonToEnterPassword.Click();

            HomePage.Password.WaitForIsVisible();
            HomePage.Password.SendKeys(Password);
            ConfirmButton.Click();
        }

        [System.Obsolete]
        public void AssertHasLoaded()
        {
            var element = new BaseElement(By.XPath("//div[@class='portal-menu js-shortcut']"));
            element.WaitForIsVisible();
        }
    }
}
