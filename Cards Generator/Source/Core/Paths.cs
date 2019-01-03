namespace Cards_Generator
{ 
    static class Paths
    {
        public static readonly string JSONExtension = ".json";
        public static readonly string FolderSeparator = "/";

        public static readonly string ResourcesPath = "./Resources";

        // Configs
        public static readonly string ConfigPath = ResourcesPath + FolderSeparator + "Config";
        public static readonly string CardsGeneratorSettingsDataPath = ConfigPath + FolderSeparator + "CardsGeneratorSettings" + JSONExtension;
        public static readonly string UISettingsDataPath = ConfigPath + FolderSeparator + "UISettings" + JSONExtension;

        // Cards generator datas
        public static readonly string DataPath = ResourcesPath + FolderSeparator + "Data";
        public static readonly string EnchantmentsDataPath = DataPath + FolderSeparator + "Enchantments" + JSONExtension;
        public static readonly string CreatureCardsDataPath = DataPath + FolderSeparator + "CreatureCards" + JSONExtension;
        public static readonly string EquipmentCardsDataPath = DataPath + FolderSeparator + "EquipmentCards" + JSONExtension;

        // FSM
        public static readonly string FSMJsonPath = ResourcesPath + FolderSeparator + "FSM";
        public static readonly string CardsGeneratorFSMPath = FSMJsonPath + FolderSeparator + "CardsGeneratorFSM" + JSONExtension;

    }
}
