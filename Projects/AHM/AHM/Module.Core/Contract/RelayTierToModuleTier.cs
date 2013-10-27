namespace Module.Core.Contract
{
    interface IRelayTierToModuleTier
    {
        Tier ModuleTier { get; set; }
        Relay.Core.Tier RelayTier { get; set; }
    }
    class RelayTierToModuleTier : IRelayTierToModuleTier
    {
        #region Properties

        public Tier ModuleTier { get; set; }
        public Relay.Core.Tier RelayTier { get; set; }

        #endregion Properties

        public Relay.Core.Tier MapModuleTierToRelayTier()
        {
            var response = new Relay.Core.Tier
            {
                FieldList = ModuleTier.FieldList,
                TypeName = ModuleTier.TypeName,
            };

            return response;
        }

        public Tier MapRelayTierToModuleTier()
        {
            var response = new Tier
            {
                FieldList = RelayTier.FieldList,
                TypeName = RelayTier.TypeName,
            };

            return response;
        }
    }
}
