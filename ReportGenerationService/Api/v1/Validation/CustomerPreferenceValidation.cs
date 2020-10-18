using Framework.Common.Enums;
using Framework.Common.Interfaces;
using Framework.Common.Utilities;
using ReportGenerationService.Api.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportGenerationService.Api.v1.Validation
{
    public class CustomerPreferenceValidation : IValidate<CustomerPreference>
    {
        /// <summary>
        /// Validate CustomerPreference
        /// </summary>
        /// <param name="customerPreference"></param>
        /// <returns></returns>
        public HttpResponse Validate(CustomerPreference customerPreference)
        {
            if (customerPreference.SpecificMonthDay < 1 || customerPreference.SpecificMonthDay > 28)
            {
                return HttpResponse.TeapotResult(ApiOffences.SpecificMonthDayBetween1And28, "SpecificMonthDay");
            }

            if (customerPreference.Type == DayPreferenceType.SpecificDayOfMonth && customerPreference.SpecificMonthDay == null)
            {
                return HttpResponse.TeapotResult(ApiOffences.SpecificDayOfMonthMustHaveValue, "SpecificMonthDay");
            }

            if (customerPreference.Type == DayPreferenceType.DaysOfWeek && customerPreference.SpecificDaysOfWeek == null)
            {
                return HttpResponse.TeapotResult(ApiOffences.SpecificDaysOfWeekMustHaveValue.ErrorCode, "SpecificDaysOfWeek");
            }

            return null;
        }
    }
}
