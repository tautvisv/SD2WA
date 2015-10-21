using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces
{
    public interface IDto
    {
        bool? RefreshData { get; set; }
    }
}
