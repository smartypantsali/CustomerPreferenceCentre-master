using Framework.Common.Interfaces;
using Framework.Common.Utilities;
using ReportGenerationService.Api.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportGenerationService.Api.v1.Validation
{
    public class CustomerValidation : IValidate<Customer>
    {
        private readonly IValidate<CustomerPreference> _valCustomerPreference;

        public CustomerValidation(IValidate<CustomerPreference> valCustomerPreference)
        {
            _valCustomerPreference = valCustomerPreference;
        }

        /// <summary>
        /// Validate Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public HttpResponse Validate(Customer customer)
        {
            var valResult = _valCustomerPreference.Validate(customer.CustomerPreference);
            if (valResult != null)
            {
                return valResult;
            }

            return null;
        }
    }
}
