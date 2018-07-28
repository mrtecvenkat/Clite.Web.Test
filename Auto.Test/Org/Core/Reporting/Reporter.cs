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
        private static ExtentReports report;
        private static ExtentTest curtest;
        public static ITestOutputHelper _output
        {
            get; set;
        }

        public Reporter()
        {
            string resultPath = Environment.CurrentDirectory + "\\" + TestDataHelper.GetValueFromAppSettings("TestResults") + "\\ExtentReport.html";
            report = new ExtentReports(resultPath);
        }

        public static void EndReporting()
        {
            report.Flush();
            report.Close();
        }
        public static void StartTestReporting(string testcase, string description = "")
        {
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
            string resultPath = TestDataHelper.GetValueFromAppSettings("TestResults");
            DriverManager.TakeScreenshot(resultPath + "\\" + screenShortName);

            _output.WriteLine(msg);


        }
        public static void LogPassMassage(string msg)
        {
            _output.WriteLine(msg);
        }
        public static void LogDebugMassage(string msg)
        {
            _output.WriteLine(msg);
        }
    }
}
