var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.CBS_WebAPI>("CbsWebApi");

builder.Build().Run();
