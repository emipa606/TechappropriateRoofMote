using HarmonyLib;
using RimWorld;
using Verse;

namespace TechappropriateRoofMote;

[HarmonyPatch(typeof(ThingMaker), nameof(ThingMaker.MakeThing))]
public static class ThingMaker_MakeThing
{
    public static void Prefix(ref ThingDef def)
    {
        if (def != ThingDefOf.Mote_TempRoof)
        {
            return;
        }

        def = TechappropriateRoofMote.GetRoofMote();
    }
}