using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents a non-player character in an adventure.
/// Referenced in FSD Section 3.3 - Adventure Structure.
/// </summary>
public class NPC
{
    /// <summary>
    /// Unique identifier for the NPC.
    /// </summary>
    [JsonPropertyName("npcId")]
    public string NpcId { get; set; } = string.Empty;

    /// <summary>
    /// NPC name.
    /// </summary>
    [Required(ErrorMessage = "NPC name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// NPC role or title (e.g., "Village Elder", "Bandit Leader").
    /// </summary>
    [StringLength(100, ErrorMessage = "Role must not exceed 100 characters")]
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    /// <summary>
    /// NPC race.
    /// </summary>
    [StringLength(50, ErrorMessage = "Race must not exceed 50 characters")]
    [JsonPropertyName("race")]
    public string? Race { get; set; }

    /// <summary>
    /// NPC class or occupation.
    /// </summary>
    [StringLength(50, ErrorMessage = "Class must not exceed 50 characters")]
    [JsonPropertyName("class")]
    public string? Class { get; set; }

    /// <summary>
    /// Physical description and appearance.
    /// </summary>
    [StringLength(1000, ErrorMessage = "Description must not exceed 1000 characters")]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Personality traits and characteristics.
    /// </summary>
    [StringLength(1000, ErrorMessage = "Personality must not exceed 1000 characters")]
    [JsonPropertyName("personality")]
    public string? Personality { get; set; }

    /// <summary>
    /// NPC motivations and goals.
    /// </summary>
    [JsonPropertyName("motivations")]
    public List<string> Motivations { get; set; } = new();

    /// <summary>
    /// NPC backstory and history.
    /// </summary>
    [StringLength(2000, ErrorMessage = "Backstory must not exceed 2000 characters")]
    [JsonPropertyName("backstory")]
    public string? Backstory { get; set; }

    /// <summary>
    /// Relationship to the party (Ally, Neutral, Enemy, etc.).
    /// </summary>
    [StringLength(50, ErrorMessage = "Relationship must not exceed 50 characters")]
    [JsonPropertyName("relationship")]
    public string? Relationship { get; set; }

    /// <summary>
    /// Faction or organization the NPC belongs to.
    /// </summary>
    [StringLength(200, ErrorMessage = "Faction must not exceed 200 characters")]
    [JsonPropertyName("faction")]
    public string? Faction { get; set; }

    /// <summary>
    /// Notable dialogue lines or quotes.
    /// </summary>
    [JsonPropertyName("dialogueHooks")]
    public List<string> DialogueHooks { get; set; } = new();

    /// <summary>
    /// Information the NPC knows or can provide.
    /// </summary>
    [JsonPropertyName("knowledge")]
    public List<string> Knowledge { get; set; } = new();

    /// <summary>
    /// Quest hooks or missions the NPC can provide.
    /// </summary>
    [JsonPropertyName("quests")]
    public List<string> Quests { get; set; } = new();

    /// <summary>
    /// Combat statistics (optional, for stat block generation).
    /// </summary>
    [JsonPropertyName("combatStats")]
    public CombatStats? CombatStats { get; set; }

    /// <summary>
    /// Location where the NPC can typically be found.
    /// </summary>
    [StringLength(200, ErrorMessage = "Location must not exceed 200 characters")]
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>
    /// Additional notes for the DM.
    /// </summary>
    [StringLength(1000, ErrorMessage = "Notes must not exceed 1000 characters")]
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }
}

/// <summary>
/// Represents basic combat statistics for an NPC.
/// </summary>
public class CombatStats
{
    /// <summary>
    /// Armor Class.
    /// </summary>
    [Range(1, 30, ErrorMessage = "AC must be between 1 and 30")]
    [JsonPropertyName("armorClass")]
    public int? ArmorClass { get; set; }

    /// <summary>
    /// Hit Points.
    /// </summary>
    [Range(1, 1000, ErrorMessage = "HP must be between 1 and 1000")]
    [JsonPropertyName("hitPoints")]
    public int? HitPoints { get; set; }

    /// <summary>
    /// Movement speed in feet.
    /// </summary>
    [Range(0, 200, ErrorMessage = "Speed must be between 0 and 200")]
    [JsonPropertyName("speed")]
    public int? Speed { get; set; }

    /// <summary>
    /// Challenge Rating.
    /// </summary>
    [StringLength(10, ErrorMessage = "CR must not exceed 10 characters")]
    [JsonPropertyName("challengeRating")]
    public string? ChallengeRating { get; set; }

    /// <summary>
    /// Special abilities or actions.
    /// </summary>
    [JsonPropertyName("abilities")]
    public List<string> Abilities { get; set; } = new();
}
