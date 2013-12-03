<CODEGEN_FILENAME>DataUtils.dbl</CODEGEN_FILENAME>
;;******************************************************************************
;;* WARNING: Code generated at <TIME> on <DATE> by <AUTHOR>
;;******************************************************************************

import System

namespace <NAMESPACE>

    ;;; <summary>
    ;;; Various data conversion utility methods
    ;;; </summary>
    public static class DataUtils

        ;;; <summary>
        ;;; Convert a Synergy D6 (YYMMDD) or D8 (YYYYMMDD) date to the date portion of a .NET DateTime
        ;;; </summary>
        public static method DateFromDecimal, DateTime
            required in aDecimalDate, d
            endparams
            record
                group date6
                    year    ,d2
                    month   ,d2
                    day     ,d2
                endgroup
                group date8
                    year    ,d4
                    month   ,d2
                    day     ,d2
                endgroup
                outDate, DateTime
            endrecord
        proc

            try
            begin
                using ^size(aDecimalDate) select
                (6),
                begin
                    date6 = aDecimalDate
                    outdate = new DateTime(integer(date6.year),integer(date6.month),integer(date6.day))
                end
                (8),
                begin
                    date8 = aDecimalDate
                    outdate = new DateTime(integer(date8.year),integer(date8.month),integer(date8.day))
                end
                (),
                    throw new ApplicationException("Unsupported date format in DataUtils.DateFromDecimal!")
                endusing
            end
            catch (ex, @Exception)
            begin
                outDate = new DateTime()
            end
            endtry

            mreturn outDate

        endmethod

        ;;; <summary>
        ;;; Convert the date portion of a .NET DateTime to a Synergy D8 (YYYYMMDD) date
        ;;; </summary>
        public static method D8FromDate, d
            required in aDate, DateTime
            endparams
            record
                group date8 ,d
                    year    ,d4
                    month   ,d2
                    day     ,d2
                endgroup
            endrecord
        proc
            date8.year = aDate.Year
            date8.month = aDate.Month
            date8.day = aDate.Day
            mreturn date8
        endmethod

        ;;; <summary>
        ;;; Convert the date portion of a .NET DateTime to a Synergy D6 (YYMMDD) date
        ;;; </summary>
        public static method D6FromDate, d
            required in aDate, DateTime
            endparams
            record
                group date6 ,d
                    year    ,d2
                    month   ,d2
                    day     ,d2
                endgroup
            endrecord
        proc
            date6.year = aDate.Year
            date6.month = aDate.Month
            date6.day = aDate.Day
            mreturn date6
        endmethod

        ;;; <summary>
        ;;; Convert a Synergy D4 (HHMM) or D6 (HHMMSS) time to the time portion of a .NET DateTime
        ;;; </summary>
        public static method TimeFromDecimal, DateTime
            required in aDecimalTime, d
            endparams
            record
                group time4 ,d
                    hour    ,d2
                    minute  ,d2
                endgroup
                group time6 ,d
                    hour    ,d2
                    minute  ,d2
                    second  ,d2
                endgroup
                outTime, DateTime
            endrecord
        proc

            try
            begin
                using ^size(aDecimalTime) select
                (4),
                begin
                    time4 = aDecimalTime
                    outTime = new DateTime(0,0,0,integer(time4.hour),integer(time4.minute),0)
                end
                (6),
                begin
                    time6 = aDecimalTime
                    outTime = new DateTime(0,0,0,integer(time6.hour),integer(time6.minute),integer(time6.second))
                end
                (),
                    throw new ApplicationException("Unsupported time format in DataUtils.TimeFromDecimal!")
                endusing
            end
            catch (ex, @Exception)
            begin
                outTime = new DateTime()
            end
            endtry

            mreturn outtime

        endmethod

        ;;; <summary>
        ;;; Convert the time portion of a .NET DateTime to a Synergy D6 (HHMMSS) time
        ;;; </summary>
        public static method D6FromTime, d6
            required in aTime, DateTime
            endparams
            record
                group time6 ,d
                    hour    ,d2
                    minute  ,d2
                    second  ,d2
                endgroup
            endrecord
        proc
            time6.hour = aTime.Hour
            time6.minute = aTime.Minute
            time6.second = aTime.Second
            mreturn time6
        endmethod

        ;;; <summary>
        ;;; Convert the time portion of a .NET DateTime to a Synergy D4 (HHMM) time
        ;;; </summary>
        public static method D4FromTime, d4
            required in aTime, DateTime
            endparams
            record
                group time4 ,d
                    hour    ,d2
                    minute  ,d2
                endgroup
            endrecord
        proc
            time4.hour = aTime.Hour
            time4.minute = aTime.Minute
            mreturn time4
        endmethod

    endclass

endnamespace

