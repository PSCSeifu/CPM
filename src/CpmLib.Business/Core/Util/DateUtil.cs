using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Business.Core.Util
{
    public static class DateUtil
    {
        public static DateTime? GetUtcDateTimeDateFromUnixTimeStamp(this long value)
        {            
            if(value <= 0)
            {
                return null;
            }

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(value);
            return dateTimeOffset.UtcDateTime;
        }
    }
}
