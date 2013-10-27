namespace Module.Core.Contract
{
    interface IAhmTierToModuleTier
    {
        Tier ModuleTier { get; set; }
        AHM.Core.Tier AhmTier { get; set; }
    }
    class AhmTierToModuleTier : IAhmTierToModuleTier
    {
        #region Properties

        public Tier ModuleTier { get; set; }
        public AHM.Core.Tier AhmTier { get; set; }

        #endregion Properties

        public AHM.Core.Tier MapModuleTierToAhmTier()
        {
            var response = new AHM.Core.Tier
            {
                FieldList = ModuleTier.FieldList,
                TypeName = ModuleTier.TypeName,
            };

            return response;
        }

        public Tier MapAhmTierToModuleTier()
        {
            var response = new Tier
            {
                FieldList = AhmTier.FieldList,
                TypeName = AhmTier.TypeName,
            };

            return response;
        }
    }
}