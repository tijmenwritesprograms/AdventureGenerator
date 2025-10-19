using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents the campaign context including setting, factions, tone, and major story arcs.
/// Referenced in FSD Section 2.1 - Core Inputs.
/// </summary>
public class CampaignContext
{
    /// <summary>
    /// Unique identifier for the campaign.
    /// </summary>
    [JsonPropertyName("campaignId")]
    public string CampaignId { get; set; } = string.Empty;

    /// <summary>
    /// Name of the campaign.
    /// </summary>
    [Required(ErrorMessage = "Campaign name is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Campaign name must be between 1 and 200 characters")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Campaign setting/world description.
    /// </summary>
    [Required(ErrorMessage = "Setting description is required")]
    [StringLength(5000, MinimumLength = 10, ErrorMessage = "Setting must be between 10 and 5000 characters")]
    [JsonPropertyName("setting")]
    public string Setting { get; set; } = string.Empty;

    /// <summary>
    /// Overall tone and themes of the campaign (e.g., "Dark Fantasy", "High Magic", "Intrigue-Heavy").
    /// </summary>
    [Required(ErrorMessage = "Tone is required")]
    [StringLength(500, ErrorMessage = "Tone must not exceed 500 characters")]
    [JsonPropertyName("tone")]
    public string Tone { get; set; } = string.Empty;

    /// <summary>
    /// List of major factions in the campaign world.
    /// </summary>
    [JsonPropertyName("factions")]
    public List<Faction> Factions { get; set; } = new();

    /// <summary>
    /// Major story arcs or ongoing plot threads.
    /// </summary>
    [JsonPropertyName("majorArcs")]
    public List<string> MajorArcs { get; set; } = new();

    /// <summary>
    /// Key locations in the campaign world.
    /// </summary>
    [JsonPropertyName("keyLocations")]
    public List<string> KeyLocations { get; set; } = new();

    /// <summary>
    /// Important historical events or lore.
    /// </summary>
    [JsonPropertyName("lore")]
    public string? Lore { get; set; }

    /// <summary>
    /// Campaign-specific rules, house rules, or restrictions.
    /// </summary>
    [JsonPropertyName("campaignRules")]
    public List<string> CampaignRules { get; set; } = new();

    /// <summary>
    /// Additional metadata (version, creation date, etc.).
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();
}

/// <summary>
/// Represents a faction in the campaign world.
/// </summary>
public class Faction
{
    /// <summary>
    /// Name of the faction.
    /// </summary>
    [Required(ErrorMessage = "Faction name is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Faction name must be between 1 and 200 characters")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the faction's goals and characteristics.
    /// </summary>
    [Required(ErrorMessage = "Faction description is required")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 2000 characters")]
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Faction's relationship status (Allied, Neutral, Hostile, etc.).
    /// </summary>
    [JsonPropertyName("relationship")]
    public string? Relationship { get; set; }

    /// <summary>
    /// Notable members or leaders of the faction.
    /// </summary>
    [JsonPropertyName("notableMembers")]
    public List<string> NotableMembers { get; set; } = new();
}
