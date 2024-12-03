using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sqlServer = builder.AddConnectionString("sql");
//var database = builder.AddSqlServer("sqlResource")
//                      .WithConnectionStringRedirection(connectionString);

//var apiService = builder.AddProject<Projects.TestAspire_ApiService>("apiservice")
//        .WithReference(sqlServer);

var apiService = builder.AddProject<Projects.TestAspire_ApiService>("apiservice")
        .WithReplicas(2);

builder.AddProject<Projects.ConsoleApp1>("consoleapp1");
builder.AddProject<Projects.TestAspire_Web>("webfrontend")
    .WithExternalHttpEndpoints();


builder.Build().Run();
