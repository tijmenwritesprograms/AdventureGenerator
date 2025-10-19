using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents a location in an adventure.
/// Referenced in FSD Section 3.3 - Adventure Structure.
/// </summary>
public class Location
{
    /// <summary>
    /// Unique identifier for the location.
    /// </summary>
    [JsonPropertyName("locationId")]
    public string LocationId { get; set; } = string.Empty;

    /// <summary>
    /// Location name.
    /// </summary>
    [Required(ErrorMessage = "Location name is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 200 characters")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Type of location (City, Dungeon, Wilderness, Building, etc.).
    /// </summary>
    [StringLength(50, ErrorMessage = "Type must not exceed 50 characters")]
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Detailed description of the location.
    /// </summary>
    [Required(ErrorMessage = "Description is required")]
    [StringLength(3000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 3000 characters")]
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Atmospheric details (sights, sounds, smells).
    /// </summary>
    [StringLength(1000, ErrorMessage = "Atmosphere must not exceed 1000 characters")]
    [JsonPropertyName("atmosphere")]
    public string? Atmosphere { get; set; }

    /// <summary>
    /// Key features or points of interest.
    /// </summary>
    [JsonPropertyName("features")]
    public List<string> Features { get; set; } = new();

    /// <summary>
    /// NPCs typically found at this location.
    /// </summary>
    [JsonPropertyName("inhabitants")]
    public List<string> Inhabitants { get; set; } = new();

    /// <summary>
    /// Encounters that can occur here.
    /// </summary>
    [JsonPropertyName("possibleEncounters")]
    public List<string> PossibleEncounters { get; set; } = new();

    /// <summary>
    /// Secrets or hidden elements.
    /// </summary>
    [JsonPropertyName("secrets")]
    public List<string> Secrets { get; set; } = new();

    /// <summary>
    /// Items or treasures found here.
    /// </summary>
    [JsonPropertyName("treasures")]
    public List<string> Treasures { get; set; } = new();

    /// <summary>
    /// Hazards or dangers in the location.
    /// </summary>
    [JsonPropertyName("hazards")]
    public List<string> Hazards { get; set; } = new();

    /// <summary>
    /// Connected locations or exits.
    /// </summary>
    [JsonPropertyName("connections")]
    public List<string> Connections { get; set; } = new();

    /// <summary>
    /// Map reference or description.
    /// </summary>
    [StringLength(500, ErrorMessage = "Map reference must not exceed 500 characters")]
    [JsonPropertyName("mapReference")]
    public string? MapReference { get; set; }

    /// <summary>
    /// DM notes for this location.
    /// </summary>
    [StringLength(1000, ErrorMessage = "Notes must not exceed 1000 characters")]
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }
}
