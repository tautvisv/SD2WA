using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCalculationServiceConnectionLib
{
    public interface IServiceConnection
    {
        object Request(CustomCalculationServiceRequest request);
    }
}
