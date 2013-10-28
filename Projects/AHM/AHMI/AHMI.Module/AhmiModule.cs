using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module.Core;

namespace AHMI.Module
{
    public class AhmiModule : IAbstractModule
    {
        public IEnumerable<IOperation> OperationList { get; set; }
        
    }
}
