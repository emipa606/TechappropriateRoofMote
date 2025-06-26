using Verse;

namespace TechappropriateRoofMote;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class TechappropriateRoofMoteSettings : ModSettings
{
    public bool BaseOnTechlevel;
    public string HighTechLimit = "MultiAnalyzer";
    public string LowTechLimit = "Electricity";
    public bool UseHightechRoof = true;
    public bool UseLowtechRoof = true;

    public ResearchProjectDef HighTechLimitDef =>
        TechappropriateRoofMote.AllResearchProjectDefs.FirstOrDefault(def => def.defName == HighTechLimit);

    public ResearchProjectDef LowTechLimitDef =>
        TechappropriateRoofMote.AllResearchProjectDefs.FirstOrDefault(def => def.defName == LowTechLimit);

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref HighTechLimit, "HighTechLimit", "MultiAnalyzer");
        Scribe_Values.Look(ref LowTechLimit, "LowTechLimit", "Electricity");
        Scribe_Values.Look(ref BaseOnTechlevel, "BaseOnTechlevel");
        Scribe_Values.Look(ref UseLowtechRoof, "UseLowtechRoof", true);
        Scribe_Values.Look(ref UseHightechRoof, "UseHightechRoof", true);
    }
}