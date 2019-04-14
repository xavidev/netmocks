using System;

namespace Mocks
{
    internal class Calendar
    {
        private ICalendarServie calendarService;

        public Calendar(ICalendarServie calendarService)
        {
            this.calendarService = calendarService;
        }

        public string CurrentTown { get;  set; }
        public int CurrentYear { get; set; }
        public int CurrentMonth { get; set; }
        public int[] Holidays { get; set; }

        public void DrawMonth()
        {
            // ... some business code here ...
            int[] holidays =
                calendarService.GetHolidays(CurrentYear, CurrentMonth, CurrentTown);
            // ... rest of business logic here ...
        }
    }
}