using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace AppacitiveAutomationFramework
{
    public class UIControlCollection
    {
        internal List<UIControlSet> Controls = new List<UIControlSet>();
        internal IWebDriver Driver;
        internal ISearchContext Context;

        public IUIWebElement GetUIElementBySelector(string controlName)
        {
            IWebElement toReturn = null;
            Exception e = null;
            Controls.ForEach(x =>
            {
                if (x[controlName] != null)
                {
                    for (var i = 0; i < 10; i = i + 1)
                    {
                        try
                        {
                            LogProvider.DefaultLogger.Log("Looking for: " + controlName);
                            toReturn = Context.FindElement(By.CssSelector(x[controlName]));
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
            element.Driver = Driver;
            element.Controls = Controls;
            element.Context = element;
            return element;
        }


        public IUIWebElement WaitAndGetBySelector(string controlName, int timeInSeconds)
        {
            LogProvider.DefaultLogger.Log("Started waiting for " + controlName + " for maximum " + timeInSeconds + " sec");

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
                    LogProvider.DefaultLogger.Log("Element not present yet.");
                    numChecksDone++;
                }
                else
                {
                    LogProvider.DefaultLogger.Log("Got element.");
                    return _uiElement;
                }
                System.Threading.Thread.Sleep(1000);
            }
            return null;
        }


        public IUIWebElement MatchByPartialLinkText(string textToMatch)
        {
            IWebElement toReturn = null;
            Exception e = null;
            System.Threading.Thread.Sleep(2000);
            
                        try
                        {
                            LogProvider.DefaultLogger.Log("Looking for: " + textToMatch);
                            toReturn = Context.FindElement(By.PartialLinkText(textToMatch));
                            if (toReturn != null)
                            {
                                LogProvider.DefaultLogger.Log("Got " + textToMatch);
                            }
                        }
                        catch (Exception e1)
                        {
                            LogProvider.DefaultLogger.Log("Could not get " + textToMatch);
                            e = e1;
                        }
            if (toReturn == null) return null;
            var element = new UIElement(toReturn, textToMatch);
            element.Driver = Driver;
            element.Context = element;
            element.Controls = Controls;
            System.Threading.Thread.Sleep(2000);
            return element;
        }

        public IUIWebElement GetUIElementById(string controlName)
        {
            IWebElement toReturn = null;
            Exception e = null;
            System.Threading.Thread.Sleep(2000);
            Controls.ForEach(x =>
            {
                if (x[controlName] != null)
                {
                    for (var i = 0; i < 10; i = i + 1)
                    {
                        try
                        {
                            LogProvider.DefaultLogger.Log("Looking for: " + controlName);
                            toReturn = Context.FindElement(By.Id(x[controlName]));
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
            element.Driver = Driver;
            element.Context = element;
            element.Controls = Controls;
            System.Threading.Thread.Sleep(2000);
            return element;
        }

        //Change windows using title

        public Dictionary<string, string> ReturnWindowHandlesWithTitles()
        {
            System.Threading.Thread.Sleep(2000);
            Dictionary<string, string> handleTitleDictionary = new Dictionary<string, string>();
            for (int i = 0; i < Driver.WindowHandles.Count; i++)
            {
                Driver.SwitchTo().Window(Driver.WindowHandles[i]);
                handleTitleDictionary.Add(Driver.Title, Driver.WindowHandles[i]);
            }
            return handleTitleDictionary;
        }

        public void ChangeCurrentWindow(string title)
        {
            System.Threading.Thread.Sleep(2000);
            var dict = ReturnWindowHandlesWithTitles();
            string windowHandle;
            if (dict.TryGetValue(title, out windowHandle))
            {
                Driver.SwitchTo().Window(windowHandle);
            }
            else
            {
                throw new NoSuchWindowException();
            }
        }

        //Change window using index/windowhandle

        public List<string> ReturnWindowHandles()
        {
            System.Threading.Thread.Sleep(2000);
            string handle;
            var handleList=new List<string>();
            for (int i = 0; i < Driver.WindowHandles.Count; i++)
            {
                handle = Driver.WindowHandles[i];
                handleList.Add(handle);
                handle="";
            }
            return handleList;
        }

        public void ChangeCurrentWindowUsingIndex(string windowHandle)
        {
            Driver.SwitchTo().Window(windowHandle);
        }


        public List<IUIWebElement> GetUIElements(string controlName)
        {
            var list = new List<IWebElement>();
            Exception e = null;
            System.Threading.Thread.Sleep(1000);
            Controls.ForEach(x =>
            {
                if (x[controlName] != null)
                {
                    for (var i = 0; i < 10; i = i + 1)
                    {
                        try
                        {
                            LogProvider.DefaultLogger.Log("Trying to get " + controlName);
                            list = Context.FindElements(By.CssSelector(x[controlName])).ToList();
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
                element.Driver = Driver;
                element.Context = element;
                element.Controls = Controls;
                resultList.Add(element);
            }
            System.Threading.Thread.Sleep(1000);
            return resultList;
        }
    }
}
