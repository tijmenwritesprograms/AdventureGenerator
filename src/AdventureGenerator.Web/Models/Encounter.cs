using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents an encounter in an adventure.
/// Referenced in FSD Section 3.3 - Adventure Structure.
/// </summary>
public class Encounter
{
    /// <summary>
    /// Unique identifier for the encounter.
    /// </summary>
    [JsonPropertyName("encounterId")]
    public string EncounterId { get; set; } = string.Empty;

    /// <summary>
    /// Encounter name or title.
    /// </summary>
    [Required(ErrorMessage = "Encounter name is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 200 characters")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Type of encounter (Combat, Social, Exploration, Puzzle, etc.).
    /// </summary>
    [Required(ErrorMessage = "Encounter type is required")]
    [JsonPropertyName("type")]
    public EncounterType Type { get; set; } = EncounterType.Combat;

    /// <summary>
    /// Detailed description of the encounter.
    /// </summary>
    [Required(ErrorMessage = "Description is required")]
    [StringLength(3000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 3000 characters")]
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Location where the encounter takes place.
    /// </summary>
    [StringLength(200, ErrorMessage = "Location must not exceed 200 characters")]
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>
    /// Difficulty level or challenge rating.
    /// </summary>
    [JsonPropertyName("difficulty")]
    public string? Difficulty { get; set; }

    /// <summary>
    /// Enemies or creatures involved (for combat encounters).
    /// </summary>
    [JsonPropertyName("enemies")]
    public List<Enemy> Enemies { get; set; } = new();

    /// <summary>
    /// NPCs involved in the encounter.
    /// </summary>
    [JsonPropertyName("npcs")]
    public List<string> NPCs { get; set; } = new();

    /// <summary>
    /// Environmental features or hazards.
    /// </summary>
    [JsonPropertyName("environment")]
    public List<string> Environment { get; set; } = new();

    /// <summary>
    /// Objectives or goals for the encounter.
    /// </summary>
    [JsonPropertyName("objectives")]
    public List<string> Objectives { get; set; } = new();

    /// <summary>
    /// Possible outcomes of the encounter.
    /// </summary>
    [JsonPropertyName("outcomes")]
    public List<string> Outcomes { get; set; } = new();

    /// <summary>
    /// Rewards for succeeding in the encounter.
    /// </summary>
    [JsonPropertyName("rewards")]
    public List<string> Rewards { get; set; } = new();

    /// <summary>
    /// Consequences for failure.
    /// </summary>
    [JsonPropertyName("consequences")]
    public List<string> Consequences { get; set; } = new();

    /// <summary>
    /// DM tips for running the encounter.
    /// </summary>
    [StringLength(2000, ErrorMessage = "DM tips must not exceed 2000 characters")]
    [JsonPropertyName("dmTips")]
    public string? DmTips { get; set; }

    /// <summary>
    /// Triggers or conditions that start the encounter.
    /// </summary>
    [StringLength(500, ErrorMessage = "Trigger must not exceed 500 characters")]
    [JsonPropertyName("trigger")]
    public string? Trigger { get; set; }
}

/// <summary>
/// Types of encounters.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EncounterType
{
    Combat,
    Social,
    Exploration,
    Puzzle,
    Trap,
    Chase,
    Negotiation,
    Investigation,
    Stealth,
    Mixed
}

/// <summary>
/// Represents an enemy in a combat encounter.
/// </summary>
public class Enemy
{
    /// <summary>
    /// Creature name or type.
    /// </summary>
    [Required(ErrorMessage = "Enemy name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Number of this enemy type.
    /// </summary>
    [Range(1, 100, ErrorMessage = "Count must be between 1 and 100")]
    [JsonPropertyName("count")]
    public int Count { get; set; } = 1;

    /// <summary>
    /// Challenge Rating.
    /// </summary>
    [StringLength(10, ErrorMessage = "CR must not exceed 10 characters")]
    [JsonPropertyName("challengeRating")]
    public string? ChallengeRating { get; set; }

    /// <summary>
    /// Brief description or tactics.
    /// </summary>
    [StringLength(500, ErrorMessage = "Description must not exceed 500 characters")]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Reference to stat block (book name and page, or stat block ID).
    /// </summary>
    [StringLength(200, ErrorMessage = "Stat block reference must not exceed 200 characters")]
    [JsonPropertyName("statBlockReference")]
    public string? StatBlockReference { get; set; }
}
