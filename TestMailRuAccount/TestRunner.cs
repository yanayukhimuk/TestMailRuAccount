using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TestMailRuAccount
{
    public class Tests
    {
        IWebDriver webDriver;
        string NeededUrl = "https://mail.ru/";

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
            //Arrange
            IWebElement MailBoxLogin = webDriver.FindElement(By.XPath("//input[@class='email-input svelte-1tib0qz']"));
            IWebElement MailBoxPass = webDriver.FindElement(By.XPath("//input[@class='password-input svelte-1tib0qz']"));

            //Act
            MailBoxLogin.Click();
            MailBoxLogin.SendKeys("jane.black@internet.ru");
            webDriver.FindElement(By.XPath("//button[@class='button svelte-1tib0qz']")).Click();

            Thread.Sleep(2000);

            MailBoxPass.Click();
            MailBoxPass.SendKeys("CatAndDogs1999");
            webDriver.FindElement(By.XPath("//button[@class='second-button svelte-1tib0qz']")).Click();
            Thread.Sleep(10000);

            //Assert
            Assert.That(webDriver.FindElement(By.XPath("//div[@class='portal-menu js-shortcut']")).Displayed);

        }

        [Test]
        public void EmailDraftTest()
        {
            //Arrange
            IWebElement MailBoxLogin = webDriver.FindElement(By.XPath("//input[@class='email-input svelte-1tib0qz']"));
            IWebElement MailBoxPass = webDriver.FindElement(By.XPath("//input[@class='password-input svelte-1tib0qz']"));

            //Act
            MailBoxLogin.Click();
            MailBoxLogin.SendKeys("jane.black@internet.ru");
            webDriver.FindElement(By.XPath("//button[@class='button svelte-1tib0qz']")).Click();

            Thread.Sleep(2000);

            MailBoxPass.Click();
            MailBoxPass.SendKeys("CatAndDogs1999");
            webDriver.FindElement(By.XPath("//button[@class='second-button svelte-1tib0qz']")).Click();
            Thread.Sleep(10000);

            webDriver.FindElement(By.XPath("//span[@class='compose-button__txt']")).Click();
            Thread.Sleep(2000);

            IWebElement AddrName = webDriver.FindElements(By.XPath("//input[@class='container--H9L5q size_s--3_M-_']"))[0];
            AddrName.Click();
            AddrName.SendKeys("yana.ryzhikova.brest.belarus@gmail.com");

            IWebElement EmailTopic = webDriver.FindElements(By.XPath("//input[@class='container--H9L5q size_s--3_M-_']"))[1];
            EmailTopic.Click();
            EmailTopic.SendKeys("Nothing special");

            //IWebElement EmailBody = webDriver.FindElement(By.XPath("//div[@class='editable-wqlr cke_editable cke_editable_inline cke_contents_true cke_show_borders']"));
            //EmailBody.Click();
            //EmailBody.SendKeys("Hello, Yana!");

            webDriver.FindElements(By.XPath("//span[@class='button2__txt']"))[3].Click();
            webDriver.FindElements(By.XPath("//div[@class='container--1HmQy']"))[4].Click();

            webDriver.FindElements(By.XPath("//div[@class='nav__folder-name__txt']"))[7].Click();

            //Assert.That(webDriver.FindElements(By.XPath("//span[@class='ll-sj__normal']"))[0].Displayed;

        }

        [TearDown]
        public void CloseBrowser()
        {
            //webDriver.Close();
        }
    }
}