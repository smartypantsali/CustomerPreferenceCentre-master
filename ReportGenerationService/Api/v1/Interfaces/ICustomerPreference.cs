using Framework.Common.Enums;
using Framework.Common.Interfaces;
using Framework.Common.Utilities;
using ReportGenerationService.Api.v1.Models;

namespace ReportGenerationService.Api.v1.Interfaces
{
    public interface ICustomerPreference
    {
        byte? SpecificMonthDay { get; set; }

        Framework.Common.Enums.DayOfWeek[] SpecificDaysOfWeek { get; set; }

        DayPreferenceType Type { get; set; }
    }
}
