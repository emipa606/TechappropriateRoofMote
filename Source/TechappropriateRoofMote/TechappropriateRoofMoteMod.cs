using System.Linq;
using Mlie;
using UnityEngine;
using Verse;

namespace TechappropriateRoofMote;

[StaticConstructorOnStartup]
internal class TechappropriateRoofMoteMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static TechappropriateRoofMoteMod Instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public TechappropriateRoofMoteMod(ModContentPack content) : base(content)
    {
        Instance = this;
        Settings = GetSettings<TechappropriateRoofMoteSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    public TechappropriateRoofMoteSettings Settings { get; }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Tech-appropriate Roof Mote";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.CheckboxLabeled("TARM.BaseOnTechlevel".Translate(), ref Settings.BaseOnTechlevel,
            "TARM.BaseOnTechlevelTT".Translate());
        listingStandard.CheckboxLabeled("TARM.UseLowtechRoof".Translate(), ref Settings.UseLowtechRoof);
        if (!Settings.BaseOnTechlevel && Settings.UseLowtechRoof &&
            listingStandard.ButtonTextLabeled("TARM.LowTechLimit".Translate(), Settings.LowTechLimitDef?.label))
        {
            Find.WindowStack.Add(new FloatMenu(TechappropriateRoofMote.AllResearchProjectDefs
                .Select(def => new FloatMenuOption(def.label, () =>
                {
                    Settings.LowTechLimit = def.defName;
                    Settings.Write();
                })).ToList()));
        }

        listingStandard.CheckboxLabeled("TARM.UseHightechRoof".Translate(), ref Settings.UseHightechRoof);
        if (!Settings.BaseOnTechlevel && Settings.UseHightechRoof &&
            listingStandard.ButtonTextLabeled("TARM.LowTechLimit".Translate(), Settings.HighTechLimitDef?.label))
        {
            Find.WindowStack.Add(new FloatMenu(TechappropriateRoofMote.AllResearchProjectDefs
                .Select(def => new FloatMenuOption(def.label, () =>
                {
                    Settings.HighTechLimit = def.defName;
                    Settings.Write();
                })).ToList()));
        }

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("TARM.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }
}