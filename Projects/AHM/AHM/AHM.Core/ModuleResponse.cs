using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHM.Core
{
    public interface IModuleResponse
    {
        ValidationResults ValidationResults { get; set; }      
    }

    public interface IGetResponse : IModuleResponse
    {
        Tier Data { get; set; }
    }
}
