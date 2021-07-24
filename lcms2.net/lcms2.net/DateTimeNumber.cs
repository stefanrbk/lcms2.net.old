using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lcms2dotnet
{
    public struct DateTimeNumber
    {
        public ushort Year;
        public ushort Month;
        public ushort Day;
        public ushort Hours;
        public ushort Minutes;
        public ushort Seconds;

        public static explicit operator DateTimeNumber(DateTime dateTime) =>
            new() { 
                Year =  (ushort)dateTime.Year, 
                Month = (ushort)dateTime.Month, 
                Day = (ushort)dateTime.Day, 
                Hours = (ushort)dateTime.Hour, 
                Minutes = (ushort)dateTime.Minute, 
                Seconds = (ushort)dateTime.Second };

        public static explicit operator DateTime(DateTimeNumber dateTime) =>
            new(dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                dateTime.Hours,
                dateTime.Minutes,
                dateTime.Seconds);
    }
}
