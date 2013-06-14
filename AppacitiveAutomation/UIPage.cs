using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EnvDTE;
using System.Threading;

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
            System.Threading.Thread.Sleep(1000);
                _controls.ForEach(x =>
                {
                    if (x[controlName] != null)
                    {
                        for (var i = 0; i < 10; i = i + 1)
                        {
                            try
                            {
                                LogProvider.DefaultLogger.Log("Looking for: " + controlName);
                                toReturn = _driver.FindElement(By.CssSelector(x[controlName]));
                                if (toReturn != null)
                                {
                                    LogProvider.DefaultLogger.Log("Got " + controlName);
                                    break;
                                }
                            }
                            catch (Exception e1)
                            {
                                LogProvider.DefaultLogger.Log("Could not get " + controlName);
                                e = e1;
                            }
                        }
                    }
                });
            
            if (toReturn == null) return null;
            var element = new UIElement(toReturn, controlName);
            element.Driver = _driver;
            System.Threading.Thread.Sleep(1000);
            return element;
        }


        protected IUIWebElement WaitAndGetBySelector(string controlName, int timeInSeconds)
        {
            LogProvider.DefaultLogger.Log("Started waiting for " + controlName + " for maximum " + timeInSeconds + " sec");

            // wait in 500ms intervals for the element to appear
            // the number of checks we have to perform
            var numChecks = timeInSeconds * 1000 / 500;
            System.Threading.Thread.Sleep(2000);
            // the number of checks completed
            var numChecksDone = 0;

            while (numChecksDone < numChecks)
            {
                var _uiElement = GetUIElementBySelector(controlName);
                if (_uiElement == null)
                {
                    LogProvider.DefaultLogger.Log("Element not present yet.");
                    numChecksDone++;
                }
                else
                {
                    LogProvider.DefaultLogger.Log("Got element.");
                    return _uiElement;
                }
                System.Threading.Thread.Sleep(500);
            }
            System.Threading.Thread.Sleep(2000);
            return null;
        }

        protected IUIWebElement GetUIElementById(string controlName)
        {
            IWebElement toReturn = null;
            Exception e = null;
            System.Threading.Thread.Sleep(2000);
            _controls.ForEach(x =>
            {
                if (x[controlName] != null)
                {
                    for (var i = 0; i < 10; i = i + 1)
                    {
                        try
                        {
                            LogProvider.DefaultLogger.Log("Looking for: " + controlName);
                            toReturn = _driver.FindElement(By.Id(x[controlName]));
                            if (toReturn != null)
                            {
                                LogProvider.DefaultLogger.Log("Got " + controlName);
                                break;
                            }
                        }
                        catch (Exception e1)
                        {
                            LogProvider.DefaultLogger.Log("Could not get " + controlName);
                            e = e1;
                        }
                    }
                }
            });
            if (toReturn == null) return null;
            var element = new UIElement(toReturn, controlName);
            element.Driver = _driver;
            System.Threading.Thread.Sleep(2000);
            return element;
        }
        protected List<IUIWebElement> GetUIElements(string controlName)
        {
            var list = new List<IWebElement>();
            Exception e = null;
            System.Threading.Thread.Sleep(1000);
            _controls.ForEach(x =>
            {
                if (x[controlName] != null)
                {
                    for (var i = 0; i < 10; i = i + 1)
                    {
                        try
                        {
                            LogProvider.DefaultLogger.Log("Trying to get " + controlName);
                            list = _driver.FindElements(By.CssSelector(x[controlName])).ToList();
                            if (list != null)
                            {
                                LogProvider.DefaultLogger.Log("Got " + controlName);
                                break;
                            }
                        }
                        catch (Exception e1)
                        {
                            LogProvider.DefaultLogger.Log("Could not get " + controlName);
                            e = e1;
                        }
                    }
                }
            });



            // create an empty list of IUIWebElements (eg 'resultList')
            // iterate over the list of IWebElements ('list')
            // for each element of 'list', create an element of IUIWebElement and add to resultList
            // return resultList
            if (list == null) return null;
            var resultList = new List<IUIWebElement>();
            for (var i = 0; i < list.Count; i++)
            {
                var element = new UIElement(list[i], controlName);
                element.Driver = _driver;
                resultList.Add(element);
            }
            System.Threading.Thread.Sleep(1000);
            return resultList;
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
