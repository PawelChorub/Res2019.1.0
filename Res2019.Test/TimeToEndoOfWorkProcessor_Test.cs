using Res2019.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Res2019.Test
{
    public class TimeToEndoOfWorkProcessor_Test
    {
        // dostępne godziny: 8:00 - 18:59
        // co pół godziny, wg. słownika
        [Theory]
        [InlineData("18:30")]
        [InlineData("14:00")]
        [InlineData("11:30")]
        [InlineData("08:30")]
        public void CalculateTimeToEndOfWork_UsingAvailableHoursOfAppointmentDictionary_ShouldReturnIntValue_InRange(string appointmentTime)
        {
            TimeToEndOfWorkProcessor timeToEndOfWorkProcessor = new TimeToEndOfWorkProcessor();
            var objectInstance = timeToEndOfWorkProcessor;
            var actual = timeToEndOfWorkProcessor.CalculateTimeToEndOfWork(appointmentTime);
            Assert.InRange(actual, 1, 690);
        }
        [Theory]
        [InlineData("19:00")]
        [InlineData("22:54")]
        [InlineData("05:36")]
        [InlineData("00:01")]
        public void CalculateTimeToEndOfWork_UsingAvailableHoursOfAppointmentDictionary_ShouldReturnIntValue_OutOfRange(string appointmentTime)
        {
            TimeToEndOfWorkProcessor timeToEndOfWorkProcessor = new TimeToEndOfWorkProcessor();
            var objectInstance = timeToEndOfWorkProcessor;
            var actual = timeToEndOfWorkProcessor.CalculateTimeToEndOfWork(appointmentTime);
            Assert.NotInRange(actual, 1, 660);
        }
    }
}
