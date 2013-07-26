using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AppacitiveAutomationFramework
{
    public class UIElement : UIControlCollection, IWebElement, IUIWebElement
    {
        private IWebElement _element;
        private string _controlName = string.Empty;
        public UIElement(IWebElement element)
        {
            _element = element;
        }

        public UIElement(IWebElement element, string controlName)
        {
            _element = element;
            _controlName = controlName;
        }

        public void Clear()
        {
            _element.Clear();
        }

        public void Click()
        {
            LogProvider.DefaultLogger.Log("Going to click on " + _controlName);
            Actions builder = new Actions(Driver);
            // WebElement tagElement = driver.findElement(By.id("tag-cloud"));
            builder.MoveToElement(this._element).Click(this._element).Build().Perform();
            LogProvider.DefaultLogger.Log("Clicked successfully on " + _controlName);
           // _element.Click();
        }


        public void DoubleClick()
        {
            LogProvider.DefaultLogger.Log("Going to double-click on " + _controlName);
            Actions action = new Actions(Driver);
            action.DoubleClick(this).Build().Perform();
            LogProvider.DefaultLogger.Log("Double clicked successfully on" + _controlName);

        }


        public void MoveToElement()
        {
            Actions builder = new Actions(Driver);
           // WebElement tagElement = driver.findElement(By.id("tag-cloud"));
            builder.MoveToElement(this._element).Build().Perform();
            
        }

        public void SelectFromDropDown(string value)
        {
            LogProvider.DefaultLogger.Log("Goint to select " + value + " from " + _controlName);
            SelectElement select = new SelectElement(this._element);
            //select.DeselectAll();
            select.SelectByText(value);
            LogProvider.DefaultLogger.Log("Successfully selected " + value + " from " + _controlName);
        }

        public bool Displayed
        {
            get { return _element.Displayed; }
        }

        public bool Enabled
        {
            get { return _element.Enabled; }
        }

        public string GetAttribute(string attributeName)
        {
            return _element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return _element.GetCssValue(propertyName);
        }

        public System.Drawing.Point Location
        {
            get { return _element.Location; }
        }

        public bool Selected
        {
            get { return _element.Selected; }
        }

        public void SendKeys(string text)
        {
            _element.SendKeys(text);
        }

        public System.Drawing.Size Size
        {
            get { return _element.Size; }
        }

        public void Submit()
        {
            _element.Submit();
        }

        public string TagName
        {
            get { return _element.TagName; }
        }

        public string Text
        {
            get { return _element.Text; }
        }

        public IWebElement FindElement(By by)
        {
            return _element.FindElement(by);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _element.FindElements(by);
        }
    }
}
