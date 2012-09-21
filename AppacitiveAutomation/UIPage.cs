using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace AppacitiveAutomationFramework
{
    public abstract class UIPage
    {
        // contains behaviour like clickonloginbutton etc
        // internally holds reference(s) to the controls' data file.

        private List<UIControlSet> _controls = new List<UIControlSet>();
        private IWebDriver _driver;

        public UIPage LoadControls(params string[] controlFiles)
        {
            controlFiles.ToList().ForEach(x => _controls.Add(new UIControlSet(x)));
            return this;
        }

        protected IUIWebElement GetUIElementBySelector(string controlName)
        {
            IWebElement toReturn = null;
            Exception e = null;
            _controls.ForEach(x =>
            {
                if (x[controlName] != null)
                {
                    for (var i = 0; i < 10; i = i + 1)
                    {
                        try
                        {
                            toReturn = _driver.FindElement(By.CssSelector(x[controlName]));
                        }
                        catch (Exception e1)
                        {
                            Console.WriteLine("could not get element");
                            e = e1;
                        }
                    }
                }
            });
            if (toReturn == null) return null;
            var element = new UIElement(toReturn);
            element.Driver = _driver;
            return element;
        }

        //protected IUIWebElement TryGetElementBySelector(string controlName)
        //{
        //    try
        //    {
        //        return GetUIElementBySelector(controlName);
        //    }
        //    catch { return null; }
        //}

        public void SetDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ExecuteJavascript(string js)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript(js);
        }
    }
}
