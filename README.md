# 🧭 D&D Adventure Generator

An AI-assisted tool designed to create detailed Dungeons & Dragons adventures comparable in quality and structure to official published modules. Built with .NET 8, Blazor Server, and .NET Aspire orchestration.

## 📋 Overview

The D&D Adventure Generator leverages structured campaign context files and curated system prompts to produce coherent, lore-consistent, and narratively rich adventure content. It's designed to help Dungeon Masters create high-quality adventures while maintaining consistency with their campaign world.

### Key Features

- 🎲 **AI-Powered Generation**: Create complete D&D adventures with acts, NPCs, encounters, and locations
- 📚 **Context-Aware**: Uses campaign context files to maintain consistency
- 🔄 **Session Continuity**: Track and build upon previous adventures
- 🎨 **Modular Architecture**: Extensible design for future enhancements
- ⚡ **Modern Stack**: Built with .NET 8, Blazor Server, and .NET Aspire

## 🏗️ Project Structure

```
AdventureGenerator/
├── src/
│   ├── AdventureGenerator.Web/          # Blazor Server application
│   │   ├── Components/                   # Blazor components
│   │   ├── Pages/                        # Page components
│   │   ├── Services/                     # Business logic services
│   │   ├── Models/                       # Data models
│   │   └── wwwroot/                      # Static files
│   ├── AdventureGenerator.AppHost/       # .NET Aspire orchestration
│   └── AdventureGenerator.ServiceDefaults/ # Shared configuration
├── specs/                                # Project specifications
│   └── fsd.md                            # Functional specification document
└── AdventureGenerator.sln                # Solution file
```

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [.NET Aspire workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/tijmenwritesprograms/AdventureGenerator.git
   cd AdventureGenerator
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application using .NET Aspire:
   ```bash
   dotnet run --project src/AdventureGenerator.AppHost
   ```

   Or run the web application directly:
   ```bash
   dotnet run --project src/AdventureGenerator.Web
   ```

### Building

Build the entire solution:
```bash
dotnet build
```

Build a specific project:
```bash
dotnet build src/AdventureGenerator.Web
```

## 🧩 Core Components

### Input Components
- **System Prompt**: Defines tone, structure, and quality expectations
- **Campaign Context File**: Campaign setting, factions, tone, major arcs
- **Story So Far**: Summary of previous sessions
- **Premise**: High-level adventure idea
- **Party File**: PC data including backstory and motivations
- **Existing Adventure File**: For extending or revising adventures

### Output Components
- **Adventure Document**: Complete adventure with acts, scenes, NPCs, and encounters
- **Summary/Outline**: Concise overview for quick DM reference
- **Metadata File**: Structured data about generated content

## 📚 Documentation

- [Functional Specification Document](specs/fsd.md) - Detailed project requirements and architecture

## 🛠️ Technology Stack

- **Framework**: .NET 8
- **UI Framework**: Blazor Server
- **Orchestration**: .NET Aspire
- **Language**: C# 12
- **Architecture**: Modular, service-oriented design

## 🏗️ Development

### Code Style

This project uses EditorConfig for consistent code formatting. Most IDEs will automatically apply these settings.

### Project Organization

- **Components/**: Reusable Blazor components
- **Pages/**: Page-level Blazor components (routes)
- **Services/**: Business logic and data access
- **Models/**: Data transfer objects and domain models

## 🎯 Roadmap

Future features planned for development:

- [ ] Encounter stat generation with CR scaling
- [ ] Visual map and region generator
- [ ] DM tools: pacing notes, random events
- [ ] VTT integration (Foundry, Roll20)
- [ ] Persistent world memory across campaigns
- [ ] CLI interface
- [ ] Export to PDF

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is currently unlicensed. Please contact the author for usage permissions.

## 👤 Author

**Tijmen van der Hilst**

## 🙏 Acknowledgments

- Built with .NET and Blazor
- Powered by .NET Aspire for orchestration
- Inspired by official D&D published modules
