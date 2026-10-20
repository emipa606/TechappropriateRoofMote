# GitHub Copilot Instructions for Tech-appropriate Roof Mote Mod

## Mod Overview and Purpose

The **Tech-appropriate Roof Mote** mod for RimWorld is designed to enhance the aesthetic and immersive experience of roof construction in the game by changing roof mote graphics according to the technological progress of a colony. This mod addresses the default, somewhat anachronistic appearance of roofs being constructed as steel corrugated types regardless of the colony's tech level. 

### Key Features and Systems

1. **Dynamic Roof Graphics**:  
   - **Wood-roof Graphic**: Displayed by default until the colony researches Electricity.
   - **Default Steel-roof Graphic**: Used once the Electricity research is done.
   - **Advanced Plasteel-roof Graphic**: Displays after researching Multianalyzer.

2. **Customization Options**:
   - Limited mod options allow players to choose specific textures.
   - Players can define their own research milestones for texture changes.
   - Option to synchronize with colony tech-level progression if influenced by other mods.

## Coding Patterns and Conventions

- **C# Conventions**: Utilize PascalCase for class names and methods, and camelCase for local variables. Each class is tailored for single responsibility with clearly defined members.
- **XML File Structure**: Follow RimWorld's XML conventions for `ThingDef` entries, using descriptive IDs and labels for compatibility with translations.

## XML Integration

- **`ThingDef` Definitions**: The XML files `Tech_RoofMotes.xml` define custom roof motifs corresponding to tech levels.
- **Localization and Mod Compatibility**: Ensure identifiers are consistent with the naming scheme used across XML files and linked with the appropriate C# logic.

## Harmony Patching

This mod relies on the **Harmony** library to apply runtime patches, ensuring that changes to roof graphics are seamlessly integrated without altering the original game code directly.

- **Patch Implementation**: 
    - The `ThingMaker_MakeThing.cs` file contains a `Prefix` method, where Harmony applies dynamic behavior before the default game logic.
    - Ensure patches are reversible and do not disrupt normal game functions if the mod is disabled.

## Suggestions for Copilot

- **Code Retrieval**: Use Copilot to assist in retrieving methods related to dynamic graphic changes based on research completion.
- **Algorithm Suggestions**: Leverage Copilot to suggest logic improvements for determining when roof graphics should transition based on tech level.
- **Optimization Patterns**: Utilize Copilot for potential optimizations in how textures are managed and retrieved during gameplay transitions.
- **Localization Assistance**: Leverage Copilot to draft translation templates or identify key phrases for localization efforts.

### Final Note

This mod's functionality can be expanded or customized further based on user feedback. Additional textures or more detailed tech level integration could be explored if there's substantial interest or community contributions. For visual customization enthusiasts, the **Tech-appropriate Roof Mote Retexture** by Nishe is recommended for additional options.

---

Developers working on the mod should ensure that all code contributions align with these guidelines to maintain consistency, performance, and robustness within the mod framework.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

