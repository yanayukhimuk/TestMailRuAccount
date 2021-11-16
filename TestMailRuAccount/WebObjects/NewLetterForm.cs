using OpenQA.Selenium;
using TestMailRuAccount.WebDriver;

namespace TestMailRuAccount.WebObjects
{
    public class NewLetterForm : BaseForm
    {
		private static readonly By newLetterLbl = By.XPath("//div[@class='scrollview--SiHhk scrollview_main--3Vfg9']");

        [System.Obsolete]
        public NewLetterForm() : base(newLetterLbl, "New Letter Page")
		{
            _ = Browser.GetDriver().CurrentWindowHandle;
		}

		
	}
}
