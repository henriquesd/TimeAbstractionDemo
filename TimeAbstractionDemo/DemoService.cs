namespace TimeAbstractionDemo
{
    public class DemoService
    {
        private readonly TimeProvider _timeProvider;

        public DemoService(TimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public string GetTimeOfDay()
        {
            var currentTime = _timeProvider.GetUtcNow();

            var message = currentTime.Hour switch
            {
                >= 6 and <= 12 => "Morning",
                > 12 and <= 18 => "Afternoon",
                > 18 and <= 24 => "Evening",
                _ => "Night"
            };

            return message;
        }

        public async Task MethodWithDelay()
        {
            Console.WriteLine($"Start of Task.Delay: {_timeProvider.GetUtcNow()}");
            await Task.Delay(TimeSpan.FromSeconds(3), _timeProvider);
            Console.WriteLine($"End of Task.Delay: {_timeProvider.GetUtcNow()}");
        }
    }
}