using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace AppacitiveAutomationFramework
{
    public enum AvailableDrivers
    {
        Firefox,
        Chrome
    }

    internal static class DriverProvider
    {
        public static IWebDriver GetDriver(AvailableDrivers driverType)
        {
            switch (driverType)
            {
                case AvailableDrivers.Firefox:
                    return Firefox;
                case AvailableDrivers.Chrome:
                    return Chrome;
                default:
                    throw new Exception("Unrecognized driver type: " + driverType.ToString());
            }
        }

        private static IWebDriver Firefox
        {
            get { return new FirefoxDriver(); }
        }

        private static IWebDriver Chrome
        {
            get { return new ChromeDriver(); }
        }
    }
}
