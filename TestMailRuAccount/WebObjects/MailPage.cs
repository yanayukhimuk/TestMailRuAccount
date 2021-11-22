using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using TestMailRuAccount.WebDriver;

namespace TestMailRuAccount.WebObjects
{
    public class MailPage : BasePage
    {
        private static readonly By MaillBL = By.XPath("//span[@class='compose-button__txt']");

        [System.Obsolete]
        public MailPage() : base(MaillBL, "Написать письмо") { }

        IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;

        static private readonly BaseElement NewLetter = new(By.XPath("//span[@class='compose-button__txt']"));
        static private readonly BaseElement ToWhom = new(By.XPath("//input[@class='container--H9L5q size_s--3_M-_']"));
        static private readonly BaseElement EmailTopic = new(By.Name("Subject"));
        static private readonly BaseElement WriteLetter = new(By.TagName("br"));
        static private readonly BaseElement LetterNavButtons = new(By.XPath("//div[@class='nav__folder-name__txt']"));
        static private readonly BaseElement SentLetters = new(By.XPath("//span[@class='ll-crpt']"));
        static private readonly BaseElement AccountButtons = new(By.XPath("//div[@class='ph-text svelte-1vf03eq']"));


        readonly IReadOnlyCollection<BaseElement> navigationButtons = LetterNavButtons as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> letterSet = SentLetters as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> accountButtons = AccountButtons as IReadOnlyCollection<BaseElement>;

        [System.Obsolete]
        public void EnterAddrNameAndEmailTopic(string topic, string emailAddr)
        {
            NewLetter.WaitForIsVisible();
            NewLetter.Click();
            ToWhom.WaitForIsClickable();
            ToWhom.Click();
            ToWhom.SendKeys(emailAddr);
            EmailTopic.Click();
            EmailTopic.SendKeys(topic);
        }

        [System.Obsolete]
        public void WriteALetter(string text)
        {
            WriteLetter.Click();
            WriteLetter.SendKeys(text);
        }

        [System.Obsolete]
        public void SaveLetter()
        {
            var LetterButtons = Browser.GetDriver().FindElements(By.XPath("//span[@class='button2__txt']"));
            LetterButtons.ElementAt(3).Click();
        }

        [System.Obsolete]
        public void CloseLetter()
        {
            var FunctionButtons = Browser.GetDriver().FindElements(By.XPath("//div[@class='container--1HmQy']"));
            FunctionButtons.ElementAt(4).Click();
        }
        [System.Obsolete]
        public void GoToSaved()
        {
            var FilterButton = Browser.GetDriver().FindElement(By.XPath("//span[@class='filters-control__filter-text']"));
            Browser.NavigateTo("https://e.mail.ru/drafts/");
            Assert.That(FilterButton.Displayed);
        }
        public void IfIsPresentAsDraft()
        {
            var LastSavedLetterList = Browser.GetDriver().FindElements(By.XPath("//span[@title='yana.ryzhikova.brest.belarus@gmail.com']"));
            Assert.That(LastSavedLetterList.ElementAt(1).Displayed);
        }

        [System.Obsolete]
        public void LogOff()
        {
            var EmailAddressOnTop = new BaseElement(By.XPath("//span[@class='ph-project__user-name svelte-1xjymf4']"));
            new Actions(Browser.GetDriver()).Click(EmailAddressOnTop).Build().Perform();
            accountButtons.ElementAt(3).Click();
            Assert.That(new BaseElement(By.XPath("//button[@class='ph-login svelte-1xjymf4']")).Displayed);
        }
        [System.Obsolete]
        public void SendSavedLetter(string EmailAddr)
        {
            var NeededLetter = letterSet.ElementAt(3);
            NeededLetter.Click();
            //letterButtons.ElementAt(1).Click();
            navigationButtons.ElementAt(5).Click();
            //Assert.AreEqual(EmailAddr, IfIsPresentAsDraft());
        }
    }
}
