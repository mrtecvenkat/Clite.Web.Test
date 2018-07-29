using Auto.Test.GenericHelpers;
using Auto.Test.Tool.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;
using Auto.Test.Org.Core.Driver;
using Xunit.Abstractions;

namespace Auto.Test.ReportHelpers
{
    public class Reporter : DriverManager
    {
        private static ExtentReports report
        {
            get; set;
        }
        private static ExtentTest curtest
        {
            get; set;
        }
        public static ITestOutputHelper _output
        {
            get; set;
        }

        public static void SetReporter()
        {
            string resultPath = Environment.CurrentDirectory + "\\" + TestDataHelper.GetValueFromAppSettings("TestResults") + "\\ExtentReport.html";
            report = new ExtentReports(resultPath);
        }

        public static void EndReporting()
        {
            try
            {
                report.Flush();
                report.Close();
            }
            catch (Exception er)
            {

            }
        }
        public static void StartTestReporting(string testcase, string description = "")
        {
            if (curtest != null)
            {
                report.EndTest(curtest);
            }
            curtest = report.StartTest(testcase);

        }
        public static void EndTestReporting()
        {
            report.EndTest(curtest);
        }

        public static void LogFailMassage(string msg, string testcaseid = "")
        {
            Random rnd = new Random();
            string screenShortName = testcaseid + ".png";
            int randomItem = rnd.Next(1, 999999);
            if (testcaseid == "")
                screenShortName = randomItem + ".png";
            string impPath = Environment.CurrentDirectory + "\\" + TestDataHelper.GetValueFromAppSettings("TestResults") + "\\" + screenShortName;
            DriverManager.TakeScreenshot(impPath);
            curtest.Log(LogStatus.Fail, curtest.AddScreenCapture(impPath));
            _output.WriteLine(msg);
        }
        public static void LogErrorMassage(string msg, string testcaseid = "")
        {
            Random rnd = new Random();
            string screenShortName = testcaseid + ".png";
            int randomItem = rnd.Next(1, 999999);
            if (testcaseid == "")
                screenShortName = randomItem + ".png";
            string impPath = Environment.CurrentDirectory + "\\" + TestDataHelper.GetValueFromAppSettings("TestResults") + "\\" + screenShortName;
            DriverManager.TakeScreenshot(impPath);
            curtest.Log(LogStatus.Error, curtest.AddScreenCapture(impPath));
            _output.WriteLine(msg);
        }
        public static void LogPassMassage(string msg)
        {
            curtest.Log(LogStatus.Pass, msg);
            _output.WriteLine(msg);
        }
        public static void LogDebugMassage(string msg)
        {
            curtest.Log(LogStatus.Info, msg);
            _output.WriteLine(msg);
        }
    }
}
