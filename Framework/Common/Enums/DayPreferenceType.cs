using System.Text.Json.Serialization;

namespace Framework.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DayPreferenceType
    {
        Never,
        EveryDay,
        DaysOfWeek,
        SpecificDayOfMonth
    }
}
