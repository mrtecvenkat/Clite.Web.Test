using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Auto.Test.Tool.Core;
using Auto.Test.Tool.ActionHelpers;
using Auto.Test.GenericHelpers;
using Auto.Test.Org.Core.Driver;
using Xunit.Abstractions;
using Auto.Test.ReportHelpers;

namespace Auto.Test.Domain.AppTests
{
    public class SampleOne : DriverManager
    {
        public SampleOne(ITestOutputHelper curOutput)
        {
            Reporter._output = curOutput;
        }

        [Fact]
        public void DoTestOne()
        {
            //string path = Environment.CurrentDirectory + "\\Resource\\AppDataOne.xlsx";
            //ExcelHelper eh = new ExcelHelper();
            //List<Dictionary<string, string>> testData = eh.GetDataRows(path, "TestData");
            Open();
            Reporter.StartTestReporting("DoTestOne", "Fist one");
            Reporter.LogPassMassage("Wecome");
            SetOrSelectHelper.SelectFieldValueById("dcdrLocation", "Chennai");
            //SeleniumJavaScriptActions.Select("#(dcdrLocation)", "Chennai");
            Reporter.LogErrorMassage("ddodlasdjfaldsfj");
            Reporter.EndTestReporting();
            Reporter.EndReporting();
        }
    }
}
