using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace AppacitiveAutomationFramework
{
    public static class UIKeys
    {
        public static string GetSpecialKey(string keyName)
        {
            return (string)(typeof(Keys).GetFields().Where(key =>
            {
                return key.Name.ToLowerInvariant() == keyName.ToLowerInvariant();
            }).First().GetValue(null));
        }
    }
}
