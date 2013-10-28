using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHM.Core;

namespace Relay.Core
{
    public interface IAbstractRelay
    {
        Tier RelayTier { get; set; }
        ValidationResults ValidationResults { get; set; }
        void GetData();
    }
}
