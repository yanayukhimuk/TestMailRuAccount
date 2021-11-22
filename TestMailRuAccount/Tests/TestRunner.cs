using NUnit.Framework;
using TestMailRuAccount.WebObjects;

namespace TestMailRuAccount
{
    public class Tests : BaseTest
    {
        readonly string Login = "jane.black@internet.ru";
        readonly string Password = "CatAndDogs1999";
        string LetterTopic = "Nothing special";
        const string Message = "Hello, Yana! How are you?";
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
            HomePage homePage = new();
            homePage.LoginInMailBox(Login, Password);
            homePage.AssertHasLoaded();

            MailPage mailPage = new();
            mailPage.EnterAddrNameAndEmailTopic(LetterTopic, EmailAddr);
            //mailPage.WriteALetter(Message);
            mailPage.SaveLetter();
            mailPage.CloseLetter();
            mailPage.GoToSaved();
            mailPage.IfIsPresentAsDraft();
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
            mailPage.GoToSaved();
            mailPage.SendSavedLetter(EmailAddr);
        }

        [Test]
        [System.Obsolete]
        public void LogOffTest()
        {
            HomePage homePage = new();
            homePage.LoginInMailBox(Login, Password);
            homePage.AssertHasLoaded();
            MailPage mailPage = new();
            mailPage.LogOff();
        }

    }
}