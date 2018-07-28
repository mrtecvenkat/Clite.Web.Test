using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;

namespace Auto.Test.GenericHelpers
{
    public class TestDataHelper
    {
        public static string GetValueFromAppSettings(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
