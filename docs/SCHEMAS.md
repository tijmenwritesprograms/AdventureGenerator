# Data Schemas Documentation

This document provides comprehensive documentation for all data schemas used in the Adventure Generator.

## Table of Contents

1. [Overview](#overview)
2. [Input Schemas](#input-schemas)
3. [Output Schemas](#output-schemas)
4. [Validation Rules](#validation-rules)
5. [Extensibility](#extensibility)

---

## Overview

All data schemas are defined as C# model classes with:
- Data annotations for validation
- JSON serialization support via System.Text.Json
- XML documentation comments
- Support for both JSON and YAML formats

**Location:** `/src/AdventureGenerator.Web/Models/`  
**Examples:** `/examples/`

---

## Input Schemas

### Campaign Context (`CampaignContext.cs`)

Represents campaign world, setting, factions, and story arcs.

**Required Fields:** `name`, `setting`, `tone`

**Key Properties:**
- `factions` - List of campaign factions with relationships
- `majorArcs` - Ongoing story arcs
- `keyLocations` - Important campaign locations
- `campaignRules` - House rules and restrictions

**Example:** See `examples/campaign-context.json`

### Party Data (`PartyData.cs`)

Party composition with player character details.

**Required Fields:** `characters` (min 1)

**Key Properties:**
- `characters` - Array of PlayerCharacter objects
- `averageLevel` - Party average level (1-20)
- `partyBackground` - Shared history
- `sharedGoals` - Party objectives

**Example:** See `examples/party-data.json`

### Player Character (`PlayerCharacter.cs`)

Individual character data.

**Required Fields:** `name`, `race`, `class`

**Key Properties:**
- `level` - Character level (1-20)
- `backstory` - Character history
- `motivations` - Goals and drives
- `personality` - Traits, ideals, bonds, flaws
- `relationships` - Connections to others

### System Prompt (`SystemPrompt.cs`)

LLM prompt template with placeholders.

**Required Fields:** `name`, `template`

**Key Properties:**
- `template` - Prompt text with {placeholders}
- `outputFormat` - Expected format (default: "Markdown")
- `toneGuidelines` - Tone expectations
- `availablePlaceholders` - Supported placeholders

**Example:** See `examples/system-prompt.json`

### Story Progress (`StoryProgress.cs`)

Campaign progress and session history.

**Required Fields:** `campaignId`, `summary`

**Key Properties:**
- `previousSessions` - Session summaries
- `activePlotThreads` - Ongoing storylines
- `knownNPCs` - Encountered NPCs
- `visitedLocations` - Visited places

**Example:** See `examples/story-progress.json`

### Premise (`Premise.cs`)

High-level adventure idea.

**Required Fields:** `hook`

**Key Properties:**
- `hook` - Adventure starting point
- `conflict` - Main challenge
- `suggestedLevelRange` - Level recommendation
- `themes` - Adventure themes

**Example:** See `examples/premise.json`

---

## Output Schemas

### Adventure (`Adventure.cs`)

Complete adventure document.

**Required Fields:** `title`, `hook`, `acts` (min 1)

**Key Properties:**
- `acts` - Adventure structure (3-5 typical)
- `npcs` - Key NPCs
- `locations` - Notable locations
- `encounters` - Various encounters
- `metadata` - AdventureMetadata object

**Example:** See `examples/adventure.json`

### Act (`Act.cs`)

Single act/chapter in adventure.

**Required Fields:** `title`, `description`

**Key Properties:**
- `scenes` - Scenes within act
- `objective` - Act goal
- `challenges` - Obstacles
- `outcomes` - Possible endings
- `dmNotes` - DM running tips

### NPC (`NPC.cs`)

Non-player character.

**Required Fields:** `name`

**Key Properties:**
- `role` - NPC title/function
- `personality` - Character traits
- `motivations` - Goals
- `dialogueHooks` - Sample dialogue
- `combatStats` - Optional combat data

### Encounter (`Encounter.cs`)

Single encounter.

**Required Fields:** `name`, `type`, `description`

**Encounter Types:** Combat, Social, Exploration, Puzzle, Trap, Chase, Negotiation, Investigation, Stealth, Mixed

**Key Properties:**
- `enemies` - Combat enemies (if applicable)
- `objectives` - Encounter goals
- `outcomes` - Possible results
- `dmTips` - Running advice

### Location (`Location.cs`)

A location in the adventure.

**Required Fields:** `name`, `description`

**Key Properties:**
- `atmosphere` - Sensory details
- `features` - Key features
- `inhabitants` - NPCs present
- `secrets` - Hidden elements
- `hazards` - Dangers

### Adventure Metadata (`AdventureMetadata.cs`)

Adventure metadata and statistics.

**Key Properties:**
- `themes` - Adventure themes
- `tags` - Categorization tags
- `levelRange` - Recommended levels
- `estimatedPlayTime` - Hours estimate
- `difficulty` - Challenge rating
- `generationInfo` - How it was created
- `customFields` - Extensibility

---

## Validation Rules

### Data Annotations

Models use standard .NET validation attributes:

```csharp
[Required(ErrorMessage = "Name is required")]
[StringLength(200, MinimumLength = 1)]
public string Name { get; set; }

[Range(1, 20, ErrorMessage = "Level must be between 1 and 20")]
public int Level { get; set; }
```

### Validation Example

```csharp
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

// Deserialize
var json = File.ReadAllText("campaign-context.json");
var context = JsonSerializer.Deserialize<CampaignContext>(json);

// Validate
var results = new List<ValidationResult>();
var isValid = Validator.TryValidateObject(
    context,
    new ValidationContext(context),
    results,
    validateAllProperties: true
);

foreach (var error in results)
{
    Console.WriteLine(error.ErrorMessage);
}
```

### Common Constraints

- String lengths: 1-10,000 characters (varies by field)
- Numeric ranges: Level (1-20), CR (1-30), etc.
- Collection minimums: Acts (min 1), Characters (min 1)
- Required fields: Marked with `[Required]` attribute

---

## Extensibility

### Metadata Dictionaries

Most schemas include extensibility through dictionaries:

```json
{
  "name": "My Campaign",
  "metadata": {
    "customField": "customValue",
    "anotherField": "anotherValue"
  }
}
```

Available in:
- `CampaignContext.Metadata`
- `PartyData.Metadata`
- `SystemPrompt.Metadata`
- `StoryProgress.Metadata`
- `AdventureMetadata.CustomFields`

### Adding New Properties

When extending schemas:

1. Make new properties optional (nullable or with defaults)
2. Add data annotations for validation
3. Document with XML comments
4. Update examples
5. Maintain backward compatibility

### Version Tracking

Use version fields to track schema changes:

```json
{
  "version": "1.0",
  "metadata": {
    "schemaVersion": "1.0",
    "lastModified": "2025-10-19"
  }
}
```

---

## Serialization

### JSON (Default)

```csharp
using System.Text.Json;

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    WriteIndented = true
};

// Serialize
var json = JsonSerializer.Serialize(campaign, options);

// Deserialize
var campaign = JsonSerializer.Deserialize<CampaignContext>(json, options);
```

### YAML (Optional)

Add YamlDotNet package and configure:

```csharp
using YamlDotNet.Serialization;

var serializer = new SerializerBuilder().Build();
var yaml = serializer.Serialize(campaign);

var deserializer = new DeserializerBuilder().Build();
var campaign = deserializer.Deserialize<CampaignContext>(yaml);
```

---

## Best Practices

1. **Always validate** - Check data before processing
2. **Use meaningful IDs** - For cross-references
3. **Provide defaults** - For optional fields
4. **Document constraints** - In XML comments
5. **Test both ways** - Serialize and deserialize
6. **Handle nulls** - Use nullable types appropriately
7. **Version schemas** - Track changes over time
8. **Include examples** - For all schemas
9. **Support extensibility** - Via metadata dictionaries
10. **Maintain compatibility** - When updating schemas

---

## Quick Reference

### Input Files
- `campaign-context.json` - Campaign world
- `party-data.json` - Player characters
- `system-prompt.json` - LLM template
- `story-progress.json` - Session history
- `premise.json` - Adventure idea

### Output Files
- `adventure.json` - Complete adventure

### Key Models
- `CampaignContext` - Campaign data
- `PartyData` + `PlayerCharacter` - Party info
- `SystemPrompt` - Prompt template
- `StoryProgress` - Progress tracking
- `Premise` - Adventure premise
- `Adventure` + `Act` + `Scene` - Adventure structure
- `NPC` - Character data
- `Encounter` - Encounter data
- `Location` - Location data
- `AdventureMetadata` - Metadata

---

## Related Documentation

- **Model Classes:** `/src/AdventureGenerator.Web/Models/`
- **Examples:** `/examples/`
- **FSD:** `/specs/fsd.md`
- **README:** `/README.md`
