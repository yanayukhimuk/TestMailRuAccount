using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestMailRuAccount.WebObjects
{
    public class BasePage
    {
        protected By Titlelocator;
        protected string Title;
        public static string TitleForm;

        [Obsolete]
        protected BasePage (By TitleLocator, string title)
        {
            Titlelocator = TitleLocator;
            Title = TitleForm = title;
            AssertIsOpen();
        }

        [Obsolete]
        private void AssertIsOpen()
        {
            var label = new BaseElement(Titlelocator, Title);
            label.WaitForIsVisible();
        }
    }
}
