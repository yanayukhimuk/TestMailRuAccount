using NUnit.Framework;
using TestMailRuAccount.WebObjects;
using TestMailRuAccount.Entities;

namespace TestMailRuAccount
{
    public class Tests : BaseTest
    {
        [Test]
#pragma warning disable CA1041 // Provide ObsoleteAttribute message
        [System.Obsolete]
#pragma warning restore CA1041 // Provide ObsoleteAttribute message
        public void LoginTest()
        {
            var User = new User("jane.black@internet.ru", "yana.ryzhikova.brest.belarus@gmail.com", "CatAndDogs1999");

            HomePage homePage = new();
            homePage.LoginInMailBox(User.DataUser[0], User.DataUser[2]);
            homePage.AssertHasLoaded();
        }

        [Test]
#pragma warning disable CA1041 // Provide ObsoleteAttribute message
        [System.Obsolete]
#pragma warning restore CA1041 // Provide ObsoleteAttribute message
        public void EmailDraftTest()
        {
            var User = new User("jane.black@internet.ru", "yana.ryzhikova.brest.belarus@gmail.com", "CatAndDogs1999");
            var Email = new Email("Nothing special", "Hello, Yana! How are you?");
            HomePage homePage = new();
            homePage.LoginInMailBox(User.DataUser[0], User.DataUser[2]);
            homePage.AssertHasLoaded();

            MailPage mailPage = new();
            mailPage.EnterAddrNameAndEmailTopic(Email.EmailContent[0], User.DataUser[1]);
            //mailPage.WriteALetter(Email.EmailContent[1]);
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
            var User = new User("jane.black@internet.ru", "yana.ryzhikova.brest.belarus@gmail.com", "CatAndDogs1999");
            MailPage mailPage = new();
            HomePage homePage = new();
            homePage.LoginInMailBox(User.DataUser[0], User.DataUser[2]);
            homePage.AssertHasLoaded();
            mailPage.GoToSaved();
            mailPage.SendSavedLetter(User.DataUser[1]);
        }

        [Test]
        [System.Obsolete]
        public void LogOffTest()
        {
            var User = new User("jane.black@internet.ru", "yana.ryzhikova.brest.belarus@gmail.com", "CatAndDogs1999");
            HomePage homePage = new();
            homePage.LoginInMailBox(User.DataUser[0], User.DataUser[2]);
            homePage.AssertHasLoaded();
            MailPage mailPage = new();
            mailPage.LogOff();
        }

    }
}