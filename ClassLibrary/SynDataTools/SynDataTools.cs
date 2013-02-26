using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SynDataTools
{
    public static class SynDataTools
    {
        //==========================================================================
        //Synergy alpha fields

        public static string SynAlphaToNetString(string avar)
        {
            return avar.Trim();
        }

        public static string NetStringToSynAlpha(string svar, int len)
        {
            string avar = svar.Trim();
            if (avar.Length < len)
                avar = avar.PadRight(len, char.Parse(" "));
            return avar;
        }

        //==========================================================================
        //Synergy decimal fields up to D9

        public static int SynDecimalToNetInt(string dvar)
        {
            //TODO: Not implemented!
            return 0;
        }

        public static string NetIntToSynDecimal(int dvar, int len)
        {
            string mask = "";
            string avar;
            bool neg = (dvar < 0);

            if (neg) dvar = -dvar;

            //Create a format mask
            mask = mask.PadLeft(len, char.Parse("0"));

            //Format the integer field using the format mask
            avar = dvar.ToString(mask);

            //Apply special encoding for negative numbers
            if (neg)
            {
                string negchar = "";
                switch (avar.Substring(len - 1, 1))
                {
                    case "0":
                        negchar = "p";
                        break;
                    case "1":
                        negchar = "q";
                        break;
                    case "2":
                        negchar = "r";
                        break;
                    case "3":
                        negchar = "s";
                        break;
                    case "4":
                        negchar = "t";
                        break;
                    case "5":
                        negchar = "u";
                        break;
                    case "6":
                        negchar = "v";
                        break;
                    case "7":
                        negchar = "w";
                        break;
                    case "8":
                        negchar = "x";
                        break;
                    case "9":
                        negchar = "y";
                        break;
                }
                avar = avar.Substring(0, len - 1) + negchar;
            }

            return avar;
        }

        //==========================================================================
        //Synergy decimal fields D10 and longer

        public static long SynDecimalToNetLong(string dvar)
        {
            //TODO: Not implemented!
            return 0;
        }

        public static string NetLongToSynDecimal(long dvar, int len)
        {
            string mask = "";
            string avar;
            bool neg = (dvar < 0);

            if (neg) dvar = -dvar;

            //Create a format mask
            mask = mask.PadLeft(len, char.Parse("0"));

            //Format the integer field using the format mask
            avar = dvar.ToString(mask);

            //Apply special encoding for negative numbers
            if (neg)
            {
                string negchar = "";
                switch (avar.Substring(len - 1, 1))
                {
                    case "0":
                        negchar = "p";
                        break;
                    case "1":
                        negchar = "q";
                        break;
                    case "2":
                        negchar = "r";
                        break;
                    case "3":
                        negchar = "s";
                        break;
                    case "4":
                        negchar = "t";
                        break;
                    case "5":
                        negchar = "u";
                        break;
                    case "6":
                        negchar = "v";
                        break;
                    case "7":
                        negchar = "w";
                        break;
                    case "8":
                        negchar = "x";
                        break;
                    case "9":
                        negchar = "y";
                        break;
                }
                avar = avar.Substring(0, len - 1) + negchar;
            }

            return avar;
        }

        //==========================================================================
        //Synergy implied decimal fields

        public static decimal SynImpliedToNetDecimal(string impvar, int precision)
        {
            //TODO: Not implemented!
            return 0;
        }

        public static string NetDecimalToSynImplied(decimal dvar, int len, int prec)
        {

            //TODO: This routine needs to round the precision value from .NET based on the precision defined in Synergy

            //Record if the value is negative, and make it positive
            bool neg = (dvar < 0);
            if (neg) dvar = -dvar;

            //Remove the decimal point
            long lval = 0;
            switch (prec)
            {
                case 1:
                    lval = (long)(dvar * 10);
                    break;
                case 2:
                    lval = (long)(dvar * 100);
                    break;
                case 3:
                    lval = (long)(dvar * 1000);
                    break;
                case 4:
                    lval = (long)(dvar * 10000);
                    break;
                case 5:
                    lval = (long)(dvar * 100000);
                    break;
                case 6:
                    lval = (long)(dvar * 1000000);
                    break;
                case 7:
                    lval = (long)(dvar * 10000000);
                    break;
                case 8:
                    lval = (long)(dvar * 100000000);
                    break;
                case 9:
                    lval = (long)(dvar * 1000000000);
                    break;
                case 10:
                    lval = (long)(dvar * 10000000000);
                    break;
            }

            //Define a numeric format mask of the correct length
            string mask = "";
            mask = mask.PadLeft(len, char.Parse("0"));

            //Format the numeric field using the format mask
            string avar;
            avar = lval.ToString(mask);

            //Apply Synergy negative number encoding
            if (neg)
            {
                string negchar = "";
                switch (avar.Substring(len - 1, 1))
                {
                    case "0":
                        negchar = "p";
                        break;
                    case "1":
                        negchar = "q";
                        break;
                    case "2":
                        negchar = "r";
                        break;
                    case "3":
                        negchar = "s";
                        break;
                    case "4":
                        negchar = "t";
                        break;
                    case "5":
                        negchar = "u";
                        break;
                    case "6":
                        negchar = "v";
                        break;
                    case "7":
                        negchar = "w";
                        break;
                    case "8":
                        negchar = "x";
                        break;
                    case "9":
                        negchar = "y";
                        break;
                }
                avar = avar.Substring(0, len - 1) + negchar;
            }
            return avar;
        }

        //==========================================================================
        //Synergy integer fields (i1, i2 and i4)

        public static int SynIntToNetInt(string avar)
        {
            //TODO: Process based on the length of avar, 1, 2 or 4
            return 0;
        }

        public static string NetIntToSynInt(int intvar, int len)
        {
            //TODO: Not implemented
            return "";
        }

        //==========================================================================
        //Synergy integer fields (i8)

        public static long SynIntToNetLong(string avar)
        {
            //TODO: Not implemented
            return 0;
        }

        public static string NetLongToSynInt(long longvar, int len)
        {
            //TODO: Not implemented
            return "";
        }

        //==========================================================================
        //Synergy boolean fields

        public static bool SynBoolToNetBool(string bvar)
        {
            if (bvar == "1")
                return true;
            else
                return false;
        }

        public static string NetBoolToSynBool(bool bvar)
        {
            if (bvar)
                return " "; //TODO: Not correct!
            else
                return " "; //TODO: Not correct!
        }

        //==========================================================================
        //Synergy date fields

        public static DateTime SynDateToNetDate(string dateString)
        {
            int year;
            int month;
            int day;
            DateTime retDate = new DateTime();
            switch (dateString.Length)
            {
                case 6: //YYMMDD
                    year = Int32.Parse(dateString.Substring(1, 2));
                    if (year <= 50) { year += 2000; } else { year += 1900; }
                    month = Int32.Parse(dateString.Substring(3, 2));
                    day = Int32.Parse(dateString.Substring(5, 2));
                    retDate = new DateTime(year, month, day);
                    break;
                case 8: //YYYYMMDD
                    year = Int32.Parse(dateString.Substring(1, 4));
                    month = Int32.Parse(dateString.Substring(5, 2));
                    day = Int32.Parse(dateString.Substring(7, 2));
                    retDate = new DateTime(year, month, day);
                    break;
            }
            return retDate;
        }

        public static string NetDateToSynDate(DateTime dDate, int len)
        {
            string sDate = "";
            int year = dDate.Year;
            int month = dDate.Month;
            int day = dDate.Day;
            switch (len)
            {
                case 6: //YYMMDD
                    sDate = sDate.Insert(sDate.Length, (year.ToString("0000").Substring(2, 2)));
                    sDate = sDate.Insert(sDate.Length, month.ToString("00"));
                    sDate = sDate.Insert(sDate.Length, day.ToString("00"));
                    break;
                case 8: //YYYYMMDD
                    sDate = sDate.Insert(sDate.Length, year.ToString("0000"));
                    sDate = sDate.Insert(sDate.Length, month.ToString("00"));
                    sDate = sDate.Insert(sDate.Length, day.ToString("00"));
                    break;
            }
            return sDate;
        }

        //==========================================================================
        //Synergy time fields

        public static DateTime SynTimeToNetTime(string timeString)
        {
            int hour;
            int minute;
            int second;
            DateTime retDate = new DateTime();

            switch (timeString.Length)
            {
                case 4: //HHMM
                    hour = Int32.Parse(timeString.Substring(1, 2));
                    minute = Int32.Parse(timeString.Substring(3, 2));
                    retDate = new DateTime(1, 1, 1, hour, minute, 0);
                    break;
                case 6: //HHMMSS
                    hour = Int32.Parse(timeString.Substring(1, 2));
                    minute = Int32.Parse(timeString.Substring(3, 2));
                    second = Int32.Parse(timeString.Substring(5, 2));
                    retDate = new DateTime(1, 1, 1, hour, minute, second);
                    break;
            }
            return retDate;
        }

        public static string NetTimeToSynTime(DateTime dTime, int len)
        {
            int hour = dTime.Hour;
            int minute = dTime.Minute;
            int second = dTime.Second;
            string sTime = "";
            switch (len)
            {
                case 4: //HHMM
                    sTime = sTime.Insert(sTime.Length, dTime.Hour.ToString("00"));
                    sTime = sTime.Insert(sTime.Length, dTime.Minute.ToString("00"));
                    break;
                case 6: //HHMMSS
                    sTime = sTime.Insert(sTime.Length, dTime.Hour.ToString("00"));
                    sTime = sTime.Insert(sTime.Length, dTime.Minute.ToString("00"));
                    sTime = sTime.Insert(sTime.Length, dTime.Second.ToString("00"));
                    break;
            }
            return sTime;
        }

    }
}
