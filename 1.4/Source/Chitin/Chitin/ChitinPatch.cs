using Verse;
using RimWorld;
using System.Reflection;

namespace Chitin
{

    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            int patched = 0;
            DefDatabase<ThingDef>.AllDefsListForReading.ForEach(action: chitin =>
            {
                bool vfeiChitinSkip = false;
                if (chitin?.race?.leatherDef == null && (chitin?.race?.FleshType == FleshTypeDefOf.Insectoid || chitin?.race?.useMeatFrom?.ToString() == "Megaspider"))
                {
                    if (chitin.butcherProducts != null && chitin.butcherProducts.Any(x => x.thingDef.defName == "VFEI_Chitin") && !Chitin_Mod.EnableVFEInsectoids())
                    {
                        vfeiChitinSkip = true;
                    }
                    if (!vfeiChitinSkip)
                    {
                        chitin.race.leatherDef = ThingDefOf.InsectChitin;
                    }
                }
                if (chitin?.race?.leatherDef == ThingDefOf.InsectChitin)
                {
                    float f = (chitin.GetStatValueAbstract(StatDefOf.MeatAmount) / 5) * Chitin_Mod.GetChitinMultiplier();
                    chitin.SetStatBaseValue(StatDefOf.LeatherAmount, f);
                    patched++;

                    /* mod settings */
                    if (ChitinUtility.comboCheckAlphaAnimals())
                    {
                        ChitinUtility.switchChitin(chitin, "Leather_Chitin");
                    }

                    if (ChitinUtility.comboCheckVFEInsects())
                    {
                        ChitinUtility.switchChitin(chitin, "VFEI_Chitin");
                    }

                    if (Chitin_Mod.EnableLoggingOnGameStart())
                    {
                        Log.Message("Chitin mod has patched " + patched + ": " + chitin.defName + ", giving it: " + chitin.GetStatValueAbstract(StatDefOf.LeatherAmount) + " " + chitin.race.leatherDef);
                    }
                }
            });

            /* recipes checks */
            if (ChitinUtility.comboCheckAlphaAnimalsRecipe())
            {
                ChitinUtility.EditRecipeDef("AlphaChitin_ToChitinPlate");
                ChitinUtility.EditRecipeDef("BulkAlphaChitin_ToChitinPlate");
                ChitinUtility.EditRecipeDef("ChitinPlateToAlphaChitin");
                ChitinUtility.EditRecipeDef("BulkChitinPlateToAlphaChitin");
            }
            if (ChitinUtility.comboCheckVFEInsectsRecipe())
            {
                ChitinUtility.EditRecipeDef("VFEIChitin_ToChitinPlate");
                ChitinUtility.EditRecipeDef("BulkVFEIChitin_ToChitinPlate");
                ChitinUtility.EditRecipeDef("ChitinPlateToVFEIChitin");
                ChitinUtility.EditRecipeDef("BulkChitinPlateToVFEIChitin");
            }
        }
    }
}