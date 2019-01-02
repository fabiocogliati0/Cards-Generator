namespace Cards_Generator
{ 
    static class Paths
    {
        public static readonly string JSONExtension = ".json";
        public static readonly string FolderSeparator = "/";

        public static readonly string DataPath = "./Resources/Data";
        public static readonly string CardsGeneratorSettingsDataPath = DataPath + FolderSeparator + "CardsGeneratorSettings" + JSONExtension;
        public static readonly string EnchantmentsDataPath = DataPath + FolderSeparator + "Enchantments" + JSONExtension;
        public static readonly string CreatureCardsDataPath = DataPath + FolderSeparator + "CreatureCards" + JSONExtension;
        public static readonly string EquipmentCardsDataPath = DataPath + FolderSeparator + "EquipmentCards" + JSONExtension;

        public static readonly string FSMJsonPath = "./Resources/FSM";
        public static readonly string CardsGeneratorFSMPath = FSMJsonPath + FolderSeparator + "CardsGeneratorFSM" + JSONExtension;

    }
}
