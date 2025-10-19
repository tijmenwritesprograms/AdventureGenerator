using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents a single act or chapter in an adventure.
/// Referenced in FSD Section 3.3 - Adventure Structure.
/// </summary>
public class Act
{
    /// <summary>
    /// Act number or identifier.
    /// </summary>
    [Range(1, 100, ErrorMessage = "Act number must be between 1 and 100")]
    [JsonPropertyName("actNumber")]
    public int ActNumber { get; set; } = 1;

    /// <summary>
    /// Title of the act.
    /// </summary>
    [Required(ErrorMessage = "Act title is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 characters")]
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Brief summary of the act.
    /// </summary>
    [StringLength(1000, ErrorMessage = "Summary must not exceed 1000 characters")]
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    /// <summary>
    /// Detailed description and narrative of the act.
    /// </summary>
    [Required(ErrorMessage = "Description is required")]
    [StringLength(10000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 10000 characters")]
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Primary objective or goal for this act.
    /// </summary>
    [StringLength(500, ErrorMessage = "Objective must not exceed 500 characters")]
    [JsonPropertyName("objective")]
    public string? Objective { get; set; }

    /// <summary>
    /// Scenes or key moments within the act.
    /// </summary>
    [JsonPropertyName("scenes")]
    public List<Scene> Scenes { get; set; } = new();

    /// <summary>
    /// Challenges or obstacles the party faces in this act.
    /// </summary>
    [JsonPropertyName("challenges")]
    public List<string> Challenges { get; set; } = new();

    /// <summary>
    /// NPCs featured in this act.
    /// </summary>
    [JsonPropertyName("featuredNPCs")]
    public List<string> FeaturedNPCs { get; set; } = new();

    /// <summary>
    /// Locations relevant to this act.
    /// </summary>
    [JsonPropertyName("locations")]
    public List<string> Locations { get; set; } = new();

    /// <summary>
    /// Encounters in this act (references to encounter IDs or names).
    /// </summary>
    [JsonPropertyName("encounters")]
    public List<string> Encounters { get; set; } = new();

    /// <summary>
    /// Possible outcomes or transitions to the next act.
    /// </summary>
    [JsonPropertyName("outcomes")]
    public List<string> Outcomes { get; set; } = new();

    /// <summary>
    /// DM notes and tips for running this act.
    /// </summary>
    [StringLength(2000, ErrorMessage = "DM notes must not exceed 2000 characters")]
    [JsonPropertyName("dmNotes")]
    public string? DmNotes { get; set; }
}

/// <summary>
/// Represents a scene within an act.
/// </summary>
public class Scene
{
    /// <summary>
    /// Scene number or order.
    /// </summary>
    [Range(1, 100, ErrorMessage = "Scene number must be between 1 and 100")]
    [JsonPropertyName("sceneNumber")]
    public int SceneNumber { get; set; } = 1;

    /// <summary>
    /// Scene title or name.
    /// </summary>
    [StringLength(200, ErrorMessage = "Title must not exceed 200 characters")]
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Description of what happens in this scene.
    /// </summary>
    [Required(ErrorMessage = "Description is required")]
    [StringLength(3000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 3000 characters")]
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Location where the scene takes place.
    /// </summary>
    [StringLength(200, ErrorMessage = "Location must not exceed 200 characters")]
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>
    /// NPCs present in this scene.
    /// </summary>
    [JsonPropertyName("npcs")]
    public List<string> NPCs { get; set; } = new();

    /// <summary>
    /// Possible player choices or decisions in this scene.
    /// </summary>
    [JsonPropertyName("choices")]
    public List<string> Choices { get; set; } = new();
}
