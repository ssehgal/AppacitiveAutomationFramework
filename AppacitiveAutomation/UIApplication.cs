using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AppacitiveAutomationFramework
{
    public abstract class UIApplication : IDisposable
    {
        protected IWebDriver Driver;

        public UIApplication()
        {
            switch (Configuration.Runner.ToLower())
            {
                case "local":
                    Driver = DriverProvider.GetDriver(Configuration.Driver);
                    break;
                case "grid":
                    //var selenium = new DefaultSelenium(Configuration.HubHost, Configuration.HubPort, GetBrowserString(Configuration.Driver), Configuration.BrowserUrl);
                    Driver = new RemoteWebDriver(Configuration.GetRemoteAddress(Configuration.HubHost, Configuration.HubPort), Configuration.GetDesiredCapability(Configuration.Driver));
                    break;
                default:
                    throw new Exception("Unrecognized test runner");
            }
        }

        protected T InitializePage<T>(params string[] controlNames) where T : UIPage, new()
        {
            // create new instance
            var page = new T();

            // load up the controls
            page.LoadControls(controlNames);

            // set the driver
            page.SetDriver(Driver);

            // return the created page
            return page as T;
        }

        public void Launch(string url)
        {
            Driver.Manage().Window.Maximize();
            Driver.Url = url;
        }

        public void Dispose()
        {
            Driver.Quit();
        }

    }


}
