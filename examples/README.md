# Example Data Files

This directory contains example JSON files demonstrating the data schemas used by the Adventure Generator.

## Files

### Input Schemas

#### `campaign-context.json`
Example campaign context file for a Waterdeep-based campaign. Demonstrates:
- Campaign setting and tone
- Faction relationships
- Major story arcs
- Key locations and lore
- Campaign rules and metadata

#### `party-data.json`
Example party composition with four characters. Demonstrates:
- Complete character profiles
- Backstories and motivations
- Personality traits
- Inter-party relationships
- Party dynamics and shared goals

#### `system-prompt.json`
Example system prompt template for adventure generation. Demonstrates:
- Prompt structure with placeholders
- Tone and quality guidelines
- Output format specifications
- Available context variables

#### `story-progress.json`
Example story progress tracking a multi-session campaign arc. Demonstrates:
- Session summaries
- Active plot threads
- Known NPCs and locations
- Party status and recent events

#### `premise.json`
Example adventure premise. Demonstrates:
- Adventure hook and conflict
- Location and themes
- Level range recommendations
- Expected outcomes

### Output Schemas

#### `adventure.json`
Complete example adventure "Echoes from the Deep". Demonstrates:
- Full adventure structure with acts and scenes
- Detailed NPCs with combat stats
- Various encounter types
- Location descriptions
- Comprehensive metadata

## Usage

These files can be used as:
1. **Templates** - Copy and modify for your own campaigns
2. **Reference** - See what a complete data structure looks like
3. **Testing** - Validate serialization/deserialization
4. **Documentation** - Understand required and optional fields

## JSON Schema Validation

All example files conform to the C# model classes defined in `/src/AdventureGenerator.Web/Models/`. You can validate them programmatically using System.Text.Json and data annotations.

### Example Validation Code

```csharp
using System.Text.Json;
using AdventureGenerator.Web.Models;

// Deserialize and validate
var json = File.ReadAllText("campaign-context.json");
var options = new JsonSerializerOptions 
{ 
    PropertyNameCaseInsensitive = true 
};
var context = JsonSerializer.Deserialize<CampaignContext>(json, options);

// Validate using data annotations
var validationResults = new List<ValidationResult>();
var isValid = Validator.TryValidateObject(
    context, 
    new ValidationContext(context), 
    validationResults, 
    validateAllProperties: true
);
```

## YAML Support

While these examples are in JSON format, the models support both JSON and YAML serialization. To use YAML:

1. Add YamlDotNet package to your project
2. Use the same model classes
3. Configure YamlDotNet to respect the `JsonPropertyName` attributes

Example:
```csharp
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(CamelCaseNamingConvention.Instance)
    .Build();

var yaml = File.ReadAllText("campaign-context.yaml");
var context = deserializer.Deserialize<CampaignContext>(yaml);
```

## Extending the Schemas

All models include `metadata` dictionaries for custom fields:
- `CampaignContext.Metadata`
- `PartyData.Metadata`
- `SystemPrompt.Metadata`
- `StoryProgress.Metadata`
- `AdventureMetadata.CustomFields`

This allows extending schemas without breaking backward compatibility.

## Related Documentation

- Model definitions: `/src/AdventureGenerator.Web/Models/`
- Functional specification: `/specs/fsd.md`
- Project README: `/README.md`
