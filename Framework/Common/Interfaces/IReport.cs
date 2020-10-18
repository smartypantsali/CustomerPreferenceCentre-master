using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Common.Interfaces
{
    public interface IReport<T1, T2>
    {
        Dictionary<string, Stack<string>> Report { get; }
        T1 GenerateReportForSingle(T2 arg);
        T1 GenerateReportForAll(T2[] arg);
    }
}
