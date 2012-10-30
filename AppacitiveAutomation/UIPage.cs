using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EnvDTE;

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
                            if (toReturn != null)
                                break;
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

        protected IUIWebElement WaitAndGetBySelector(string controlName, int timeInSeconds)
        {
            // wait in 500ms intervals for the element to appear
            // the number of checks we have to perform
            var numChecks = timeInSeconds * 1000 / 500;
            
            // the number of checks completed
            var numChecksDone = 0;

            while (numChecksDone < numChecks)
            {
                var _uiElement = GetUIElementBySelector(controlName);
                if (_uiElement == null)
                {
                    numChecksDone++;
                }
                else
                {
                    return _uiElement;
                }
                System.Threading.Thread.Sleep(500);
            }
            return null;
        }

        protected IUIWebElement WaitAndGetBySelector2(string controlName, int time)
        {
            IWebElement toReturn = null;
            _controls.ForEach(x =>
            {
                if (x[controlName] != null)
                {
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(time));
                    wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                    toReturn = wait.Until<IWebElement>((d) =>
                    {
                        try
                        {
                            d.FindElement(By.CssSelector(x[controlName]));
                            return d.FindElement(By.CssSelector(x[controlName]));
                        }
                        catch
                        {
                            return null;
                        }
                    });

                }
            });
            if (toReturn == null) return null;
            var element = new UIElement(toReturn);
            element.Driver = _driver;
            return element;
        }

        protected IUIWebElement GetUIElementById(string controlName)
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
                            toReturn = _driver.FindElement(By.Id(x[controlName]));
                        }
                        catch (Exception e1)
                        {
                            Console.WriteLine("could not get id of element");
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
        protected List<IUIWebElement> GetUIElements(string controlName)
        {
            var list = new List<IWebElement>();
            Exception e = null;
            _controls.ForEach(x =>
            {
                if (x[controlName] != null)
                {
                    for (var i = 0; i < 10; i = i + 1)
                    {
                        try
                        {
                            list = _driver.FindElements(By.CssSelector(x[controlName])).ToList();
                        }
                        catch (Exception e1)
                        {
                            Console.WriteLine("could not get element");
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
                var element = new UIElement(list[i]);
                element.Driver = _driver;
                resultList.Add(element);
            }
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
