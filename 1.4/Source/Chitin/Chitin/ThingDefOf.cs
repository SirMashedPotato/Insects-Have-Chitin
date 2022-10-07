using System;
using Verse;
using RimWorld;

namespace Chitin
{
    [DefOf]
    public static class ThingDefOf
    {
        static ThingDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
        }

        public static ThingDef InsectChitin;

        //public static ThingDef Leather_Chitin;
    }
}
