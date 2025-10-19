using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents metadata about a generated adventure.
/// Referenced in FSD Section 2.2 - Core Outputs (Metadata File).
/// </summary>
public class AdventureMetadata
{
    /// <summary>
    /// Themes present in the adventure.
    /// </summary>
    [JsonPropertyName("themes")]
    public List<string> Themes { get; set; } = new();

    /// <summary>
    /// Tone of the adventure (e.g., Dark, Humorous, Epic, Gritty).
    /// </summary>
    [StringLength(100, ErrorMessage = "Tone must not exceed 100 characters")]
    [JsonPropertyName("tone")]
    public string? Tone { get; set; }

    /// <summary>
    /// Tags for categorizing the adventure.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = new();

    /// <summary>
    /// Recommended level range.
    /// </summary>
    [JsonPropertyName("levelRange")]
    public LevelRange? LevelRange { get; set; }

    /// <summary>
    /// Estimated play time in hours.
    /// </summary>
    [Range(0.5, 100, ErrorMessage = "Play time must be between 0.5 and 100 hours")]
    [JsonPropertyName("estimatedPlayTime")]
    public double? EstimatedPlayTime { get; set; }

    /// <summary>
    /// Difficulty rating (Easy, Medium, Hard, Deadly).
    /// </summary>
    [JsonPropertyName("difficulty")]
    public string? Difficulty { get; set; }

    /// <summary>
    /// Primary adventure type (Combat-heavy, Roleplay-focused, Exploration, Mystery, etc.).
    /// </summary>
    [JsonPropertyName("adventureType")]
    public string? AdventureType { get; set; }

    /// <summary>
    /// Setting type (Urban, Wilderness, Dungeon, Planar, etc.).
    /// </summary>
    [JsonPropertyName("setting")]
    public string? Setting { get; set; }

    /// <summary>
    /// Number of acts/chapters.
    /// </summary>
    [Range(1, 20, ErrorMessage = "Act count must be between 1 and 20")]
    [JsonPropertyName("actCount")]
    public int ActCount { get; set; }

    /// <summary>
    /// Number of NPCs.
    /// </summary>
    [Range(0, 1000, ErrorMessage = "NPC count must be between 0 and 1000")]
    [JsonPropertyName("npcCount")]
    public int NpcCount { get; set; }

    /// <summary>
    /// Number of encounters.
    /// </summary>
    [Range(0, 1000, ErrorMessage = "Encounter count must be between 0 and 1000")]
    [JsonPropertyName("encounterCount")]
    public int EncounterCount { get; set; }

    /// <summary>
    /// Number of locations.
    /// </summary>
    [Range(0, 1000, ErrorMessage = "Location count must be between 0 and 1000")]
    [JsonPropertyName("locationCount")]
    public int LocationCount { get; set; }

    /// <summary>
    /// Content warnings or sensitive topics.
    /// </summary>
    [JsonPropertyName("contentWarnings")]
    public List<string> ContentWarnings { get; set; } = new();

    /// <summary>
    /// Prerequisites or required knowledge.
    /// </summary>
    [JsonPropertyName("prerequisites")]
    public List<string> Prerequisites { get; set; } = new();

    /// <summary>
    /// Generation parameters used.
    /// </summary>
    [JsonPropertyName("generationInfo")]
    public GenerationInfo? GenerationInfo { get; set; }

    /// <summary>
    /// Custom metadata fields for extensibility.
    /// </summary>
    [JsonPropertyName("customFields")]
    public Dictionary<string, string> CustomFields { get; set; } = new();
}

/// <summary>
/// Information about how the adventure was generated.
/// </summary>
public class GenerationInfo
{
    /// <summary>
    /// System prompt ID or name used.
    /// </summary>
    [StringLength(200, ErrorMessage = "Prompt ID must not exceed 200 characters")]
    [JsonPropertyName("promptId")]
    public string? PromptId { get; set; }

    /// <summary>
    /// Model or generator version used.
    /// </summary>
    [StringLength(100, ErrorMessage = "Generator version must not exceed 100 characters")]
    [JsonPropertyName("generatorVersion")]
    public string? GeneratorVersion { get; set; }

    /// <summary>
    /// Date and time of generation.
    /// </summary>
    [JsonPropertyName("generatedAt")]
    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Generation seed (for reproducibility).
    /// </summary>
    [JsonPropertyName("seed")]
    public string? Seed { get; set; }

    /// <summary>
    /// Parameters used during generation.
    /// </summary>
    [JsonPropertyName("parameters")]
    public Dictionary<string, string> Parameters { get; set; } = new();
}
