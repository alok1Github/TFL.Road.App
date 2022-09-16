using Microsoft.AspNetCore.HttpLogging;
using TFL.API.Builder;
using TFL.API.ExceptionHandlers;
using TFL.API.Features.Road;
using TFL.API.filters;
using TFL.API.Interfaces;
using TFL.API.Model;
using TFL.API.Request;
using TFL.Common.Interfaces;
using IResult = TFL.API.Features.Road.IResult;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IGet<RoadRequest, RoadModel>, GetRoadDetails>();
builder.Services.AddScoped<IResult, RoadResult>();
builder.Services.AddScoped<HttpClient, HttpClient>();
builder.Services.AddScoped<IAPIGetService<RoadModel>, RoadService>();
builder.Services.AddScoped<IAppSettings<RoadConfigRequest>, RoadAppSetting>();
builder.Services.AddScoped<IURI<RoadConfigRequest, RoadRequest>, RoadURIBuilder>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpLogging
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
});

// Filters
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ValidationFilter>();
    options.Filters.Add<ExceptionFilter>();
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();

app.UseHttpsRedirection();

// Excetion handler 
app.UseMiddleware(typeof(GlobalErrorHandler));

// To Do : apply the security for api

app.UseAuthorization();

app.MapControllers();

app.Run();
