using Framework.Common.Interfaces;
using Framework.Common.Utilities;
using ReportGenerationService.Api.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportGenerationService.Api.v1.Interfaces
{
    public interface ICustomer
    {
        CustomerPreference CustomerPreference { get; set; }

        string Name { get; set; }

        HttpResponse Validate(IValidate<Customer> validate);

        CustomerPreferenceReport GenerateSingleCustomerReport(IReport<CustomerPreferenceReport, Customer> report);

        static CustomerPreferenceReport GenerateAllCustomersReport(Customer[] customers, IReport<CustomerPreferenceReport, Customer> report)
        {
            throw new NotImplementedException();
        }
    }
}
