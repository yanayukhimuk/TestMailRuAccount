using NUnit.Framework;
using TestMailRuAccount.WebDriver;

namespace TestMailRuAccount
{
    public class BaseTest
	{
        [System.Obsolete]
        protected static Browser Browser = Browser.Instance;

		[SetUp]
        [System.Obsolete]
        public virtual void InitTest()
		{
			Browser = Browser.Instance;
			Browser.WindowMaximise();
			Browser.NavigateTo(Configuration.StartUrl);
		}

		[TearDown]
		public virtual void CleanTest()
		{
			Browser.Quit();
		}
	}
}
