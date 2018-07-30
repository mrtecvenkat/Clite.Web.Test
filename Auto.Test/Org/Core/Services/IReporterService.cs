using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Test.Org.Core.Services
{
    public interface IReporterService
    {
        //Create Reporter
        IReporterService CreateReport(string path);
        //Add Environment details

        //Add Scenario
        //Add TestCase
        //Log TestStep        
        //Close TestCase
        //CloseScenario
    }


}
