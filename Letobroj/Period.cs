using System.Collections.Generic;

namespace BulgarskiLetobroj
{
    /// <summary>
    /// Each period in the calendar has a <ref:>CalendarPeriods</ref> type; duration in days and a list of
    /// sub-period types.
    /// </summary>
    internal interface IPeriod
    {
        long Days { get; }
        LetobrojPeriodi Type { get; }
        List<int> SubPeriods { get; }
    }
    /// <summary>
    /// Base structure for handling the different periods and period types.
    /// Constructor calculates length in days based on sub-period lengths.
    /// </summary>
    internal readonly struct Period : IPeriod
    {
        readonly long mDays;
        readonly LetobrojPeriodi mType;
        readonly List<int> mPeriods;
        public long Days { get => mDays; }
        public LetobrojPeriodi Type { get => mType; }
        public List<int> SubPeriods { get => mPeriods; }

        public Period(LetobrojPeriodi type, List<int> periods, long days = 0)
        {
            mType = type;
            mDays = days;
            mPeriods = periods;
            for (int i = 0; i < periods.Count; i++)
            {
                mDays += Periods.GetPeriod(periods[i]).Days;
            }
        }
    }
}