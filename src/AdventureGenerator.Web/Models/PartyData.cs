using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents the party composition and data.
/// Referenced in FSD Section 2.1 - Core Inputs (Party File).
/// </summary>
public class PartyData
{
    /// <summary>
    /// Name or identifier for the party.
    /// </summary>
    [StringLength(200, ErrorMessage = "Party name must not exceed 200 characters")]
    [JsonPropertyName("partyName")]
    public string? PartyName { get; set; }

    /// <summary>
    /// List of player characters in the party.
    /// </summary>
    [Required(ErrorMessage = "Party must have at least one character")]
    [MinLength(1, ErrorMessage = "Party must have at least one character")]
    [JsonPropertyName("characters")]
    public List<PlayerCharacter> Characters { get; set; } = new();

    /// <summary>
    /// Average party level (calculated or explicit).
    /// </summary>
    [Range(1, 20, ErrorMessage = "Average level must be between 1 and 20")]
    [JsonPropertyName("averageLevel")]
    public int AverageLevel { get; set; } = 1;

    /// <summary>
    /// Party dynamics, shared history, or group characteristics.
    /// </summary>
    [StringLength(2000, ErrorMessage = "Party background must not exceed 2000 characters")]
    [JsonPropertyName("partyBackground")]
    public string? PartyBackground { get; set; }

    /// <summary>
    /// Shared party goals or quests.
    /// </summary>
    [JsonPropertyName("sharedGoals")]
    public List<string> SharedGoals { get; set; } = new();

    /// <summary>
    /// Notable party achievements or milestones.
    /// </summary>
    [JsonPropertyName("achievements")]
    public List<string> Achievements { get; set; } = new();

    /// <summary>
    /// Additional metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();
}
