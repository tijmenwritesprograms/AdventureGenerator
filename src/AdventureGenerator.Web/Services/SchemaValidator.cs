using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using AdventureGenerator.Web.Models;

namespace AdventureGenerator.Web.Services;

/// <summary>
/// Service for validating data models against their schema definitions.
/// </summary>
public class SchemaValidator
{
    private readonly JsonSerializerOptions _jsonOptions;

    public SchemaValidator()
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
    }

    /// <summary>
    /// Validates an object against its data annotations.
    /// </summary>
    public SchemaValidationResult ValidateObject<T>(T obj) where T : class
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(obj);

        bool isValid = Validator.TryValidateObject(
            obj,
            validationContext,
            validationResults,
            validateAllProperties: true
        );

        return new SchemaValidationResult
        {
            IsValid = isValid,
            Errors = validationResults.Select(r => r.ErrorMessage ?? "Unknown error").ToList()
        };
    }

    /// <summary>
    /// Deserializes JSON and validates the result.
    /// </summary>
    public (T? Object, SchemaValidationResult ValidationResult) DeserializeAndValidate<T>(string json) where T : class
    {
        try
        {
            var obj = JsonSerializer.Deserialize<T>(json, _jsonOptions);
            if (obj == null)
            {
                return (null, new SchemaValidationResult
                {
                    IsValid = false,
                    Errors = new List<string> { "Failed to deserialize JSON" }
                });
            }

            var validationResult = ValidateObject(obj);
            return (obj, validationResult);
        }
        catch (JsonException ex)
        {
            return (null, new SchemaValidationResult
            {
                IsValid = false,
                Errors = new List<string> { $"JSON error: {ex.Message}" }
            });
        }
    }

    /// <summary>
    /// Serializes an object to JSON.
    /// </summary>
    public string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, _jsonOptions);
    }

    /// <summary>
    /// Round-trip test: serialize then deserialize and validate.
    /// </summary>
    public SchemaValidationResult RoundTripTest<T>(T obj) where T : class
    {
        try
        {
            // Serialize
            var json = Serialize(obj);

            // Deserialize
            var deserialized = JsonSerializer.Deserialize<T>(json, _jsonOptions);
            if (deserialized == null)
            {
                return new SchemaValidationResult
                {
                    IsValid = false,
                    Errors = new List<string> { "Failed to deserialize after serialization" }
                };
            }

            // Validate
            return ValidateObject(deserialized);
        }
        catch (Exception ex)
        {
            return new SchemaValidationResult
            {
                IsValid = false,
                Errors = new List<string> { $"Round-trip error: {ex.Message}" }
            };
        }
    }
}

/// <summary>
/// Validation result container.
/// </summary>
public class SchemaValidationResult
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; } = new();
}
