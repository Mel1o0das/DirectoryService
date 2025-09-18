using DirectoryService.Application;
using DirectoryService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddScoped<ApplicationDbContext>(_ => 
    new ApplicationDbContext(builder.Configuration.GetConnectionString("DirectoryServiceDb")!));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DirectoryService"));
}

app.MapControllers();

app.Run();