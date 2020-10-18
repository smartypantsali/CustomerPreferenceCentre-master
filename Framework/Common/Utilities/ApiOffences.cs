namespace Framework.Common.Utilities
{
    public static class ApiOffences
    {
        /// <summary>
        /// Check if days specified is between 1-28
        /// </summary>
        public static ApiOffence SpecificMonthDayBetween1And28 => "value_must_be_between_1_and_28";

        /// <summary>
        /// Check if SpecificMonthDay has value. When SpecificDayOfMonth is selected as type
        /// </summary>
        public static ApiOffence SpecificDayOfMonthMustHaveValue => "specificDayOfMonth_must_be_specified";


        /// <summary>
        /// Check if SpecificDaysOfWeek has value. When DaysOfWeek is selected as type
        /// </summary>
        public static ApiOffence SpecificDaysOfWeekMustHaveValue => "specificDaysOfWeek_must_be_specified";

        /// <summary>
        /// Check if SpecificDaysOfWeek has value. When DaysOfWeek is selected as type
        /// </summary>
        public static ApiOffence CustomerCannotBeNull => "customer_cannot_be_null";
    }
}
