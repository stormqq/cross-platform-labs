using Microsoft.AspNetCore.Authentication.JwtBearer;
using lab13_1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-6tcz4ihaqxbrx7aw.us.auth0.com/";
    options.Audience = "http://localhost:3001/";
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/labs/lab1", async (HttpContext context) =>
    {
        var request = await context.Request.ReadFromJsonAsync<Lab1Request>();

        var sa = request.SA;
        var sb = request.SB;
        
        var result = labs_sources.Lab1.CalculateCyclicDistance(sa, sb);
        var resObj = new LabResult { Result = result };

        return Results.Json(resObj);
    })
    .WithName("GetLab1")
    .WithOpenApi()
    .RequireAuthorization();

app.MapPost("/labs/lab2", async (HttpContext context) =>
    {
        var request = await context.Request.ReadFromJsonAsync<Lab2Request>();
        var k = request.K;
        var p = request.P;
        var result = labs_sources.Lab2.CalculateEnts(k, p);
        var resObj = new LabResult { Result = result.ToString() };
        return Results.Json(resObj);
    })
    .WithName("GetLab2")
    .WithOpenApi()
    .RequireAuthorization();

app.MapPost("/labs/lab3", async (HttpContext context) =>
    {
        var request = await context.Request.ReadFromJsonAsync<Lab3Request>();
        var rectangles = request.Rectangles.Split(' ').Select(int.Parse).ToList();
        var n = request.n;
        var result = labs_lib.Lab3.Calculate(rectangles, n);
        var resObj = new LabResult { Result = result.ToString() };
        return Results.Json(resObj);
    })
    .WithName("GetLab3")
    .WithOpenApi()
    .RequireAuthorization();

app.MapControllers();

app.Run("http://localhost:3001/");
