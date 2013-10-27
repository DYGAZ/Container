using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relay.Core
{
    public interface IAbstractRelay
    {
        IRelayType RelayType { get; set; }
        Tier Tier { get; set; }
    }
    public class AbstractRelay : IAbstractRelay
    {
        #region Properties

        public IRelayType RelayType { get; set; }
        public Tier Tier { get; set; }

        #endregion Properties
    }
}
