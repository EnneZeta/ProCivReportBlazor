using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCivReport.Extensions
{
    public static class TimeExtensions
    {
        public static string ToHours(this int p)
        {
            return decimal.Divide(p , 60).ToString();
        }
    }
}
