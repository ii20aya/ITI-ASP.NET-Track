using MyApp.Features.Todos;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

    c.RoutePrefix = string.Empty;
});



// Seed data
TodoFeature.SeedData();

// Map Endpoints
app.MapTodoEndpoints();

// Health Check
app.MapHealthChecks("/health");

app.Run();
