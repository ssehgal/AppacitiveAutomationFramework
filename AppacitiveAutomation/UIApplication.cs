using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AppacitiveAutomationFramework
{
    public abstract class UIApplication : IDisposable
    {
        protected IWebDriver _driver;

        protected abstract AvailableDrivers DriverType { get; }

        public UIApplication()
        {
            _driver = DriverProvider.GetDriver(DriverType);
        }

        protected T InitializePage<T>(params string[] controlNames) where T : UIPage, new()
        {
            // create new instance
            var page = new T();

            // load up the controls
            page.LoadControls(controlNames);

            // set the driver
            page.SetDriver(_driver);

            // return the created page
            return page as T;
        }

        public void Launch(string url)
        {
            _driver.Manage().Window.Maximize();
            _driver.Url = url;
        }

        public void Dispose()
        {
            _driver.Quit();
        }

    }

    
}
