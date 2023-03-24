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
    internal struct SpecificDay
    {
        internal long Day { get; set; }
        internal long WeekDay { get; set; }
        internal long Month { get; set; }
        internal long Year { get; set; }
        internal long Quaternion { get; set; }
        internal long Dozen { get; set; }
        internal long DozenAnimal { get; set; }
        internal long DozenColor { get; set; }
        internal long DouzineGender { get; set; }
        internal long DouzineElement { get; set; }
        internal long StarColor { get; set; }
        internal long DouzineDirection { get; set; }
        internal long StarDay { get; set; }
        internal long StarWeek { get; set; }
        internal long StarMonth { get; set; }
        internal long StarYear { get; set; }
        internal long StarQuadruple { get; set; }
        internal long StarEpoch { get; set; }
        internal bool behti;
        internal bool eni;
    }

}