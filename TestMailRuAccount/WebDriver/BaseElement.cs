using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using TestMailRuAccount.WebDriver;

namespace TestMailRuAccount.WebObjects
{
    public class BaseElement : IWebElement
    {
		protected string Name;
		protected By Locator;
		protected IWebElement Element;

        [Obsolete]
        public BaseElement(By locator, string name)
		{
			Locator = locator;
			Name = name == "" ? GetText() : name;
		}

		public BaseElement(By locator)
		{
			Locator = locator;
		}

        [Obsolete]
        public string GetText()
		{
			WaitForIsVisible();
			return Element.Text;
		}

		public IWebElement GetElement()
		{
			try
			{
				Element = Browser.GetDriver().FindElement(Locator);
			}
			catch (Exception)
			{

				throw;
			}
			return Element;
		}

		public void WaitForIsVisible()
        {
			var driver = Browser.GetDriver();
			_ = new WebDriverWait(driver, TimeSpan.FromSeconds(Browser.TimeoutForElement)).Until(driver => driver.FindElement(Locator).Displayed);
        }

		public void WaitForIsClickable()
        {
			var driver = Browser.GetDriver();
			_ = new WebDriverWait(driver, TimeSpan.FromSeconds(Browser.TimeoutForElement)).Until(driver => driver.FindElement(Locator).Enabled);

		}
        public IWebElement FindElement(By @by)
		{
			Element = Browser.GetDriver().FindElement(Locator);
			return Element;
		}

		public ReadOnlyCollection<IWebElement> FindElements(By @by) 
		{
            if (by is null)
            {
                throw new ArgumentNullException(nameof(by));
            }

            Element = Browser.GetDriver().FindElement(Locator);
			ReadOnlyCollection<IWebElement> collection = Element as ReadOnlyCollection<IWebElement>;
			return collection;
		}

		public void Clear()
		{
			throw new System.NotImplementedException();
		}

        [Obsolete]
        public void SendKeys(string text) //ругается тут - Element is not interactable 
		{
			WaitForIsVisible();
			Browser.GetDriver().FindElement(Locator).SendKeys(text);
		}

        [Obsolete]
        public void JsSendKeys(string text)
        {
			WaitForIsVisible();
			IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
			executor.ExecuteScript("arguments[0].sendKeys();", this.GetElement());
		}

		public void Submit()
		{
			throw new System.NotImplementedException();
		}

        [Obsolete]
        public void Click()
		{
			WaitForIsVisible();
			Browser.GetDriver().FindElement(Locator).Click();
		}

        [Obsolete]
        public void JsClick()
		{
			WaitForIsVisible();
			IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
			executor.ExecuteScript("arguments[0].click();", this.GetElement());
		}

		public string GetAttribute(string attributeName)
		{
			throw new System.NotImplementedException();
		}

		public string GetCssValue(string propertyName)
		{
			throw new System.NotImplementedException();
		}

		public string GetProperty(string propertyName)
		{
			throw new NotImplementedException();
		}

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public string TagName { get; }
		public string Text { get; }
		public bool Enabled { get; }
		public bool Selected { get; }
		public Point Location { get; }
		public Size Size { get; }
		public bool Displayed { get; }
        public object ExpectedConditions { get; private set; }
    }
}
