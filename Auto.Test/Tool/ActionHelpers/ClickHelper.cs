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
    public class ClickHelper : DriverManager
    {
        public static void ClickOnElement(By locator)
        {
            IWebElement ele = UIReadHelper.GetVisibleElement(locator);
            if (ele != null)
                ele.Click();
            else
                Reporter.LogErrorMassage("Unable to find element " + locator);
        }
        public static void ClickOnElemnetById(string id)
        {
            ClickOnElement(By.Id(id));
        }
        public static void ClickOnElemnetByName(string name)
        {
            ClickOnElement(By.Name(name));
        }
        public static void ClickOnElemnetByXpath(string xpath)
        {
            ClickOnElement(By.XPath(xpath));
        }
        public static void ClickOnElemnetByLinkText(string linkText)
        {
            ClickOnElement(By.LinkText(linkText));
        }
        public static void ClickOnElemnetByPartialLinkText(string partialLinkText)
        {
            ClickOnElement(By.PartialLinkText(partialLinkText));
        }
        public static void ClickOnElemnetByClassName(string className)
        {
            ClickOnElement(By.CssSelector(className));
        }
        public static void ClickOnElemnetByCssSelector(string cssSelector)
        {
            ClickOnElement(By.CssSelector(cssSelector));
        }
        public static void ClickOnElemnetByTagName(string tagName)
        {
            ClickOnElement(By.TagName(tagName));
        }


    }


}
