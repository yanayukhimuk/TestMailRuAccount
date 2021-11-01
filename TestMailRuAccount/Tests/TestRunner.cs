using NUnit.Framework;
using TestMailRuAccount.WebObjects;

namespace TestMailRuAccount
{
    public class Tests : BaseTest
    {
        readonly string Login = "jane.black@internet.ru";
        readonly string Password = "CatAndDogs1999";
        string LetterTopic = "Noting special";
        string Message = "Hello!";
        string EmailAddr = "yana.ryzhikova.brest.belarus@gmail.com";


        [Test]
#pragma warning disable CA1041 // Provide ObsoleteAttribute message
        [System.Obsolete]
#pragma warning restore CA1041 // Provide ObsoleteAttribute message
        public void LoginTest()
        {
            HomePage homePage = new();
            homePage.LoginInMailBox(Login, Password);
            homePage.AssertHasLoaded();
        }

        [Test]
#pragma warning disable CA1041 // Provide ObsoleteAttribute message
        [System.Obsolete]
#pragma warning restore CA1041 // Provide ObsoleteAttribute message
        public void EmailDraftTest()
        {
            MailPage mailPage = new();
            HomePage homePage = new();
            homePage.LoginInMailBox(Login, Password);
            homePage.AssertHasLoaded();
            //mailPage.WriteALetter(Message);
            mailPage.SaveLetter();
            mailPage.CloseLetter();
            mailPage.GoToSaved(EmailAddr);
        }

        [Test]
#pragma warning disable CA1041 // Provide ObsoleteAttribute message
        [System.Obsolete]
#pragma warning restore CA1041 // Provide ObsoleteAttribute message
        public void EmailSentTest()
        {
            MailPage mailPage = new();
            HomePage homePage = new();
            homePage.LoginInMailBox(Login, Password);
            homePage.AssertHasLoaded();
            mailPage.GoToSaved(EmailAddr);
            mailPage.SendSavedLetter(EmailAddr);
        }

        [Test]
        [System.Obsolete]
        public void LogOffTest()
        {
            MailPage mailPage = new();
            HomePage homePage = new();
            homePage.LoginInMailBox(Login, Password);
            homePage.AssertHasLoaded();
            mailPage.LogOff();
        }

    }
}