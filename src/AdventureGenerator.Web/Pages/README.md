# Pages

This directory contains page-level Blazor components that define routes in the application.

## Planned Pages

- **Index**: Home page with welcome and quick start
- **CreateAdventure**: Main adventure creation interface
- **ContinueCampaign**: Load and continue existing campaigns
- **EditContext**: Manage campaign context files
- **ViewAdventure**: Display generated adventures
- **ExportAdventure**: Export options for adventures

## Routing

Blazor pages use the `@page` directive to define routes:
```razor
@page "/create"
```

## Page Organization

- Keep pages focused on layout and composition
- Move complex logic to services
- Use components for reusable UI elements
