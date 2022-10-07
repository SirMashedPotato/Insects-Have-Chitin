using UnityEngine;
using Verse;
using RimWorld;
using System;
using System.Linq;
using System.Xml;

namespace Chitin
{
    class ChitinUtility
    {

        /* Al[pha Animals */
        public static bool checkAlphaAnimals()
        {
            return LoadedModManager.RunningModsListForReading.Any(x => x.Name == "Alpha Animals");
        }

        public static bool comboCheckAlphaAnimals()
        {
            return checkAlphaAnimals() && Chitin_Mod.UseAlphaAnimalsChitin();
        }

        public static bool comboCheckAlphaAnimalsRecipe()
        {
            return checkAlphaAnimals() && !Chitin_Mod.EnableAlphaAnimalsChitinRecipes();
        }

        /* VFE Insects*/

        public static bool checkVFEInsects()
        {
            return LoadedModManager.RunningModsListForReading.Any(x => x.Name == "Vanilla Factions Expanded - Insectoids");
        }

        public static bool comboCheckVFEInsects()
        {
            return checkVFEInsects() && Chitin_Mod.UseVFEInsectoidsChitin();
        }

        public static bool comboCheckVFEInsectsRecipe()
        {
            return checkVFEInsects() && !Chitin_Mod.EnableVFEInsectoidsChitinRecipes();
        }

        /* generic */

        public static void switchChitin(ThingDef target, string newChitin)
        {
            ThingDef newChitinDef = DefDatabase<ThingDef>.GetNamed(newChitin);
            if (newChitinDef != null) target.race.leatherDef = newChitinDef;
        }

        public static void EditRecipeDef(string recipeString)
        {
            RecipeDef target = DefDatabase<RecipeDef>.GetNamed(recipeString);
            target.recipeUsers.Clear();
            if (Chitin_Mod.EnableLoggingOnGameStart())
            {
                if (!target.recipeUsers.Any()) Log.Message("Recipe users removed for: " + target);
            }
        }
    }
}
