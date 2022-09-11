using TFL.API.Builder;
using TFL.API.Features.Road;
using TFL.API.Interfaces;
using TFL.API.Model;
using TFL.API.Request;
using TFL.Common.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IGet<RoadRequest, RoadModel>, GetRoadDetails>();
builder.Services.AddScoped<IAPIGetService<RoadModel>, RoadService>();
builder.Services.AddScoped<IAppSettings<RoadConfigRequest>, RoadAppSetting>();
builder.Services.AddScoped<IURI<RoadConfigRequest, RoadRequest>, RoadURIBuilder>();

builder.Services.AddControllers();

builder.Services.AddMvc(o =>
{
    o.AllowEmptyInputInBodyModelBinding = true;
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
