using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents a player character in the party.
/// Referenced in FSD Section 2.1 - Core Inputs (Party File).
/// </summary>
public class PlayerCharacter
{
    /// <summary>
    /// Character name.
    /// </summary>
    [Required(ErrorMessage = "Character name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Character race (e.g., Human, Elf, Dwarf).
    /// </summary>
    [Required(ErrorMessage = "Race is required")]
    [StringLength(50, ErrorMessage = "Race must not exceed 50 characters")]
    [JsonPropertyName("race")]
    public string Race { get; set; } = string.Empty;

    /// <summary>
    /// Character class (e.g., Fighter, Wizard, Rogue).
    /// </summary>
    [Required(ErrorMessage = "Class is required")]
    [StringLength(50, ErrorMessage = "Class must not exceed 50 characters")]
    [JsonPropertyName("class")]
    public string Class { get; set; } = string.Empty;

    /// <summary>
    /// Character level.
    /// </summary>
    [Range(1, 20, ErrorMessage = "Level must be between 1 and 20")]
    [JsonPropertyName("level")]
    public int Level { get; set; } = 1;

    /// <summary>
    /// Character backstory and history.
    /// </summary>
    [StringLength(5000, ErrorMessage = "Backstory must not exceed 5000 characters")]
    [JsonPropertyName("backstory")]
    public string? Backstory { get; set; }

    /// <summary>
    /// Character motivations and goals.
    /// </summary>
    [JsonPropertyName("motivations")]
    public List<string> Motivations { get; set; } = new();

    /// <summary>
    /// Personality traits, ideals, bonds, and flaws.
    /// </summary>
    [JsonPropertyName("personality")]
    public CharacterPersonality? Personality { get; set; }

    /// <summary>
    /// Relationships with other party members or NPCs.
    /// </summary>
    [JsonPropertyName("relationships")]
    public List<Relationship> Relationships { get; set; } = new();

    /// <summary>
    /// Notable items or equipment.
    /// </summary>
    [JsonPropertyName("notableItems")]
    public List<string> NotableItems { get; set; } = new();

    /// <summary>
    /// Player name (optional, for DM reference).
    /// </summary>
    [StringLength(100, ErrorMessage = "Player name must not exceed 100 characters")]
    [JsonPropertyName("playerName")]
    public string? PlayerName { get; set; }
}

/// <summary>
/// Represents personality traits for a character.
/// </summary>
public class CharacterPersonality
{
    /// <summary>
    /// Character traits.
    /// </summary>
    [JsonPropertyName("traits")]
    public List<string> Traits { get; set; } = new();

    /// <summary>
    /// Character ideals.
    /// </summary>
    [JsonPropertyName("ideals")]
    public List<string> Ideals { get; set; } = new();

    /// <summary>
    /// Character bonds.
    /// </summary>
    [JsonPropertyName("bonds")]
    public List<string> Bonds { get; set; } = new();

    /// <summary>
    /// Character flaws.
    /// </summary>
    [JsonPropertyName("flaws")]
    public List<string> Flaws { get; set; } = new();
}

/// <summary>
/// Represents a relationship between characters or with NPCs.
/// </summary>
public class Relationship
{
    /// <summary>
    /// Name of the related character or NPC.
    /// </summary>
    [Required(ErrorMessage = "Target name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters")]
    [JsonPropertyName("target")]
    public string Target { get; set; } = string.Empty;

    /// <summary>
    /// Type or nature of the relationship (e.g., Friend, Rival, Family).
    /// </summary>
    [Required(ErrorMessage = "Relationship type is required")]
    [StringLength(50, ErrorMessage = "Type must not exceed 50 characters")]
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Description of the relationship.
    /// </summary>
    [StringLength(500, ErrorMessage = "Description must not exceed 500 characters")]
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
