namespace TimeAbstractionDemo
{
    public class DemoServiceOldApproach
    {
        private readonly IDateTimeOffsetProvider _dateTimeOffsetProvider;

        public DemoServiceOldApproach(IDateTimeOffsetProvider dateTimeOffsetProvider)
        {
            _dateTimeOffsetProvider = dateTimeOffsetProvider;
        }

        public string GetTimeOfDay()
        {
            //var currentTime = DateTimeOffset.UtcNow;
            //var currentTime = DateTime.Now;

            var currentTime = _dateTimeOffsetProvider.UtcNow;

            var message = currentTime.Hour switch
            {
                >= 6 and <= 12 => "Morning",
                > 12 and <= 18 => "Afternoon",
                > 18 and <= 24 => "Evening",
                _ => "Night"
            };

            return message;
        }
    }

    public interface IDateTimeOffsetProvider
    {
        DateTimeOffset UtcNow { get; }
    }

    public class DateTimeOffsetProvider : IDateTimeOffsetProvider
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}