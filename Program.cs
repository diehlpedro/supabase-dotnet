using DotNetEnv;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

var supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
var supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_ANON_KEY");

if (string.IsNullOrWhiteSpace(supabaseUrl) || string.IsNullOrWhiteSpace(supabaseKey))
    throw new Exception("Missing Supabase environment variables.");

builder.Services.AddHttpClient<SupabaseService>(client =>
{
    client.BaseAddress = new Uri(supabaseUrl);
    client.DefaultRequestHeaders.Add("apikey", supabaseKey);
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {supabaseKey}");
});

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger UI only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/readings", async (SupabaseService service) =>
{
    var readings = await service.GetReadingsAsync();
    return Results.Ok(readings);
});

app.MapPost("/readings", async (SupabaseService service, Reading reading) =>
{
    var success = await service.CreateReadingAsync(reading);
    return success ? Results.Created("/readings", reading) : Results.BadRequest();
});

app.Run();
