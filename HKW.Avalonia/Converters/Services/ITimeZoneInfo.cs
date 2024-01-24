using System;

namespace HKW.HKWAvalonia.Converters.Services
{
    internal interface ITimeZoneInfo
    {
        public TimeZoneInfo Utc { get; }

        public TimeZoneInfo Local { get; }
    }
}
