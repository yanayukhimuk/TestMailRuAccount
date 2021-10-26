using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TestMailRuAccount.WebObjects;

namespace TestMailRuAccount
{
    public class Tests
    {
        IWebDriver webDriver;
        string NeededUrl = "https://mail.ru/";
        string Login = "jane.black@internet.ru";
        string Password = "CatAndDogs1999";
        string LetterTopic = "Noting special";
        string Message = "Hello!";
        string EmailAddr = "yana.ryzhikova.brest.belarus@gmail.com";

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(NeededUrl);
            webDriver.Manage().Window.Maximize();
        }
        [Test]
        public void LoginTest()
        {
            HomePage homePage = new HomePage();

            homePage.LoginInMailBox(Login, Password);

            Assert.That(webDriver.FindElement(By.XPath("//div[@class='portal-menu js-shortcut']")).Displayed);

        }

        [Test]
        public void EmailDraftTest()
        {

            HomePage homePage = new HomePage();
            MailPage mailPage = new MailPage();

            homePage.LoginInMailBox(Login, Password);

            mailPage.EnterAddrNameAndEmailTopic(LetterTopic, EmailAddr);

            //mailPage.WriteALetter(Message);

            mailPage.SaveLetter();
            mailPage.CloseLetter();
            mailPage.GoToSaved();

            Assert.AreEqual(EmailAddr, mailPage.GetActualAddr());

        }

        [Test]

        public void EmailSentTest()
        {
            HomePage homePage = new HomePage();
            MailPage mailPage = new MailPage();

            homePage.LoginInMailBox(Login, Password);
            mailPage.GoToSaved();
            mailPage.SendSavedLetter();

            Assert.AreEqual(EmailAddr, mailPage.GetActualAddr());
        }

        [Test]

        public void LogOffTest()
        {
            HomePage homePage = new HomePage();
            MailPage mailPage = new MailPage();

            homePage.LoginInMailBox(Login, Password);

            mailPage.LogOff();

            Assert.That(webDriver.FindElement(By.XPath("//button[@class='ph-login svelte-1xjymf4']")).Displayed);

        }
        [TearDown]
        public void CloseBrowser()
        {
            webDriver.Close();
        }
    }
}