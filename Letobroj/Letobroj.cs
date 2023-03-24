using Android.OS;
using System;

namespace BulgarskiLetobroj
{
    /// <summary>
    /// Main calculating class of the application. Contains constant for the number of days since the start of the
    /// Bulgarian Letobroj to the JAVA epoch.
    /// Calculates a Bulgarian-calendar SpecificDay from provided gregorian datetime by substracting the lesser periods and incrementing the return date properties.
    /// </summary>
    internal class Letobroj
    {
        // The number of days from the beginning of the Bulgarian calendar to the JAVA epoch
        private const long mBCStartDayJavaEpoch = 2729830L; // or 2 729 833 ?
        private const long mEpochYears = 3681641376;
        private const long mStarMonthYears = 1680;
        private const long mStarWeekYears = 420;
        private const long mStarDayYears = 60;
        private const long mStarDozenYears = 12;
        private const long mStarQuaternionYears = 4;

        /// <summary>
        /// Get a date from gregorian implementation and returns a the SpecificDay instance for the same day in the Bulgarian calendar.
        /// </summary>
        /// <param name="param">Gregorian DateTime</param>
        /// <returns>Bulgarian SpecificDay</returns>
        public SpecificDay GetDay(DateTime param)
        {
            // Days from JAVA epoch to the provided date and final number of days
            long javaEpochDays = (long) (param - new DateTime(1970, 1, 1, 0, 0, 0)).TotalDays;
            long finalDays = mBCStartDayJavaEpoch + javaEpochDays;
            var factory = new LetobrojFactory();
            var day = new SpecificDay();

            // Generate the structs needed to calculate the Bulgarian date
            factory.GenerateStructs();

            // Start recursing over the structs in order to calculate all the properties of the specific day
            day = SubstractPeriod(day, ref finalDays, LetobrojPeriodi.StarEpoch);

            // Add color, gender and animal to the specific day
            SetAdditional(ref day);

            return day;
        }
        /// <summary>
        /// Set additional properties to the spficic day: day of week; gender; element, color, direction; animal; type of day.
        /// </summary>
        /// <param name="day">The specific day to be decorated</param>
        private void SetAdditional(ref SpecificDay day)
        {
            day.WeekDay = (((long)Math.Floor((double)day.Month / 3) + 1) + day.Month * 30 + day.Day) % 7;
            day.DouzineGender = (long) Math.Floor((double) (day.Year + 1) / 12) % 2;
            day.DouzineElement = (long)Math.Floor((double) (day.Year + 1) / 12) % 5;
            day.DozenAnimal = (day.Year + 1) % 12;
            if (day.Day == 30 && day.Month == 5)
            {
                day.behti = true;
            }
            if (day.Day == 30 && day.Month == 11)
            {
                day.eni = true;
            }
        }
        /// <summary>
        /// Try to substract the period from the specific day. If successful, increment the appropriate 
        /// property of the specific day.
        /// If the period is larger, try to recursively do the same with all the child periods.
        /// </summary>
        /// <param name="day">The specific day we are working upon</param>
        /// <param name="days">The number of days left to account for</param>
        /// <param name="period">The current period in question</param>
        /// <returns>The specific day with incremented properties for the various period types</returns>
        private SpecificDay SubstractPeriod(SpecificDay day, ref long days, LetobrojPeriodi period)
        {
            Period p = Periods.GetPeriod((int)period);
            if (days >= p.Days)
            {
                IncrementPeriod(ref day, p);
                days -= p.Days;
            }
            else if (days > 0)
            {
                for (int i = 0; i < p.SubPeriods.Count; i++)
                {
                    day = SubstractPeriod(day, ref days, Periods.GetPeriod((int) p.SubPeriods[i]).Type);
                }
            }
            return day;
        }
        /// <summary>
        /// Increment the appropriate property of the specific day provided: day, month, year, star week, etc.
        /// </summary>
        /// <param name="day">The specific day to be updated</param>
        /// <param name="period">The period that has incremented by one</param>
        private void IncrementPeriod(ref SpecificDay day, Period period)
        {
            switch (period.Type)
            {
                case LetobrojPeriodi.StarEpoch:
                    day.StarEpoch++;
                    day.Year += mEpochYears;
                    break;
                case LetobrojPeriodi.StarMonth:
                    day.StarMonth++;
                    day.Year += mStarMonthYears;
                    break;
                case LetobrojPeriodi.LeapStarMonth:
                    day.StarMonth++;
                    day.Year += mStarMonthYears;
                    break;
                case LetobrojPeriodi.StarWeek:
                    day.StarWeek++;
                    day.Year += mStarWeekYears;
                    break;
                case LetobrojPeriodi.LeapStarWeek:
                    day.StarWeek++;
                    day.Year += mStarWeekYears;
                    break;
                case LetobrojPeriodi.StarDay:
                    day.StarDay++;
                    day.Year += mStarDayYears;
                    break;
                case LetobrojPeriodi.LeapStarDay:
                    day.StarDay++;
                    day.Year += mStarDayYears;
                    break;
                case LetobrojPeriodi.Dozen:
                    day.Dozen++;
                    day.Year += mStarDozenYears;
                    break;
                case LetobrojPeriodi.LeapDozen:
                    day.Dozen++;
                    day.Year += mStarDozenYears;
                    break;
                case LetobrojPeriodi.Quaternion:
                    day.Quaternion++;
                    day.Year += mStarQuaternionYears;
                    break;
                case LetobrojPeriodi.LeapQuaternion:
                    day.Quaternion++;
                    day.Year += mStarQuaternionYears;
                    break;
                case LetobrojPeriodi.Year:
                    day.Year++;
                    break;
                case LetobrojPeriodi.LeapYear:
                    day.Year++;
                    break;
                case LetobrojPeriodi.Month:
                    day.Month++;
                    break;
                case LetobrojPeriodi.WinterLeapMonth:
                    day.Month++;
                    break;
                case LetobrojPeriodi.SummerLeapMonth:
                    day.Month++;
                    break;
                case LetobrojPeriodi.LeapMonth:
                    day.Month++;
                    break;
                case LetobrojPeriodi.Day:
                    day.Day++;
                    break;
                case LetobrojPeriodi.WinterDay:
                    day.Day++;
                    break;
                case LetobrojPeriodi.SummerDay:
                    day.Day++;
                    break;
                default:
                    break;
            }
        }
    }
}