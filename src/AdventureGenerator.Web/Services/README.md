# Services

This directory contains business logic services for the Adventure Generator.

## Planned Services

- **ContextManager**: Load, validate, and merge campaign context files
- **PromptBuilder**: Combine templates and context into structured LLM prompts
- **AdventureGenerator**: Interface with LLM or text generation backend
- **PostProcessor**: Format raw text into structured adventure sections
- **Exporter**: Save and export adventure documents
- **VersionManager**: Handle revisions and continuity across sessions

## Service Architecture

Services should follow dependency injection patterns and be registered in `Program.cs`.

Example service registration:
```csharp
builder.Services.AddScoped<IContextManager, ContextManager>();
```
