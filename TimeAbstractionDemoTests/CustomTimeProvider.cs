namespace TimeAbstractionDemoTests
{
    public class NoDelayTimeProvider : TimeProvider
    {
        public override ITimer CreateTimer(
            TimerCallback callback,
            object? state,
            TimeSpan dueTime,
            TimeSpan period)
        {
            return base.CreateTimer(callback, state, TimeSpan.Zero, period);
        }
    }

    public class MorningTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return new DateTimeOffset(2024, 1, 1, 8, 0, 0, TimeSpan.Zero);
        }
    }

    public class AfternoonTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return new DateTimeOffset(2024, 1, 1, 15, 0, 0, TimeSpan.Zero);
        }
    }

    public class EveningTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return new DateTimeOffset(2024, 1, 1, 20, 0, 0, TimeSpan.Zero);
        }
    }

    public class NightTimeProvider : TimeProvider
    {
        public override DateTimeOffset GetUtcNow()
        {
            return new DateTimeOffset(2024, 1, 1, 3, 0, 0, TimeSpan.Zero);
        }
    }
}