using FluentAssertions;
using Moq;
using TimeAbstractionDemo;

namespace TimeAbstractionDemoTests
{
    public class DemoServiceOldApproachTests
    {
        private readonly DemoServiceOldApproach _demoServiceOldApproach;
        private readonly Mock<IDateTimeOffsetProvider> _dateTimeOffsetProviderMock = new Mock<IDateTimeOffsetProvider>();

        public DemoServiceOldApproachTests()
        {
            _demoServiceOldApproach = new DemoServiceOldApproach(_dateTimeOffsetProviderMock.Object);
        }

        [Theory]
        [MemberData(nameof(TimeOfDayTestCases))]
        public void GetTimeOfDay_ShouldReturnExpectedMessage(DateTimeOffset date, string expectedMessage)
        {
            // Arrange
            _dateTimeOffsetProviderMock.Setup(c => c.UtcNow).Returns(date);

            // Act
            var result = _demoServiceOldApproach.GetTimeOfDay();

            // Assert
            result.Should().Be(expectedMessage);
        }

        public static IEnumerable<object[]> TimeOfDayTestCases()
        {
            yield return new object[] { new DateTimeOffset(2024, 1, 1, 6, 0, 0, TimeSpan.Zero), "Morning" };
            yield return new object[] { new DateTimeOffset(2024, 1, 1, 12, 59, 59, TimeSpan.Zero), "Morning" };
            yield return new object[] { new DateTimeOffset(2024, 1, 1, 13, 0, 0, TimeSpan.Zero), "Afternoon" };
            yield return new object[] { new DateTimeOffset(2024, 1, 1, 18, 59, 59, TimeSpan.Zero), "Afternoon" };
            yield return new object[] { new DateTimeOffset(2024, 1, 1, 19, 0, 0, TimeSpan.Zero), "Evening" };
            yield return new object[] { new DateTimeOffset(2024, 1, 1, 23, 59, 59, TimeSpan.Zero), "Evening" };
            yield return new object[] { new DateTimeOffset(2024, 1, 1, 00, 0, 0, TimeSpan.Zero), "Night" };
            yield return new object[] { new DateTimeOffset(2024, 1, 1, 05, 59, 59, TimeSpan.Zero), "Night" };
        }
    }
}