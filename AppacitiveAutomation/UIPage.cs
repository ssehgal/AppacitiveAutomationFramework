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
    public abstract class UIPage : UIControlCollection
    {
        // contains behaviour like clickonloginbutton etc
        // internally holds reference(s) to the controls' data file.

        private List<UIControlSet> _controls = new List<UIControlSet>();
        private UIControlCollection _controlCollection = new UIControlCollection();

        public UIPage LoadControls(params string[] controlFiles)
        {
            controlFiles.ToList().ForEach(x => _controls.Add(new UIControlSet(x)));
            this.Controls = _controls;
            return this;
        }

        public void SetDriver(IWebDriver driver)
        {
            this.Driver = driver;
            this.Context = driver;
        }

        public void ExecuteJavascript(string js)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript(js);
        }

    }
}
