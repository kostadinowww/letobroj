using System.Collections.Generic;

namespace BulgarskiLetobroj
{
    /// <summary>
    /// All the different period types from the Bulgarian calendar.
    /// </summary>
    internal enum LetobrojPeriodi
    {
        Day,
        SummerDay,
        WinterDay,
        Month,
        LeapMonth,
        SummerLeapMonth,
        WinterLeapMonth,
        Year,
        LeapYear,
        Quaternion,
        LeapQuaternion,
        Dozen,
        LeapDozen,
        DouzineGender, // Alternating male / female
        DouzineElement,
        DouzineColor,
        DouzineDirection,
        StarDay, // 60 years
        LeapStarDay, // 60 years
        StarWeek, // 7 star days = 420 years
        LeapStarWeek, // 7 star days = 420 years
        StarMonth, // 4 star weeks = 28 star days = 1680 years
        LeapStarMonth, // 4 star weeks = 28 star days = 1680 years
        StarYear, // 12 star months = 48 star weeks = 336 star days = 20160 years
        LeapStarYear, // 12 star months = 48 star weeks = 336 star days = 20160 years
        StarQuaternion, // 12 star months = 48 star weeks = 336 star days = 20160 years
        LeapStarQuaternion, // 12 star months = 48 star weeks = 336 star days = 20160 years
        StarEpoch // 125 periods of 4 star years = 500 star years ...
    }
}