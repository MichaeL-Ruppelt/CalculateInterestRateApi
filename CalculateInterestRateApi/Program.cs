using CalculateInterestRateApi.Entities;
using CalculateInterestRateApi.Interfaces;
using CalculateInterestRateApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddHttpClient();

builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<ICalculateService, CalculateService>();
builder.Services.AddScoped<IApiInterestRateService, ApiInterestRateService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyAllow", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Calculate Interest Rate Api", Version = "v1" }); });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AnyAllow");
app.UseAuthorization();

app.MapControllers();

app.Run();
