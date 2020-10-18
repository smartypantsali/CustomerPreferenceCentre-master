using Framework.Common.Enums;
using Framework.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReportGenerationService.Api.v1.Models
{
    public abstract class BaseReport<T1, T2> : IReport<T1, T2>
    {
        [JsonIgnore]
        public byte NumberOfDays { get; }

        public virtual Dictionary<string, Stack<string>> Report { get; protected set; }

        public BaseReport()
        {
            // TODO: Can be configured as a config variable and mocked for unit tests
            NumberOfDays = 90;
        }

        public abstract T1 GenerateReportForSingle(T2 arg);

        public abstract T1 GenerateReportForAll(T2[] arg);
    }
}
