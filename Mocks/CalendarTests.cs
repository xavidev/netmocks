using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Mocks
{
    [TestFixture]
    public class CalendarTests
    {
        [Test]
        public void ClientAsksCalendarService()
        {
            int year = 2009;
            int month = 2;
            string townCode = "b002";
            ICalendarServie serviceMock =
                MockRepository.GenerateStrictMock<ICalendarServie>();
            serviceMock.Expect(
                x => x.GetHolidays(
                    year, month, townCode)).Return(new int[] { 1, 5 });

            Calendar calendar = new Calendar(serviceMock);
            calendar.CurrentTown = townCode;
            calendar.CurrentYear = year;
            calendar.CurrentMonth = month;
            calendar.DrawMonth(); // the SUT

            serviceMock.VerifyAllExpectations();
        }

        [Test]
        public void DrawHolidaysWithStub()
        {
            int year = 2009;
            int month = 2;
            string townCode = "b002";
            ICalendarServie serviceStub =
                MockRepository.GenerateStub<ICalendarServie>();
            serviceStub.Stub(
                x => x.GetHolidays(year, month, townCode)).Return(
                new int[] { 1, 5 });

            Calendar calendar = new Calendar(serviceStub);
            calendar.CurrentTown = townCode;
            calendar.CurrentYear = year;
            calendar.CurrentMonth = month;
            calendar.DrawMonth();

            Assert.AreEqual(1, calendar.Holidays[0]);
            Assert.AreEqual(1, calendar.Holidays[1]);
        }
    }
}

/* Diferencia entre Stub y el Mock
    La diferencia es que este test mantendría la luz verde incluso
    aunque no se llamase a GetHolidays, siempre que la propiedad Holidays
    de calendar tuviese los valores indicados en las afirmaciones del
    final. También pasaría aunque la llamada se hiciese cien veces y 
    aunque se hicieran llamadas a otros métodos del servicio.

    Mock --> Más precisión/control && Test más frágil
    Stub --> Menos precisión/control && Test menos frágil

    Típico caso de uso de stub: 'Si se produce esta X llamada al servicio
    la respuesta tiene que ser Y'. 
    */
