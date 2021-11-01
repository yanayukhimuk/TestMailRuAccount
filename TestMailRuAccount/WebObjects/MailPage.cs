using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TestMailRuAccount.WebDriver;

namespace TestMailRuAccount.WebObjects
{
    public class MailPage : BasePage
    {
        private static readonly By MaillBL = By.XPath("//span[@class='ph-project__user-name svelte-1xjymf4']");

        [System.Obsolete]
        public MailPage() : base(MaillBL, "jane.black@internet.ru") { }

        private readonly BaseElement NewLetter = new BaseElement(By.XPath("//span[@class='compose-button__txt']"));
        static private readonly BaseElement ElectrButtons = new BaseElement(By.XPath("//input[@class='container--H9L5q size_s--3_M-_']")); // убрать подчеркивание 
        static private readonly BaseElement LetterButtons = new BaseElement(By.XPath("//span[@class='button2__txt']")); //3
        static private readonly BaseElement FunctionButtons = new BaseElement(By.XPath("//div[@class='container--1HmQy']")); //4
        static private readonly BaseElement LetterNavButtons = new BaseElement(By.XPath("//div[@class='nav__folder-name__txt']"));
        static private readonly BaseElement SentLetters = new BaseElement(By.XPath("//span[@class='ll-crpt']"));
        static private readonly BaseElement AccountButtons = new BaseElement(By.XPath("//div[@class='ph-text svelte-1vf03eq']"));
        

        readonly IReadOnlyCollection<BaseElement> emailButtons = ElectrButtons as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> letterButtons = LetterButtons as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> functionButtons = FunctionButtons as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> navigationButtons = LetterNavButtons as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> letterSet = SentLetters as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> accountButtons = AccountButtons as IReadOnlyCollection<BaseElement>;

        [System.Obsolete]
        public void EnterAddrNameAndEmailTopic(string mes, string emailAddr)
        {
            NewLetter.Click();
            var AddrName = emailButtons.ElementAt(1);
            var EmailTopic = emailButtons.ElementAt(2);
            AddrName.Click();
            AddrName.SendKeys(emailAddr);
            EmailTopic.Click();
            EmailTopic.SendKeys(mes);
        }

        public void WriteALetter(string text)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.GetDriver();
            js.ExecuteScript("document.getElementByClassName('editable-p3tf cke_editable cke_editable_inline cke_contents_true cke_show_borders').click()"); //?
        }

        [System.Obsolete]
        public void SaveLetter()
        {
           letterButtons.ElementAt(3).Click();
        }

        [System.Obsolete]
        public void CloseLetter()
        {
            functionButtons.ElementAt(4).Click();
        }
        [System.Obsolete]
        public void GoToSaved(string EmailAddr)
        {
            navigationButtons.ElementAt(6).Click();
            Assert.AreEqual(EmailAddr, GetActualAddr());
        }
        [System.Obsolete]
        public string GetActualAddr()
        {
            var _neededLetter = letterSet.ElementAt(1);
            return _neededLetter.GetAttribute("title").ToString();
        }
        [System.Obsolete]
        public void LogOff()
        {
            var EmailAddressOnTop = new BaseElement(By.XPath("//span[@class='ph-project__user-name svelte-1xjymf4']"));
            EmailAddressOnTop.Click();
            accountButtons.ElementAt(3).Click();
            Assert.That(new BaseElement(By.XPath("//button[@class='ph-login svelte-1xjymf4']")).Displayed);
        }
        [System.Obsolete]
        public void SendSavedLetter(string EmailAddr)
        {
            var NeededLetter = letterSet.ElementAt(3);
            NeededLetter.Click();
            letterButtons.ElementAt(1).Click();
            navigationButtons.ElementAt(5).Click();
            Assert.AreEqual(EmailAddr, GetActualAddr());
        }
    }
}
