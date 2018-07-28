using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using Auto.Test.Tool.Core;
using Auto.Test.ReportHelpers;
using System.Threading;
using Auto.Test.Org.Core.Driver;

namespace Auto.Test.Tool.ActionHelpers
{
    public class SetOrSelectHelper : DriverManager
    {
        public static void SetFieldValue(By locator, string value)
        {
            IWebElement ele = UIReadHelper.GetVisibleElement(locator);
            if (ele != null)
                ele.SendKeys(value);
            else
                Reporter.LogFailMassage("Unable to find element " + locator);
        }
        public static void SetFieldValueById(string id, string value)
        {
            SetFieldValue(By.Id(id), value);
        }
        public static void SetFieldValueByName(string name, string value)
        {
            SetFieldValue(By.Name(name), value);
        }
        public static void SetFieldValueByXpath(string xpath, string value)
        {
            SetFieldValue(By.XPath(xpath), value);
        }
        public static void SetFieldValueByLinkText(string linkText, string value)
        {
            SetFieldValue(By.LinkText(linkText), value);
        }
        public static void SetFieldValueByPartialLinkText(string partialLinkText, string value)
        {
            SetFieldValue(By.PartialLinkText(partialLinkText), value);
        }
        public static void SetFieldValueByClassName(string className, string value)
        {
            SetFieldValue(By.CssSelector(className), value);
        }
        public static void SetFieldValueByCssSelector(string cssSelector, string value)
        {
            SetFieldValue(By.CssSelector(cssSelector), value);
        }
        public static void SetFieldValueByTagName(string tagName, string value)
        {
            SetFieldValue(By.TagName(tagName), value);
        }

        public static void SelectFieldValue(By locator, string value)
        {
            IWebElement ele = UIReadHelper.GetVisibleElement(locator);
            if (ele != null)
            {
                ele.Click();
                Thread.Sleep(2000);
                OpenQA.Selenium.Interactions.Actions curAction = new OpenQA.Selenium.Interactions.Actions(UIReadHelper.driver);
                IWebElement optionEle = driver.FindElement(By.XPath("//option[text()='" + value + "']"));
                curAction.MoveToElement(optionEle);
                //curAction.Click(optionEle).Build().Perform();
                UIReadHelper.GetVisibleElement(By.XPath("//option[text()='" + value + "']")).Click();
            }
            else
                Reporter.LogFailMassage("Unable to find element " + locator);
        }
        public static void SelectFieldValueById(string id, string value)
        {
            SelectFieldValue(By.Id(id), value);
        }
        public static void SelectFieldValueByName(string name, string value)
        {
            SelectFieldValue(By.Name(name), value);
        }
        public static void SelectFieldValueByXpath(string xpath, string value)
        {
            SelectFieldValue(By.XPath(xpath), value);
        }
        public static void SelectFieldValueByLinkText(string linkText, string value)
        {
            SelectFieldValue(By.LinkText(linkText), value);
        }
        public static void SelectFieldValueByPartialLinkText(string partialLinkText, string value)
        {
            SelectFieldValue(By.PartialLinkText(partialLinkText), value);
        }
        public static void SelectFieldValueByClassName(string className, string value)
        {
            SelectFieldValue(By.CssSelector(className), value);
        }
        public static void SelectFieldValueByCssSelector(string cssSelector, string value)
        {
            SelectFieldValue(By.CssSelector(cssSelector), value);
        }
        public static void SelectFieldValueByTagName(string tagName, string value)
        {
            SelectFieldValue(By.TagName(tagName), value);
        }

    }


}
