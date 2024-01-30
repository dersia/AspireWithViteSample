var builder = DistributedApplication.CreateBuilder(args);

var backend = builder.AddProject<Projects.AspireWithViteSample_Backend>("backend");

var frontend = builder.AddNpmApp("frontend", "../AspireWithViteSample.Frontend", "dev")
    .WithReference(backend)
    .WithServiceBinding(5173,"http","frontend","PORT");

builder.Build().Run();
