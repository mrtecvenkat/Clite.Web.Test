using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Test.Org.Core.Util
{
    public class DateTimeUtil
    {
        public static string GetUniqueValue()
        {
            DateTime curDate = new DateTime();
            return curDate.Day + "" + curDate.Month + "" + curDate.Year + "" + curDate.Hour + "" + curDate.Minute + "" + curDate.Second + "" + curDate.Millisecond;
        }
    }
}
