using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestMailRuAccount.WebObjects
{
    public class BasePage
    {
        protected By _titlelocator;
        protected string _title;
        public static string _titleForm;

        protected BasePage (By TitleLocator, string title)
        {
            _titlelocator = TitleLocator;
            _title = _titleForm = title;
            AssertIsOpen();
        }

        private void AssertIsOpen()
        {
            var label = new BaseElement(_titlelocator, _title);
            label.WaitForIsVisible();
        }
    }
}
