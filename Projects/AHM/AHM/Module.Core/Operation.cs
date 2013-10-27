using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHM.Core;

namespace Module.Core
{
    public interface IOperation
    {
        Action Action { get; set; }
        IModuleResponse Response { get; set; }
    }
}
