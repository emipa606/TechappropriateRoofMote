using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace TechappropriateRoofMote;

[StaticConstructorOnStartup]
public static class TechappropriateRoofMote
{
    private static readonly ThingDef moteTempRoofLowTech = ThingDef.Named("Mote_TempRoof_LowTech");
    private static readonly ThingDef moteTempRoofHighTech = ThingDef.Named("Mote_TempRoof_HighTech");
    public static readonly List<ResearchProjectDef> AllResearchProjectDefs;


    static TechappropriateRoofMote()
    {
        new Harmony("Mlie.TechappropriateRoofMote").PatchAll(Assembly.GetExecutingAssembly());
        AllResearchProjectDefs =
            DefDatabase<ResearchProjectDef>.AllDefsListForReading.OrderBy(def => def.label).ToList();
    }

    public static ThingDef GetRoofMote()
    {
        if (TechappropriateRoofMoteMod.Instance.Settings.UseHightechRoof)
        {
            if (TechappropriateRoofMoteMod.Instance.Settings.BaseOnTechlevel &&
                Faction.OfPlayerSilentFail.def.techLevel > TechLevel.Industrial ||
                !TechappropriateRoofMoteMod.Instance.Settings.BaseOnTechlevel &&
                TechappropriateRoofMoteMod.Instance.Settings.LowTechLimitDef.IsFinished)
            {
                return moteTempRoofHighTech;
            }
        }

        if (!TechappropriateRoofMoteMod.Instance.Settings.UseLowtechRoof)
        {
            return ThingDefOf.Mote_TempRoof;
        }

        if (TechappropriateRoofMoteMod.Instance.Settings.BaseOnTechlevel &&
            Faction.OfPlayerSilentFail.def.techLevel < TechLevel.Industrial ||
            !TechappropriateRoofMoteMod.Instance.Settings.BaseOnTechlevel &&
            !TechappropriateRoofMoteMod.Instance.Settings.HighTechLimitDef.IsFinished)
        {
            return moteTempRoofLowTech;
        }

        return ThingDefOf.Mote_TempRoof;
    }
}