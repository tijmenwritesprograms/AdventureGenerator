using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents a complete D&D adventure document.
/// Referenced in FSD Section 2.2 - Core Outputs and Section 3.3 - Adventure Structure.
/// </summary>
public class Adventure
{
    /// <summary>
    /// Unique identifier for the adventure.
    /// </summary>
    [JsonPropertyName("adventureId")]
    public string AdventureId { get; set; } = string.Empty;

    /// <summary>
    /// Adventure title.
    /// </summary>
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 characters")]
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Brief summary or tagline for the adventure.
    /// </summary>
    [StringLength(500, ErrorMessage = "Summary must not exceed 500 characters")]
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    /// <summary>
    /// Recommended level range for the adventure.
    /// </summary>
    [JsonPropertyName("levelRange")]
    public LevelRange? LevelRange { get; set; }

    /// <summary>
    /// The adventure hook - how the party gets involved.
    /// </summary>
    [Required(ErrorMessage = "Adventure hook is required")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Hook must be between 10 and 2000 characters")]
    [JsonPropertyName("hook")]
    public string Hook { get; set; } = string.Empty;

    /// <summary>
    /// Background information and lore relevant to the adventure.
    /// </summary>
    [StringLength(5000, ErrorMessage = "Background must not exceed 5000 characters")]
    [JsonPropertyName("background")]
    public string? Background { get; set; }

    /// <summary>
    /// The acts or chapters that make up the adventure.
    /// </summary>
    [Required(ErrorMessage = "Adventure must have at least one act")]
    [MinLength(1, ErrorMessage = "Adventure must have at least one act")]
    [JsonPropertyName("acts")]
    public List<Act> Acts { get; set; } = new();

    /// <summary>
    /// Key NPCs in the adventure.
    /// </summary>
    [JsonPropertyName("npcs")]
    public List<NPC> NPCs { get; set; } = new();

    /// <summary>
    /// Notable locations in the adventure.
    /// </summary>
    [JsonPropertyName("locations")]
    public List<Location> Locations { get; set; } = new();

    /// <summary>
    /// Encounters (combat, exploration, social) in the adventure.
    /// </summary>
    [JsonPropertyName("encounters")]
    public List<Encounter> Encounters { get; set; } = new();

    /// <summary>
    /// Resolution and aftermath of the adventure.
    /// </summary>
    [StringLength(3000, ErrorMessage = "Resolution must not exceed 3000 characters")]
    [JsonPropertyName("resolution")]
    public string? Resolution { get; set; }

    /// <summary>
    /// Potential consequences and follow-up hooks.
    /// </summary>
    [JsonPropertyName("consequences")]
    public List<string> Consequences { get; set; } = new();

    /// <summary>
    /// Rewards the party can earn (items, gold, information, etc.).
    /// </summary>
    [JsonPropertyName("rewards")]
    public List<string> Rewards { get; set; } = new();

    /// <summary>
    /// Campaign ID this adventure belongs to.
    /// </summary>
    [JsonPropertyName("campaignId")]
    public string? CampaignId { get; set; }

    /// <summary>
    /// Metadata about the adventure (themes, tags, etc.).
    /// </summary>
    [JsonPropertyName("metadata")]
    public AdventureMetadata? Metadata { get; set; }

    /// <summary>
    /// Date the adventure was created.
    /// </summary>
    [JsonPropertyName("createdDate")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Date the adventure was last modified.
    /// </summary>
    [JsonPropertyName("lastModified")]
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Version of the adventure for tracking revisions.
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; } = "1.0";
}
