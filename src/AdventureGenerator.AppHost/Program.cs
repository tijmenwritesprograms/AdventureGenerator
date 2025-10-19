var builder = DistributedApplication.CreateBuilder(args);

var web = builder.AddProject<Projects.AdventureGenerator_Web>("web");

builder.Build().Run();
