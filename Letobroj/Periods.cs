using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulgarskiLetobroj
{
    /// <summary>
    /// Static class containing the structs of letobroj periods.
    /// </summary>
    internal static class Periods
    {
        /// <summary>
        /// Holds the different periods types the Bulgarian calendar is composed of
        /// </summary>
        private static readonly Period[] mPeriods = new Period[28];
        /// <summary>
        /// Get desired period type
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Period GetPeriod(int index)
        {
            return mPeriods[index];
        }
        /// <summary>
        /// Set desired period type
        /// </summary>
        /// <param name="index"></param>
        /// <param name="period"></param>
        public static void SetPeriod(int index, Period period)
        {
            mPeriods[index] = period;
        }
    }
}