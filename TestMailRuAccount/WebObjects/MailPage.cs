using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using TestMailRuAccount.WebObjects;
using TestMailRuAccount.WebDriver;

namespace TestMailRuAccount.WebObjects
{
    public class MailPage : BasePage
    {
        private static readonly By MaillBL = By.ClassName("b-titles-outer");
        public MailPage() : base(MaillBL, "Mail page") { }

        private readonly BaseElement _newLetter = new BaseElement(By.XPath("//span[@class='compose-button__txt']"));
        static private readonly BaseElement _eButtons = new BaseElement(By.XPath("//input[@class='container--H9L5q size_s--3_M-_']"));
        static private readonly BaseElement _letterButtons = new BaseElement(By.XPath("//span[@class='button2__txt']")); //3
        static private readonly BaseElement _functionButtons = new BaseElement(By.XPath("//div[@class='container--1HmQy']")); //4
        static private readonly BaseElement _letterNavButtons = new BaseElement(By.XPath("//div[@class='nav__folder-name__txt']"));
        static private readonly BaseElement _sentLetters = new BaseElement(By.XPath("//span[@class='ll-crpt']"));
        static private readonly BaseElement _accountButtons = new BaseElement(By.XPath("//div[@class='ph-text svelte-1vf03eq']"));
        

        readonly IReadOnlyCollection<BaseElement> emailButtons = _eButtons as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> letterButtons = _letterButtons as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> functionButtons = _functionButtons as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> navigationButtons = _letterNavButtons as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> letterSet = _sentLetters as IReadOnlyCollection<BaseElement>;
        readonly IReadOnlyCollection<BaseElement> accountButtons = _accountButtons as IReadOnlyCollection<BaseElement>;
        public void EnterAddrNameAndEmailTopic(string mes, string emailAddr)
        {
            _newLetter.Click();
            Thread.Sleep(2000);
            var _addrName = emailButtons.ElementAt(1);
            var _emailTopic = emailButtons.ElementAt(2);
            _addrName.Click();
            _addrName.SendKeys(emailAddr);
            _emailTopic.Click();
            _emailTopic.SendKeys(mes);
            Thread.Sleep(2000);
        }

        public void WriteALetter(string text)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.GetDriver();
            js.ExecuteScript("document.getElementByClassName('editable-p3tf cke_editable cke_editable_inline cke_contents_true cke_show_borders').click()"); //?
        }

        public void SaveLetter()
        {
           letterButtons.ElementAt(3).Click();
           Thread.Sleep(2000);
        }

        public void CloseLetter()
        {
            functionButtons.ElementAt(4).Click();
            Thread.Sleep(2000);
        }

        public void GoToSaved()
        {
            navigationButtons.ElementAt(6).Click();
            Thread.Sleep(5000);
        }

        public string GetActualAddr()
        {
            var _neededLetter = letterSet.ElementAt(1);
            return _neededLetter.GetAttribute("title").ToString();
        }

        public void LogOff()
        {
            var _emailAddressOnTop = new BaseElement(By.XPath("//span[@class='ph-project__user-name svelte-1xjymf4']"));
            _emailAddressOnTop.Click();
            Thread.Sleep(2000);
            accountButtons.ElementAt(3).Click();
            Thread.Sleep(5000);
        }

        public void SendSavedLetter()
        {
            var _neededLetter = letterSet.ElementAt(3);
            _neededLetter.Click();
            Thread.Sleep(2000);
            letterButtons.ElementAt(1).Click();
            Thread.Sleep(5000);
            navigationButtons.ElementAt(5).Click();
            Thread.Sleep(5000);
        }
    }
}
