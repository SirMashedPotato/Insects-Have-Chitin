using Verse;

namespace Chitin
{
    class Chitin_ModSettings : ModSettings
    {
        //settings
        public bool enableVFEInsectoids = enableVFEInsectoids_def;
        public bool enableLoggingOnGameStart = enableLoggingOnGameStart_def;
        public bool useVFEInsectoidsChitin = useVFEInsectoidsChitin_def;
        public bool useAlphaAnimalsChitin = useAlphaAnimalsChitin_def;
        public bool enableVFEInsectoidsChitinRecipes = enableVFEInsectoidsChitinRecipes_def;
        public bool enableAlphaAnimalsChitinRecipes = enableAlphaAnimalsChitinRecipes_def;
        public int MorrowRim_chitinMultiplier = MorrowRim_chitinMultiplier_def;

        //defaults
        public static readonly bool enableVFEInsectoids_def = false;
        public static readonly bool enableLoggingOnGameStart_def = false;
        public static readonly bool useVFEInsectoidsChitin_def = false;
        public static readonly bool useAlphaAnimalsChitin_def = false;
        public static readonly bool enableVFEInsectoidsChitinRecipes_def = true;
        public static readonly bool enableAlphaAnimalsChitinRecipes_def = true;
        public static readonly int MorrowRim_chitinMultiplier_def = 100;

        //save settings
        public override void ExposeData()
        {
            Scribe_Values.Look(ref enableVFEInsectoids, "MorrowRim_enableVFEInsectoids", enableVFEInsectoids_def);
            Scribe_Values.Look(ref enableLoggingOnGameStart, "MorrowRim_enableLoggingOnGameStart", enableLoggingOnGameStart_def);
            Scribe_Values.Look(ref useVFEInsectoidsChitin, "MorrowRim_useVFEInsectoidsChitin", useVFEInsectoidsChitin_def);
            Scribe_Values.Look(ref useAlphaAnimalsChitin, "MorrowRim_useAlphaAnimalsChitin", useAlphaAnimalsChitin_def);
            Scribe_Values.Look(ref enableVFEInsectoidsChitinRecipes, "MorrowRim_enableVFEInsectoidsChitinRecipes", enableVFEInsectoidsChitinRecipes_def);
            Scribe_Values.Look(ref enableAlphaAnimalsChitinRecipes, "MorrowRim_enableAlphaAnimalsChitinRecipes", enableAlphaAnimalsChitinRecipes_def);
            Scribe_Values.Look(ref MorrowRim_chitinMultiplier, "MorrowRim_chitinMultiplier", MorrowRim_chitinMultiplier_def);
            base.ExposeData();
        }

        public static void ResetSettings(Chitin_ModSettings settings)
        {
            settings.enableVFEInsectoids = enableVFEInsectoids_def;
            settings.enableLoggingOnGameStart = enableLoggingOnGameStart_def;
            settings.useVFEInsectoidsChitin = useVFEInsectoidsChitin_def;
            settings.useAlphaAnimalsChitin = useAlphaAnimalsChitin_def;
            settings.enableVFEInsectoidsChitinRecipes = enableVFEInsectoidsChitinRecipes_def;
            settings.enableAlphaAnimalsChitinRecipes = enableAlphaAnimalsChitinRecipes_def;
            settings.MorrowRim_chitinMultiplier = MorrowRim_chitinMultiplier_def;
        }
    }
}
