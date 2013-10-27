using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Relay.Core
{
    public interface IRelayType
    {
        string TypeName { get; set; }       //Possibly swap out for enum so that we dont have to add condition for each new type further up. Can define 3 or so enums that will cover most if not all cases                                            
    }                                       //and then we only have to write new code at the relay level
}
