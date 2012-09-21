using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AppacitiveAutomationFramework
{
    public class UIElement : IWebElement, IUIWebElement
    {
        private IWebElement _element;
        internal IWebDriver Driver { get; set; }
        public UIElement(IWebElement element)
        {
            _element = element;
        }

        public void Clear()
        {
            _element.Clear();
        }

        public void Click()
        {
            Actions builder = new Actions(Driver);
            // WebElement tagElement = driver.findElement(By.id("tag-cloud"));
            builder.MoveToElement(this._element).Click(this._element).Build().Perform();
           // _element.Click();
        }

        public void DoubleClick()
        {
            Actions action = new Actions(Driver);
            action.DoubleClick(this).Build().Perform();

        }

        public void MoveToElement()
        {
            Actions builder = new Actions(Driver);
           // WebElement tagElement = driver.findElement(By.id("tag-cloud"));
            builder.MoveToElement(this._element).Build().Perform();
            
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
