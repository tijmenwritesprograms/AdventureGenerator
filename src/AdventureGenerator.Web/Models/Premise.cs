using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents a high-level adventure premise or hook.
/// Referenced in FSD Section 2.1 - Core Inputs (Premise).
/// </summary>
public class Premise
{
    /// <summary>
    /// Title or name of the adventure premise.
    /// </summary>
    [StringLength(200, ErrorMessage = "Title must not exceed 200 characters")]
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// The main adventure hook or starting idea.
    /// </summary>
    [Required(ErrorMessage = "Hook is required")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Hook must be between 10 and 1000 characters")]
    [JsonPropertyName("hook")]
    public string Hook { get; set; } = string.Empty;

    /// <summary>
    /// Main conflict or challenge the adventure centers around.
    /// </summary>
    [StringLength(1000, ErrorMessage = "Conflict must not exceed 1000 characters")]
    [JsonPropertyName("conflict")]
    public string? Conflict { get; set; }

    /// <summary>
    /// Primary location or region where the adventure takes place.
    /// </summary>
    [StringLength(200, ErrorMessage = "Location must not exceed 200 characters")]
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>
    /// Suggested level range for the adventure.
    /// </summary>
    [JsonPropertyName("suggestedLevelRange")]
    public LevelRange? SuggestedLevelRange { get; set; }

    /// <summary>
    /// Themes or tones for this adventure (e.g., Mystery, Combat-heavy, Political intrigue).
    /// </summary>
    [JsonPropertyName("themes")]
    public List<string> Themes { get; set; } = new();

    /// <summary>
    /// Key NPCs that should appear in the adventure.
    /// </summary>
    [JsonPropertyName("keyNPCs")]
    public List<string> KeyNPCs { get; set; } = new();

    /// <summary>
    /// Expected outcomes or possible endings.
    /// </summary>
    [JsonPropertyName("expectedOutcomes")]
    public List<string> ExpectedOutcomes { get; set; } = new();

    /// <summary>
    /// Additional notes or constraints.
    /// </summary>
    [StringLength(2000, ErrorMessage = "Notes must not exceed 2000 characters")]
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }
}

/// <summary>
/// Represents a level range for an adventure.
/// </summary>
public class LevelRange
{
    /// <summary>
    /// Minimum recommended level.
    /// </summary>
    [Range(1, 20, ErrorMessage = "Minimum level must be between 1 and 20")]
    [JsonPropertyName("min")]
    public int Min { get; set; } = 1;

    /// <summary>
    /// Maximum recommended level.
    /// </summary>
    [Range(1, 20, ErrorMessage = "Maximum level must be between 1 and 20")]
    [JsonPropertyName("max")]
    public int Max { get; set; } = 5;
}
