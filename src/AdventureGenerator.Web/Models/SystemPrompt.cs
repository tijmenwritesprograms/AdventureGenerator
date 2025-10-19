using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdventureGenerator.Web.Models;

/// <summary>
/// Represents the system prompt template for LLM instructions.
/// Referenced in FSD Section 2.1 - Core Inputs (System Prompt).
/// </summary>
public class SystemPrompt
{
    /// <summary>
    /// Unique identifier for the prompt template.
    /// </summary>
    [JsonPropertyName("promptId")]
    public string PromptId { get; set; } = string.Empty;

    /// <summary>
    /// Name or title of the prompt template.
    /// </summary>
    [Required(ErrorMessage = "Prompt name is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Prompt name must be between 1 and 200 characters")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Version of the prompt template for tracking changes.
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; } = "1.0";

    /// <summary>
    /// The main prompt template text with placeholders for context injection.
    /// </summary>
    [Required(ErrorMessage = "Template is required")]
    [StringLength(10000, MinimumLength = 10, ErrorMessage = "Template must be between 10 and 10000 characters")]
    [JsonPropertyName("template")]
    public string Template { get; set; } = string.Empty;

    /// <summary>
    /// Description of what this prompt is designed to generate.
    /// </summary>
    [StringLength(1000, ErrorMessage = "Description must not exceed 1000 characters")]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Expected output format (e.g., "Markdown", "JSON", "Structured Text").
    /// </summary>
    [JsonPropertyName("outputFormat")]
    public string OutputFormat { get; set; } = "Markdown";

    /// <summary>
    /// Tone expectations (e.g., "Professional DM voice", "Descriptive and immersive").
    /// </summary>
    [JsonPropertyName("toneGuidelines")]
    public List<string> ToneGuidelines { get; set; } = new();

    /// <summary>
    /// Structure guidelines for the generated content.
    /// </summary>
    [JsonPropertyName("structureGuidelines")]
    public List<string> StructureGuidelines { get; set; } = new();

    /// <summary>
    /// Quality expectations and constraints.
    /// </summary>
    [JsonPropertyName("qualityConstraints")]
    public List<string> QualityConstraints { get; set; } = new();

    /// <summary>
    /// Placeholders available in the template (e.g., {campaign_context}, {party_data}).
    /// </summary>
    [JsonPropertyName("availablePlaceholders")]
    public List<string> AvailablePlaceholders { get; set; } = new();

    /// <summary>
    /// Example outputs or references for this prompt type.
    /// </summary>
    [JsonPropertyName("examples")]
    public List<string> Examples { get; set; } = new();

    /// <summary>
    /// Additional metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string> Metadata { get; set; } = new();
}
