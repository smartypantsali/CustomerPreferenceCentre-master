using Framework.Common.Enums;
using Framework.Common.Utilities;
using ReportGenerationService.Api.v1.Interfaces;

namespace ReportGenerationService.Api.v1.Models
{
    public class CustomerPreference : ICustomerPreference
    {
        public byte? SpecificMonthDay { get; set; }

        public DayOfWeek[] SpecificDaysOfWeek { get; set; }

        public DayPreferenceType Type { get; set; }
    }
}
