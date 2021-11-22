using OpenQA.Selenium;
using System;

namespace TestMailRuAccount.WebDriver
{
    public class Browser
    {
		private static Browser CurrentInstane;
		private static IWebDriver Driver;
        public static BrowserFactory.BrowserType CurrentBrowser;
		public static int ImplWait;
		public static double TimeoutForElement;
		private static string newBrowser;

        [Obsolete]
        public Browser()
		{
			InitParamas();
			Driver = BrowserFactory.GetDriver(CurrentBrowser, ImplWait);
		}

		public static void InitParamas()
		{
			ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
			TimeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
			newBrowser = Configuration.Browser;
            _ = Enum.TryParse(newBrowser, out CurrentBrowser);
		}

        [Obsolete]
        public static Browser Instance => CurrentInstane ?? (CurrentInstane = new Browser());

		public static void WindowMaximise()
		{
			Driver.Manage().Window.Maximize();
		}

		public static void NavigateTo(string url)
		{
			Driver.Navigate().GoToUrl(url);
		}

		public static IWebDriver GetDriver()
		{
			return Driver;
		}

		public static void Quit()
		{
			Driver.Quit();
			CurrentInstane = null;
			Driver = null;
			newBrowser = null;
		}
	}
}
