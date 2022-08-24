using Moq;
using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests {
    public class TirePressureMonitoringSystemTests {
        [Test]
        public void AlarmOnInicialTest()
        {
            var alarm = new Alarm();

            Assert.True(!alarm.AlarmOn);
        }

        [TestCase(TirePressureMonitoringSystemUtils.LowPressureThreshold)]
        [TestCase(TirePressureMonitoringSystemUtils.HighPressureThreshold)]
        [TestCase(TirePressureMonitoringSystemUtils.LowPressureThreshold + 1)]
        [TestCase(TirePressureMonitoringSystemUtils.HighPressureThreshold - 1)]
        public void AlarmOnFalseFlagTest(double pressureThresholdValue)
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(pressureThresholdValue);

            var alarm = new Alarm(mockSensor.Object);
            alarm.Check();

            Assert.False(alarm.AlarmOn);
        }

        [TestCase(TirePressureMonitoringSystemUtils.LowPressureThreshold - 1)]
        [TestCase(TirePressureMonitoringSystemUtils.HighPressureThreshold + 1)]
        public void AlarmOnTrueFlagTest(double pressureThresholdValue)
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(pressureThresholdValue);

            var alarm = new Alarm(mockSensor.Object);
            alarm.Check();

            Assert.True(alarm.AlarmOn);
        }

    }
}
