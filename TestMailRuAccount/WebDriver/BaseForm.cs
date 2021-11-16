using OpenQA.Selenium;
using TestMailRuAccount.WebObjects;

namespace TestMailRuAccount.WebDriver
{
    public class BaseForm
    {
		protected By TitleLocator;
		protected string title;
		public static string titleForm;

        [System.Obsolete]
        protected BaseForm(By TitleLocator, string title)
		{
			this.TitleLocator = TitleLocator;
			this.title = titleForm = title;
			AssertIsOpen();
		}

        [System.Obsolete]
        public void AssertIsOpen()
		{
			var label = new BaseElement(TitleLocator, title);
			label.WaitForIsVisible();
		}
	}
}
