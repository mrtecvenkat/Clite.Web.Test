using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using Auto.Test.Tool.Core;
using Auto.Test.ReportHelpers;

namespace Auto.Test.Tool.ActionHelpers
{
    public class UIReadHelper : DriverManager
    {
        public static IWebElement GetVisibleElement(By locator)
        {
            try
            {
                var elements = driver.FindElements(locator).Where(x => x.Displayed);
                if (elements.Count() == 0)
                    return null;
                else
                    return elements.ElementAt(0);
            }
            catch (Exception ex)
            {
                Reporter.LogDebugMassage("GetVisibleElement: " + ex.Message);
                return null;
            }
        }
    }
}
