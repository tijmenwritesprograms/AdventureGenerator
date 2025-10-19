using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents the story progress and session summary.
/// Referenced in FSD Section 2.1 - Core Inputs (Story So Far).
/// </summary>
public class StoryProgress
{
    /// <summary>
    /// Campaign identifier this story belongs to.
    /// </summary>
    [Required(ErrorMessage = "Campaign ID is required")]
    [JsonPropertyName("campaignId")]
    public string CampaignId { get; set; } = string.Empty;

    /// <summary>
    /// Current session or chapter number.
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Session number must be positive")]
    [JsonPropertyName("sessionNumber")]
    public int SessionNumber { get; set; } = 1;

    /// <summary>
    /// Summary of the story so far.
    /// </summary>
    [Required(ErrorMessage = "Summary is required")]
    [StringLength(10000, MinimumLength = 10, ErrorMessage = "Summary must be between 10 and 10000 characters")]
    [JsonPropertyName("summary")]
    public string Summary { get; set; } = string.Empty;

    /// <summary>
    /// List of previous session summaries for continuity.
    /// </summary>
    [JsonPropertyName("previousSessions")]
    public List<SessionSummary> PreviousSessions { get; set; } = new();

    /// <summary>
    /// Active plot threads or unresolved storylines.
    /// </summary>
    [JsonPropertyName("activePlotThreads")]
    public List<PlotThread> ActivePlotThreads { get; set; } = new();

    /// <summary>
    /// Important NPCs the party has encountered.
    /// </summary>
    [JsonPropertyName("knownNPCs")]
    public List<string> KnownNPCs { get; set; } = new();

    /// <summary>
    /// Locations the party has visited.
    /// </summary>
    [JsonPropertyName("visitedLocations")]
    public List<string> VisitedLocations { get; set; } = new();

    /// <summary>
    /// Key events or decisions that have occurred.
    /// </summary>
    [JsonPropertyName("keyEvents")]
    public List<string> KeyEvents { get; set; } = new();

    /// <summary>
    /// Current party status (resources, morale, etc.).
    /// </summary>
    [JsonPropertyName("partyStatus")]
    public string? PartyStatus { get; set; }

    /// <summary>
    /// Date this progress was last updated.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Additional metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();
}

/// <summary>
/// Represents a summary of a single session.
/// </summary>
public class SessionSummary
{
    /// <summary>
    /// Session number.
    /// </summary>
    [Range(1, int.MaxValue, ErrorMessage = "Session number must be positive")]
    [JsonPropertyName("sessionNumber")]
    public int SessionNumber { get; set; }

    /// <summary>
    /// Session title or name.
    /// </summary>
    [StringLength(200, ErrorMessage = "Title must not exceed 200 characters")]
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Summary of what happened in this session.
    /// </summary>
    [Required(ErrorMessage = "Summary is required")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Summary must be between 10 and 2000 characters")]
    [JsonPropertyName("summary")]
    public string Summary { get; set; } = string.Empty;

    /// <summary>
    /// Date the session occurred.
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }
}

/// <summary>
/// Represents an ongoing plot thread or storyline.
/// </summary>
public class PlotThread
{
    /// <summary>
    /// Name or identifier of the plot thread.
    /// </summary>
    [Required(ErrorMessage = "Plot thread name is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 200 characters")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the plot thread.
    /// </summary>
    [Required(ErrorMessage = "Description is required")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 1000 characters")]
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Status of the plot thread (Active, Paused, Resolved).
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = "Active";

    /// <summary>
    /// Priority or importance level.
    /// </summary>
    [Range(1, 5, ErrorMessage = "Priority must be between 1 and 5")]
    [JsonPropertyName("priority")]
    public int Priority { get; set; } = 3;
}
