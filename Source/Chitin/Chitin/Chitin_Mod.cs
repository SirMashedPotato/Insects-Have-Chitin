using UnityEngine;
using Verse;
using System;

namespace Chitin
{
    class Chitin_Mod : Mod
    {
        Chitin_ModSettings settings;
        public Chitin_Mod(ModContentPack contentPack) : base(contentPack)
        {
            this.settings = GetSettings<Chitin_ModSettings>();
        }

        public override string SettingsCategory() => "Insects Have Chitin";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);

            listing_Standard.Label("MorrowRim_chitinMultiplier".Translate() + " (" + settings.MorrowRim_chitinMultiplier + "%)");
            settings.MorrowRim_chitinMultiplier = (int)Math.Round(listing_Standard.Slider(settings.MorrowRim_chitinMultiplier, 10, 200) / 10) * 10;
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_enableLoggingOnGameStart".Translate(), ref settings.enableLoggingOnGameStart);
            listing_Standard.Gap();

            /* VFE Insects */

            if (UseAlphaAnimalsChitin())
            {
                settings.useVFEInsectoidsChitin = false;
            }
            if (ChitinUtility.checkVFEInsects())
            {

                listing_Standard.GapLine();
                listing_Standard.CheckboxLabeled("MorrowRim_enableVFEInsectoids".Translate(), ref settings.enableVFEInsectoids);
                listing_Standard.Gap();
                listing_Standard.CheckboxLabeled("MorrowRim_useVFEInsectoidsChitin".Translate(), ref settings.useVFEInsectoidsChitin);
                listing_Standard.Gap();
                listing_Standard.CheckboxLabeled("MorrowRim_enableVFEInsectoidsChitinRecipes".Translate(), ref settings.enableVFEInsectoidsChitinRecipes);
                listing_Standard.Gap();
            }

            /* Alpha Animals */

            if (UseVFEInsectoidsChitin())
            {
                settings.useAlphaAnimalsChitin = false;
            }
            if (ChitinUtility.checkAlphaAnimals())
            {
                listing_Standard.GapLine();
                listing_Standard.CheckboxLabeled("MorrowRim_useAlphaAnimalsChitin".Translate(), ref settings.useAlphaAnimalsChitin);
                listing_Standard.Gap();
                listing_Standard.CheckboxLabeled("MorrowRim_enableAlphaAnimalsChitinRecipes".Translate(), ref settings.enableAlphaAnimalsChitinRecipes);
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();
            listing_Standard.Label("MorrowRim_restartWarning".Translate());

            //reset
            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "Chitin_reset".Translate());
            if (Widgets.ButtonText(rectDefault, "Chitin_reset".Translate(), true, true, true))
            {
                Chitin_ModSettings.ResetSettings(settings);
            }

            listing_Standard.End();
            base.DoSettingsWindowContents(inRect);
        }

        /* getters */

        public static bool EnableVFEInsectoids()
        {
            return LoadedModManager.GetMod<Chitin_Mod>().GetSettings<Chitin_ModSettings>().enableVFEInsectoids;
        }

        public static bool EnableLoggingOnGameStart()
        {
            return LoadedModManager.GetMod<Chitin_Mod>().GetSettings<Chitin_ModSettings>().enableLoggingOnGameStart;
        }

        public static bool UseVFEInsectoidsChitin()
        {
            return LoadedModManager.GetMod<Chitin_Mod>().GetSettings<Chitin_ModSettings>().useVFEInsectoidsChitin;
        }
        public static bool UseAlphaAnimalsChitin()
        {
            return LoadedModManager.GetMod<Chitin_Mod>().GetSettings<Chitin_ModSettings>().useAlphaAnimalsChitin;
        }

        public static bool EnableVFEInsectoidsChitinRecipes()
        {
            return LoadedModManager.GetMod<Chitin_Mod>().GetSettings<Chitin_ModSettings>().enableVFEInsectoidsChitinRecipes;
        }
        public static bool EnableAlphaAnimalsChitinRecipes()
        {
            return LoadedModManager.GetMod<Chitin_Mod>().GetSettings<Chitin_ModSettings>().enableAlphaAnimalsChitinRecipes;
        }

        public static float GetChitinMultiplier()
        {
            float temp = LoadedModManager.GetMod<Chitin_Mod>().GetSettings<Chitin_ModSettings>().MorrowRim_chitinMultiplier;
            temp /= 100f;
            return temp;
        }
    }
}

