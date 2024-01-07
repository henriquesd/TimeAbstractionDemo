using FluentAssertions;
using TimeAbstractionDemo;

namespace TimeAbstractionDemoTests
{
    public class CustomTimeProviderTests
    {
        [Fact]
        public async Task MethodWithDelay_ShouldHaveNoDelay_WhenUsingNoDelayTimeProvider()
        {
            // Arrange
            var noDelayTimeProvider = new NoDelayTimeProvider();
            var demoService = new DemoService(noDelayTimeProvider);

            // Act
            var startTime = noDelayTimeProvider.GetUtcNow();
            await demoService.MethodWithDelay();
            var endTime = noDelayTimeProvider.GetUtcNow();

            // Assert
            var elapsedSeconds = (endTime - startTime).Seconds;
            elapsedSeconds.Should().Be(0);
        }

        [Fact]
        public void GetTimeOfDay_ShouldReturnMorning_WhenItIsMorning()
        {
            // Arrange
            var morningTimeProvider = new MorningTimeProvider();
            var demoService = new DemoService(morningTimeProvider);

            // Act
            var result = demoService.GetTimeOfDay();

            // Assert
            result.Should().Be("Morning");
        }

        [Fact]
        public void TimeOfDay_ShouldReturnAfternoon_WhenItIsAfternoon()
        {
            // Arrange
            var afternoonTimeProvider = new AfternoonTimeProvider();
            var demoService = new DemoService(afternoonTimeProvider);

            // Act
            var result = demoService.GetTimeOfDay();

            // Assert
            result.Should().Be("Afternoon");
        }

        [Fact]
        public void GetTimeOfDay_ShouldReturnEvening_WhenItIsEvening()
        {
            // Arrange
            var eveningTimeProvider = new EveningTimeProvider();
            var demoService = new DemoService(eveningTimeProvider);

            // Act
            var result = demoService.GetTimeOfDay();

            // Assert
            result.Should().Be("Evening");
        }

        [Fact]
        public void GetTimeOfDay_ShouldReturnNight_WhenItIsNight()
        {
            // Arrange
            var nightTimeProvider = new NightTimeProvider();
            var demoService = new DemoService(nightTimeProvider);

            // Act
            var result = demoService.GetTimeOfDay();

            // Assert
            result.Should().Be("Night");
        }
    }
}