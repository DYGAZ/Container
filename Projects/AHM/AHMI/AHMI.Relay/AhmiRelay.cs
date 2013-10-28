using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Relay.Core;
using AHM.Core;

namespace AHMI.Relay
{
    public class AhmiRelay : IAbstractRelay
    {
        #region Properties

        public ValidationResults ValidationResults { get; set; }
        public Tier RelayTier { get; set; }

        #endregion Properties

        public AhmiRelay()
        {
            var ValidationResults = new ValidationResults();
        }

        public void GetData()
        {
            RelayTier = getTier();
        }

        private Tier getTier()
        {
            //Need to Implement when we can get data from Arduino
            //
            return new Tier
            {
                TypeName = "Test",
                FieldList = new List<Field>
                {
                    new Field{ Name = "Test", Value = 1.0f}
                }
            };
        }

        
    }
}
