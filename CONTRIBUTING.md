# Contributing to D&D Adventure Generator

Thank you for your interest in contributing to the D&D Adventure Generator! This document provides guidelines and information for contributors.

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK or later
- Git
- A code editor (Visual Studio, VS Code, or Rider recommended)

### Setting Up Your Development Environment

1. Fork and clone the repository:
   ```bash
   git clone https://github.com/tijmenwritesprograms/AdventureGenerator.git
   cd AdventureGenerator
   ```

2. Install .NET Aspire workload:
   ```bash
   dotnet workload install aspire
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Build the solution:
   ```bash
   dotnet build
   ```

5. Run the application:
   ```bash
   dotnet run --project src/AdventureGenerator.AppHost
   ```
   Or run the web app directly:
   ```bash
   dotnet run --project src/AdventureGenerator.Web
   ```

## 📋 Development Guidelines

### Code Style

This project uses EditorConfig for consistent formatting. Key conventions:

- **Indentation**: 4 spaces for C#, 2 spaces for JSON/YAML
- **Naming**: 
  - PascalCase for classes, methods, properties
  - camelCase for private fields
  - Interfaces prefixed with 'I'
- **Braces**: Opening braces on new lines
- **Usings**: System directives first

Your IDE should automatically apply these settings.

### Project Structure

```
src/
├── AdventureGenerator.Web/          # Main Blazor Server app
│   ├── Components/                   # Reusable UI components
│   ├── Pages/                        # Page-level components (routes)
│   ├── Services/                     # Business logic services
│   ├── Models/                       # Data models and DTOs
│   └── wwwroot/                      # Static files (CSS, JS, images)
├── AdventureGenerator.AppHost/       # Aspire orchestration
└── AdventureGenerator.ServiceDefaults/ # Shared configuration
```

### Coding Standards

- Enable nullable reference types (`<Nullable>enable</Nullable>`)
- Use dependency injection for services
- Follow SOLID principles
- Write meaningful commit messages
- Add XML documentation comments for public APIs
- Keep methods focused and single-purpose

### Testing

When adding new features:
- Write unit tests for services and business logic
- Consider integration tests for complex workflows
- Test Blazor components where appropriate

## 🔄 Workflow

### Branching Strategy

- `main` - Stable, production-ready code
- `develop` - Integration branch for features
- `feature/*` - New features
- `bugfix/*` - Bug fixes
- `hotfix/*` - Urgent production fixes

### Pull Request Process

1. Create a feature branch from `develop`:
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. Make your changes, following the coding standards

3. Commit your changes with clear messages:
   ```bash
   git commit -m "Add feature: brief description"
   ```

4. Push to your fork:
   ```bash
   git push origin feature/your-feature-name
   ```

5. Create a Pull Request to the `develop` branch

6. Address any review feedback

### Commit Message Format

Use clear, descriptive commit messages:

```
<type>: <subject>

<body>

<footer>
```

Types:
- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `style`: Code style changes (formatting)
- `refactor`: Code refactoring
- `test`: Adding or updating tests
- `chore`: Maintenance tasks

Example:
```
feat: Add campaign context file parser

Implement service to load and validate campaign context JSON files.
Includes schema validation and error handling.

Closes #123
```

## 🐛 Reporting Issues

### Bug Reports

When reporting bugs, please include:
- Clear description of the issue
- Steps to reproduce
- Expected vs actual behavior
- Environment details (.NET version, OS)
- Relevant logs or error messages

### Feature Requests

For feature requests, describe:
- The problem you're trying to solve
- Your proposed solution
- Any alternatives you've considered
- How it aligns with project goals

## 📚 Documentation

- Update README.md for user-facing changes
- Update code comments and XML docs
- Add/update inline documentation for complex logic
- Reference the FSD (specs/fsd.md) for architectural decisions

## 🧪 Testing Locally

Before submitting a PR:

1. Ensure code builds without warnings:
   ```bash
   dotnet build
   ```

2. Run tests (when available):
   ```bash
   dotnet test
   ```

3. Test the application manually:
   ```bash
   dotnet run --project src/AdventureGenerator.Web
   ```

## 🤝 Code of Conduct

- Be respectful and inclusive
- Provide constructive feedback
- Focus on what's best for the project
- Show empathy towards other contributors

## 📞 Getting Help

- Check existing issues and PRs
- Review the [Functional Specification Document](specs/fsd.md)
- Ask questions in issue discussions
- Contact the maintainer if needed

## 📄 License

By contributing, you agree that your contributions will be licensed under the same license as the project (to be determined).

---

Thank you for contributing to the D&D Adventure Generator! 🎲
