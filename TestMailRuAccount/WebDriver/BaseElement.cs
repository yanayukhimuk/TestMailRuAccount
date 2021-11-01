using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
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
			this.Locator = locator;
			this.Name = name == "" ? GetText() : name;
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

        [Obsolete]
        public void WaitForIsVisible() => _ = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Browser.TimeoutForElement)).Until(c => c.FindElement(Locator));

        public IWebElement FindElement(By @by)
		{
			throw new System.NotImplementedException();
		}

		public ReadOnlyCollection<IWebElement> FindElements(By @by)
		{
			throw new System.NotImplementedException();
		}

		public void Clear()
		{
			throw new System.NotImplementedException();
		}

        [Obsolete]
        public void SendKeys(string text)
		{
			WaitForIsVisible();
			Browser.GetDriver().FindElement(Locator).SendKeys(text);
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
