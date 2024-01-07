using FluentAssertions;
using Microsoft.Extensions.Time.Testing;
using Moq;
using TimeAbstractionDemo;

namespace TimeAbstractionDemoTests
{
    public class DemoServiceTests
    {
        private readonly DemoService _demoService;
        private readonly Mock<TimeProvider> _timeProviderMock = new Mock<TimeProvider>();

        public DemoServiceTests()
        {
            _demoService = new DemoService(_timeProviderMock.Object);
        }

        #region Mocking TimeProvider examples

        [Theory]
        [MemberData(nameof(TimeOfDayTestCases))]
        public void GetTimeOfDay_ShouldReturnExpectedTimeOfDay(DateTimeOffset date, string expectedMessage)
        {
            // Arrange
            _timeProviderMock.Setup(c => c.GetUtcNow()).Returns(date);

            // Act
            var result = _demoService.GetTimeOfDay();

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

        #endregion

        #region FakeTimeProvider examples

        [Fact]
        public void GetTimeOfDay_ShouldReturnMorning_WhenItIsMorning()
        {
            // Arrange
            var fakeTimeProvider = new FakeTimeProvider();
            fakeTimeProvider.SetUtcNow(new DateTime(2024, 1, 1, 8, 0, 0));

            var demoService = new DemoService(fakeTimeProvider);

            // Act
            var result = demoService.GetTimeOfDay();

            // Assert
            result.Should().Be("Morning");
        }

        [Fact]
        public void TimeOfDay_ShouldReturnAfternoon_WhenItIsAfternoon()
        {
            // Arrange
            var fakeTimeProvider = new FakeTimeProvider();
            fakeTimeProvider.SetUtcNow(new DateTime(2024, 1, 1, 15, 0, 0));

            var demoService = new DemoService(fakeTimeProvider);

            // Act
            var result = demoService.GetTimeOfDay();

            // Assert
            result.Should().Be("Afternoon");
        }

        [Fact]
        public void GetTimeOfDay_ShouldReturnEvening_WhenItIsEvening()
        {
            // Arrange
            var fakeTimeProvider = new FakeTimeProvider();
            fakeTimeProvider.SetUtcNow(new DateTime(2024, 1, 1, 20, 0, 0));

            var demoService = new DemoService(fakeTimeProvider);

            // Act
            var result = demoService.GetTimeOfDay();

            // Assert
            result.Should().Be("Evening");
        }

        [Fact]
        public void GetTimeOfDay_ShouldReturnNight_WhenItIsNight()
        {
            // Arrange
            var fakeTimeProvider = new FakeTimeProvider();
            fakeTimeProvider.SetUtcNow(new DateTime(2024, 1, 1, 3, 0, 0));

            var demoService = new DemoService(fakeTimeProvider);

            // Act
            var result = demoService.GetTimeOfDay();

            // Assert
            result.Should().Be("Night");
        }
        #endregion
    }
}