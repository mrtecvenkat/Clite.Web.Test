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
using Auto.Test.GenericHelpers;
using Xunit;
using Auto.Test.ReportHelpers;

namespace Auto.Test.Org.Core.Driver
{
    public class DriverManager
    {
        public static string browserVersion = "";
        static int activeDriverIndex = 0;
        public static string browserType = TestDataHelper.GetValueFromAppSettings("browser");
        private static IWebDriver curDriver = null;
        public static string curWindowId = null;
        public static IWebDriver driver
        {
            get
            {
                if (browserType != null)
                {
                    if (curDriver == null)
                    {
                        curDriver = GetDriver(browserType);
                        curWindowId = curDriver.CurrentWindowHandle;
                        curDriver.Manage().Window.Maximize();
                        return curDriver;
                    }
                    else
                        return curDriver;
                }
                else
                    return null;
            }
        }

        private static IWebDriver GetDriver(string browserType)
        {
            IWebDriver curDriver = null;
            switch (browserType)
            {
                case "chrome":
                    DesiredCapabilities capabilites = DesiredCapabilities.Chrome();
                    capabilites.SetCapability("navtiveEvents", true);
                    ChromePerformanceLoggingPreferences logPrefs = new ChromePerformanceLoggingPreferences();
                    logPrefs.AddTracingCategories(LogType.Profiler);
                    ChromeOptions options = new ChromeOptions();
                    options.SetLoggingPreference(LogType.Browser, LogLevel.Warning);
                    curDriver = new ChromeDriver(options);
                    Reporter.SetReporter();
                    Reporter.StartTestReporting("Test Started");
                    break;


            }
            return curDriver;
        }

        public static void TakeScreenshot(string imgPath)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshort = ss.AsBase64EncodedString;
            byte[] screenshortAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(imgPath, ScreenshotImageFormat.Png);
            ss.ToString();

        }
        public static void SwitchToNewWindow()
        {
            IReadOnlyCollection<string> windowIds = driver.WindowHandles;
            foreach (string item in windowIds)
            {
                if (item != curWindowId)
                {
                    driver.SwitchTo().Window(item);
                    break;
                }
            }
        }
        public static void SwitchBackToMainWindow()
        {
            driver.SwitchTo().Window(curWindowId);
            Reporter.LogPassMassage("Application Successfully swithced to window id" + curWindowId);
        }
        public static void Open(string url = "")
        {
            if (url == "")
                url = TestDataHelper.GetValueFromAppSettings("appurl");
            try
            {
                driver.Navigate().GoToUrl(url);
                Reporter.LogPassMassage("Successfully Navigates to URL " + url);
            }
            catch (Exception ex)
            {
                Reporter.LogFailMassage("Unable to naviage url <" + url + "> exception:" + ex.Message);
            }
        }

        public void Exit()
        {
            curDriver.Quit();
            Reporter.LogPassMassage("Application Successfully closed");
            Reporter.EndTestReporting();
            Reporter.EndReporting();
        }
    }
}
