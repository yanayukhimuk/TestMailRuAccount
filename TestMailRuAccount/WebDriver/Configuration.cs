using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TestMailRuAccount.WebDriver
{
    public class Configuration
    {
        public static string GetEnvironmentVar (string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnvironmentVar("ElementTimeout", "50");

        public static string Browser => GetEnvironmentVar("Browser", "Chrome");

        public static string StartUrl => GetEnvironmentVar("StartUrl", "https://mail.ru/");
    }
}
