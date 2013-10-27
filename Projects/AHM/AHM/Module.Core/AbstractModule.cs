using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHM.Core;

namespace Module.Core
{
    public interface IAbstractModule
    {
        IEnumerable<IOperation> OperationList { get; set; }
    }
}
