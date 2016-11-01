using System;

class CountingSundays
{

    static void Main()
    {
        //string[] WeekDays = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
        //string[] Months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        DateTime StartDay = new DateTime(1901, 1, 1);
        DateTime EndDay = new DateTime(2000, 12, 31);

        DateTime CurrDay = StartDay;
        int SundayOnFirst = 0;
        while (CurrDay != EndDay)
        {
            if (CurrDay.DayOfWeek == DayOfWeek.Sunday && CurrDay.Day == 1) SundayOnFirst++;
            CurrDay = CurrDay.AddDays(1);
        }
        Console.WriteLine(SundayOnFirst);
        Console.ReadLine();
    }
}