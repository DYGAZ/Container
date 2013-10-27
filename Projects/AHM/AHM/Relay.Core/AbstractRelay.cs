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
        IRelayType RelayType { get; set; }
        Tier Tier { get; set; }
        ValidationResult RequestData();
    }
}
