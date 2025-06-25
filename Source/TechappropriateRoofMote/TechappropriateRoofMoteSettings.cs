using Verse;

namespace TechappropriateRoofMote;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class TechappropriateRoofMoteSettings : ModSettings
{
    public bool UseHightechRoof = true;
    public bool UseLowtechRoof = true;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref UseLowtechRoof, "UseLowtechRoof", true);
        Scribe_Values.Look(ref UseHightechRoof, "UseHightechRoof", true);
    }
}