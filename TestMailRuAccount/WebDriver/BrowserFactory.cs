﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace TestMailRuAccount.WebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
			Chrome,
			Firefox,
			remoteChrome,
			remoteFirefox
		}

        [Obsolete]
        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
			IWebDriver driver = null;

			switch (type)
			{
				case BrowserType.Chrome:
					{
						var service = ChromeDriverService.CreateDefaultService();
						var option = new ChromeOptions();
						option.AddArgument("disable-infobars");
						driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
						break;
					}
				case BrowserType.Firefox:
					{
						var service = FirefoxDriverService.CreateDefaultService();
						var options = new FirefoxOptions();
						driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
						break;
					}
                case BrowserType.remoteChrome:
                    {
                        var option = new ChromeOptions();
						option.AddArgument("disable-infobars");
						option.AddArgument("--no-sandbox");
						driver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), option.ToCapabilities());
                        break;
                    }
                case BrowserType.remoteFirefox:
                    {
						var option = new FirefoxOptions();
						option.AddArgument("disable-infobars");
						option.AddArgument("--no-sandbox");
						driver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), option.ToCapabilities());
						break;
					}
            }
			return driver;
		}
    }
}
