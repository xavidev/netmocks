using System;

public interface ICalendarServie
{
    int[] GetHolidays(int year, int month, string townCode);
}
