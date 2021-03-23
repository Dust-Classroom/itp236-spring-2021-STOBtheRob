using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI
{
    public static class Delegate
    {
        public delegate int DateDifference(DateTime start, DateTime end);

        public static int Days (DateTime start, DateTime end)
        {
            TimeSpan daysDiff;
            daysDiff = end.Subtract(start);
            return daysDiff.Days;
        }

        public static int Hours (DateTime start, DateTime end)
        {
            TimeSpan hoursDiff;
            hoursDiff = end.Subtract(start);
            return hoursDiff.Hours;
        }

        public static int Minutes(DateTime start, DateTime end)
        {
            TimeSpan minsDiff;
            minsDiff = end.Subtract(start);
            return minsDiff.Minutes;
        }

    }
}
