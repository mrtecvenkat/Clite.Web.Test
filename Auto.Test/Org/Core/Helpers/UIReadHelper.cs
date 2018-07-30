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
using Auto.Test.Org.Core.Driver;

namespace Auto.Test.Tool.ActionHelpers
{
    public class UIReadHelper : DriverManager
    {
        private static int maxTimeOuts = 90;
        private static int counter = 0;
        public static IWebElement GetVisibleElement(By locator)
        {
            try
            {
                var elements = driver.FindElements(locator).Where(x => x.Displayed);
                if (elements.Count() == 0)
                {
                    if (counter < maxTimeOuts)
                    {
                        counter++;
                        return GetVisibleElement(locator);
                    }
                    else
                        return null;
                }
                else
                {
                    counter = 0;
                    return elements.ElementAt(0);
                }

            }
            catch (Exception ex)
            {
                Reporter.LogErrorMassage("Unable to find element : " + locator + " and Error:\n" + ex.Message);
                return null;
            }
        }
    }
}
