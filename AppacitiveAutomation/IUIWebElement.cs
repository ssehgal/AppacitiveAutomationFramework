using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AppacitiveAutomationFramework
{
    public interface IUIWebElement
    {
        // Summary:
        //     Gets a value indicating whether or not this element is displayed.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     The OpenQA.Selenium.IWebElement.Displayed property avoids the problem of
        //     having to parse an element's "style" attribute to determine visibility of
        //     an element.
        bool Displayed { get; }
        //
        // Summary:
        //     Gets a value indicating whether or not this element is enabled.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     The OpenQA.Selenium.IWebElement.Enabled property will generally return true
        //     for everything except explicitly disabled input elements.
        bool Enabled { get; }
        //
        // Summary:
        //     Gets a System.Drawing.Point object containgin the coordinates of the upper-left
        //     corner of this element relative to the upper-left corner of the page.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        Point Location { get; }
        //
        // Summary:
        //     Gets a value indicating whether or not this element is selected.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     This operation only applies to input elements such as checkboxes, options
        //     in a select element and radio buttons.
        bool Selected { get; }
        //
        // Summary:
        //     Gets a OpenQA.Selenium.IWebElement.Size object containing the height and
        //     width of this element.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        Size Size { get; }
        //
        // Summary:
        //     Gets the tag name of this element.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     The OpenQA.Selenium.IWebElement.TagName property returns the tag name of
        //     the element, not the value of the name attribute. For example, it will return
        //     "input" for an element specifiedby the HTML markup <input name="foo" />.
        string TagName { get; }
        //
        // Summary:
        //     Gets the innerText of this element, without any leading or trailing whitespace,
        //     and with other whitespace collapsed.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        string Text { get; }

        // Summary:
        //     Clears the content of this element.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     If this element is a text entry element, the OpenQA.Selenium.IWebElement.Clear()
        //     method will clear the value. It has no effect on other elements. Text entry
        //     elements are defined as elements with INPUT or TEXTAREA tags.
        void Clear();
        //
        // Summary:
        //     Clicks this element.
        //
        // Exceptions:
        //   OpenQA.Selenium.ElementNotVisibleException:
        //     Thrown when the target element is not visible.
        //
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //      Click this element. If the click causes a new page to load, the OpenQA.Selenium.IWebElement.Click()
        //     method will attempt to block until the page has loaded. After calling the
        //     OpenQA.Selenium.IWebElement.Click() method, you should discard all references
        //     to this element unless you know that the element and the page will still
        //     be present. Otherwise, any further operations performed on this element will
        //     have an undefined.  behavior.
        //     If this element is not clickable, then this operation is ignored. This allows
        //     you to simulate a users to accidentally missing the target when clicking.
        void Click();
        //
        // Summary:
        //     Gets the value of the specified attribute for this element.
        //
        // Parameters:
        //   attributeName:
        //     The name of the attribute.
        //
        // Returns:
        //     The attribute's current value. Returns a null if the value is not set.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     The OpenQA.Selenium.IWebElement.GetAttribute(System.String) method will return
        //     the current value of the attribute, even if the value has been modified after
        //     the page has been loaded. Note that the value of the following attributes
        //     will be returned even if there is no explicit attribute on the element: Attribute
        //     name Value returned if not explicitly specified Valid element types checked
        //     checked Check Box selected selected Options in Select elements disabled disabled
        //     Input and other UI elements
        string GetAttribute(string attributeName);
        //
        // Summary:
        //     Gets the value of a CSS property of this element.
        //
        // Parameters:
        //   propertyName:
        //     The name of the CSS property to get the value of.
        //
        // Returns:
        //     The value of the specified CSS property.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     The value returned by the OpenQA.Selenium.IWebElement.GetCssValue(System.String)
        //     method is likely to be unpredictable in a cross-browser environment. Color
        //     values should be returned as hex strings. For example, a "background-color"
        //     property set as "green" in the HTML source, will return "#008000" for its
        //     value.
        string GetCssValue(string propertyName);
        //
        // Summary:
        //     Simulates typing text into the element.
        //
        // Parameters:
        //   text:
        //     The text to type into the element.
        //
        // Exceptions:
        //   OpenQA.Selenium.InvalidElementStateException:
        //     Thrown when the target element is not enabled.
        //
        //   OpenQA.Selenium.ElementNotVisibleException:
        //     Thrown when the target element is not visible.
        //
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     The text to be typed may include special characters like arrow keys, backspaces,
        //     function keys, and so on. Valid special keys are defined in OpenQA.Selenium.Keys.
        void SendKeys(string text);
        //
        // Summary:
        //     Submits this element to the web server.
        //
        // Exceptions:
        //   OpenQA.Selenium.StaleElementReferenceException:
        //     Thrown when the target element is no longer valid in the document DOM.
        //
        // Remarks:
        //     If this current element is a form, or an element within a form, then this
        //     will be submitted to the web server. If this causes the current page to change,
        //     then this method will block until the new page is loaded.
        void Submit();
        void DoubleClick();
    }
}
