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
    private static readonly ResearchProjectDef electricity = ResearchProjectDef.Named("Electricity");
    private static readonly ResearchProjectDef multiAnalyzer = ResearchProjectDef.Named("MultiAnalyzer");


    static TechappropriateRoofMote()
    {
        new Harmony("Mlie.TechappropriateRoofMote").PatchAll(Assembly.GetExecutingAssembly());
    }

    public static ThingDef GetRoofMote()
    {
        if (TechappropriateRoofMoteMod.Instance.Settings.UseHightechRoof && multiAnalyzer.IsFinished)
        {
            return moteTempRoofHighTech;
        }

        if (TechappropriateRoofMoteMod.Instance.Settings.UseLowtechRoof && !electricity.IsFinished)
        {
            return moteTempRoofLowTech;
        }

        return ThingDefOf.Mote_TempRoof;
    }
}