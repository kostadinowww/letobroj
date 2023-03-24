using System.Collections.Generic;

namespace BulgarskiLetobroj
{
    /// <summary>
    /// This factory class populates all the various periods of the Bulgarian calendar as structs in the
    /// static class Periods.
    /// </summary>
    internal class LetobrojFactory
    {
        /// <summary>
        /// Generate structs for all the period types in the Bulgarian letobroj: day, month, four years, twelve years, star day (60) years, star week, star month, star year, epoch.
        /// </summary>
        public void GenerateStructs()
        {
            var dni = new List<int>();
            var meseci = new List<int>();
            var chetirigodie = new List<int>();
            var dvanadesetogodie = new List<int>();
            var zvezdenDen = new List<int>();
            var zvezdnaSedmica = new List<int>();
            var zvezdenMesec = new List<int>();
            var zvezdnaGodina = new List<int>();
            var zvezdnoChetirigodie = new List<int>();
            var epoha = new List<int>();

            Periods.SetPeriod((int)LetobrojPeriodi.Day, new Period(LetobrojPeriodi.Day, dni, 1));
            Periods.SetPeriod((int)LetobrojPeriodi.WinterDay, new Period(LetobrojPeriodi.Day, dni, 1));
            Periods.SetPeriod((int)LetobrojPeriodi.SummerDay, new Period(LetobrojPeriodi.Day, dni, 1));

            dni = new List<int>(dni);
            for (int i = 0; i < 30; i++)
            {
                dni.Add((int)LetobrojPeriodi.Day);
            }
            Periods.SetPeriod((int)LetobrojPeriodi.Month, new Period(LetobrojPeriodi.Month, dni));

            dni = new List<int>(dni);
            dni.Add((int)LetobrojPeriodi.Day);
            Periods.SetPeriod((int)LetobrojPeriodi.LeapMonth, new Period(LetobrojPeriodi.LeapMonth, dni));

            dni = new List<int>(dni);
            dni.RemoveAt(30);
            dni.Add((int)LetobrojPeriodi.SummerDay);
            Periods.SetPeriod((int)LetobrojPeriodi.SummerLeapMonth, new Period(LetobrojPeriodi.SummerLeapMonth, dni));

            dni = new List<int>(dni);
            dni.RemoveAt(30);
            dni.Add((int)LetobrojPeriodi.WinterDay);
            Periods.SetPeriod((int)LetobrojPeriodi.WinterLeapMonth, new Period(LetobrojPeriodi.WinterLeapMonth, dni));

            for (int i = 0; i < 12; i++)
            {
                meseci.Add((int)LetobrojPeriodi.Month);
            }
            meseci[0] = (int)LetobrojPeriodi.LeapMonth;
            meseci[3] = (int)LetobrojPeriodi.LeapMonth;
            meseci[6] = (int)LetobrojPeriodi.LeapMonth;
            meseci[9] = (int)LetobrojPeriodi.LeapMonth;
            meseci[11] = (int)LetobrojPeriodi.WinterLeapMonth;
            Periods.SetPeriod((int)LetobrojPeriodi.Year, new Period(LetobrojPeriodi.Year, meseci));

            meseci = new List<int>(meseci);
            meseci[5] = (int)LetobrojPeriodi.SummerLeapMonth;
            Periods.SetPeriod((int)LetobrojPeriodi.LeapYear, new Period(LetobrojPeriodi.LeapYear, meseci));

            chetirigodie.Add((int)LetobrojPeriodi.Year);
            chetirigodie.Add((int)LetobrojPeriodi.Year);
            chetirigodie.Add((int)LetobrojPeriodi.Year);
            chetirigodie.Add((int)LetobrojPeriodi.Year);
            Periods.SetPeriod((int)LetobrojPeriodi.Quaternion, new Period(LetobrojPeriodi.Quaternion, chetirigodie));

            chetirigodie = new List<int>(chetirigodie);
            chetirigodie[3] = (int)LetobrojPeriodi.LeapYear;
            Periods.SetPeriod((int)LetobrojPeriodi.LeapQuaternion, new Period(LetobrojPeriodi.LeapQuaternion, chetirigodie));

            dvanadesetogodie.Add((int)LetobrojPeriodi.LeapQuaternion);
            dvanadesetogodie.Add((int)LetobrojPeriodi.LeapQuaternion);
            dvanadesetogodie.Add((int)LetobrojPeriodi.Quaternion);
            Periods.SetPeriod((int)LetobrojPeriodi.Dozen, new Period(LetobrojPeriodi.Dozen, dvanadesetogodie));

            dvanadesetogodie = new List<int>(dvanadesetogodie);
            dvanadesetogodie[2] = (int)LetobrojPeriodi.LeapQuaternion;
            Periods.SetPeriod((int)LetobrojPeriodi.LeapDozen, new Period(LetobrojPeriodi.LeapDozen, dvanadesetogodie));

            zvezdenDen.Add((int)LetobrojPeriodi.LeapDozen);
            zvezdenDen.Add((int)LetobrojPeriodi.LeapDozen);
            zvezdenDen.Add((int)LetobrojPeriodi.LeapDozen);
            zvezdenDen.Add((int)LetobrojPeriodi.LeapDozen);
            zvezdenDen.Add((int)LetobrojPeriodi.Dozen);
            Periods.SetPeriod((int)LetobrojPeriodi.StarDay, new Period(LetobrojPeriodi.StarDay, zvezdenDen));

            zvezdenDen = new List<int>(zvezdenDen);
            zvezdenDen[4] = (int)LetobrojPeriodi.LeapDozen;
            Periods.SetPeriod((int)LetobrojPeriodi.LeapStarDay, new Period(LetobrojPeriodi.LeapStarDay, zvezdenDen));

            zvezdnaSedmica.Add((int)LetobrojPeriodi.StarDay);
            zvezdnaSedmica.Add((int)LetobrojPeriodi.LeapStarDay);
            zvezdnaSedmica.Add((int)LetobrojPeriodi.StarDay);
            zvezdnaSedmica.Add((int)LetobrojPeriodi.LeapStarDay);
            zvezdnaSedmica.Add((int)LetobrojPeriodi.StarDay);
            zvezdnaSedmica.Add((int)LetobrojPeriodi.LeapStarDay);
            zvezdnaSedmica.Add((int)LetobrojPeriodi.StarDay);
            Periods.SetPeriod((int)LetobrojPeriodi.StarWeek, new Period(LetobrojPeriodi.StarWeek, zvezdnaSedmica));

            zvezdnaSedmica = new List<int>(zvezdnaSedmica);
            zvezdnaSedmica[6] = (int)LetobrojPeriodi.LeapStarDay;
            Periods.SetPeriod((int)LetobrojPeriodi.LeapStarWeek, new Period(LetobrojPeriodi.LeapStarWeek, zvezdnaSedmica));

            zvezdenMesec.Add((int)LetobrojPeriodi.LeapStarWeek);
            zvezdenMesec.Add((int)LetobrojPeriodi.StarWeek);
            zvezdenMesec.Add((int)LetobrojPeriodi.LeapStarWeek);
            zvezdenMesec.Add((int)LetobrojPeriodi.StarWeek);
            Periods.SetPeriod((int)LetobrojPeriodi.StarMonth, new Period(LetobrojPeriodi.StarMonth, zvezdenMesec));

            zvezdenMesec = new List<int>(zvezdenMesec);
            zvezdenMesec[3] = (int)LetobrojPeriodi.LeapStarWeek;
            Periods.SetPeriod((int)LetobrojPeriodi.LeapStarMonth, new Period(LetobrojPeriodi.LeapStarMonth, zvezdenMesec));

            for (int i = 0; i < 12; i++)
            {
                zvezdnaGodina.Add((int)LetobrojPeriodi.LeapStarMonth);
            }
            zvezdnaGodina[5] = (int)LetobrojPeriodi.StarMonth;
            Periods.SetPeriod((int)LetobrojPeriodi.LeapStarYear, new Period(LetobrojPeriodi.LeapStarYear, zvezdnaGodina));

            zvezdnaGodina = new List<int>(zvezdnaGodina);
            zvezdnaGodina[11] = (int)LetobrojPeriodi.StarMonth;
            Periods.SetPeriod((int)LetobrojPeriodi.StarYear, new Period(LetobrojPeriodi.StarYear, zvezdnaGodina));

            zvezdnoChetirigodie.Add((int)LetobrojPeriodi.LeapStarYear);
            zvezdnoChetirigodie.Add((int)LetobrojPeriodi.LeapStarYear);
            zvezdnoChetirigodie.Add((int)LetobrojPeriodi.LeapStarYear);
            zvezdnoChetirigodie.Add((int)LetobrojPeriodi.LeapStarYear);
            Periods.SetPeriod((int)LetobrojPeriodi.LeapStarQuaternion, new Period(LetobrojPeriodi.LeapStarQuaternion, zvezdnoChetirigodie));

            zvezdnoChetirigodie = new List<int>(zvezdnoChetirigodie);
            zvezdnoChetirigodie[1] = (int)LetobrojPeriodi.StarYear;
            Periods.SetPeriod((int)LetobrojPeriodi.StarQuaternion, new Period(LetobrojPeriodi.StarQuaternion, zvezdnoChetirigodie));

            for (int i = 0; i < 125; i++)
            {
                epoha.Add((int)LetobrojPeriodi.StarQuaternion);
            }
            epoha[62] = (int)LetobrojPeriodi.LeapStarQuaternion;
            Periods.SetPeriod((int)LetobrojPeriodi.StarEpoch, new Period(LetobrojPeriodi.StarEpoch, epoha));
        }
    }
}