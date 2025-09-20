# Copilot Instruction File for Tech-appropriate Roof Mote Mod

## Mod Overview and Purpose

**Mod Name:** Tech-appropriate Roof Mote

This mod enhances the immersion and visual representation of roofing in RimWorld by changing the default roofing graphics based on the player's technological progress. Instead of the generic steel corrugated roof graphics shown when pawns build roofs, the mod displays a wood-roof graphic initially. Once the colony achieves certain research milestones, such as researching Electricity or Multianalyzer, the graphics update to reflect more advanced materials like metal or plasteel.

## Key Features and Systems

1. **Dynamic Roof Graphics:**
   - Displays a wood-roof graphic by default.
   - Changes to metal roof graphics after the colony researches Electricity.
   - Upgrades to plasteel-like graphics once Multianalyzer is researched.

2. **Player Customization:**
   - Mod options allow players to select which roof texture to use.
   - Players can choose specific research milestones for changing roof graphics.
   - Supports mods that modify colony tech levels dynamically.

## Coding Patterns and Conventions

- **Class Structure:**
  - `TechappropriateRoofMote`: Static utility class for roof graphic updates.
  - `TechappropriateRoofMoteMod`: Inherits from `Mod`, handling initialization and settings.
  - `TechappropriateRoofMoteSettings`: Inherits from `ModSettings`, managing user configurations.

- **Naming Conventions:**
  - Follow PascalCase for class and method names.
  - Use meaningful names that describe the purpose and function clearly.

- **Code Organization:**
  - Keep classes focused on single responsibilities.
  - Maintain separation between graphic handling and mod settings.

## XML Integration

- This mod does not use XML files directly but interacts with RimWorld’s graphics system and research databases.
- Ensure that XML references, like `.xml` files for defining graphics paths, are correctly set in the game's asset manager.

## Harmony Patching

- **Harmony Usage:**
  - Use Harmony to patch methods related to roof construction.
  - Ensure patches do not conflict with other mods by careful method targeting and using `Prefix` or `Postfix` appropriately.
  - Leverage `ThingMaker_MakeThing` static class for creating roof objects with patched graphics logic.

## Suggestions for Copilot

- **Code Completion:**
  - Assist in generating method stubs in `TechappropriateRoofMote` for handling graphic changes.
  - Suggest Harmony patch decorations and layout for method patches.

- **Project Organization:**
  - Provide scaffolding for new settings in `TechappropriateRoofMoteSettings`.
  - Display template for mod option menus to integrate user choice seamlessly.

- **Documentation:**
  - Auto-generate XML documentation comments for public methods to maintain self-explanatory code.

- **Error Handling:**
  - Offer patterns for safe error checking when interacting with game state or third-party mods.

This file should guide developers in using GitHub Copilot to streamline the coding process, integrate with respect to the game’s architecture, and maintain best practices for mod development.
