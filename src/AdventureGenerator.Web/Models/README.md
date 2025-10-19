# Models

This directory contains data models and domain objects for the Adventure Generator.

## Planned Models

### Input Models
- **SystemPrompt**: Template for LLM instructions
- **CampaignContext**: Campaign setting, factions, tone, arcs
- **StoryProgress**: Summary of previous sessions
- **Premise**: High-level adventure idea
- **PartyData**: PC information including backstories
- **ExistingAdventure**: Previous adventure data for extensions

### Output Models
- **Adventure**: Complete adventure document
- **Act**: Individual act/chapter in an adventure
- **NPC**: Non-player character with motivations
- **Encounter**: Combat, exploration, or roleplay encounter
- **Location**: Place description with events
- **Metadata**: Generated content metadata (themes, level, tags)

## Best Practices

- Use records for immutable data
- Implement proper validation
- Add data annotations where appropriate
- Keep models focused and single-purpose
