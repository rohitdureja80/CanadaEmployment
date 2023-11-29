using CanadaEmployment.Data;
using CanadaEmployment.Controllers;
using CanadaEmployment.Model;

using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<UnemploymentModel>("Unemployment");

// Add services to the container.

builder.Services.AddSingleton<IDataAccess, SqlDataAccess>();

builder.Services.AddControllers().AddOData(options => options.Select().Filter()
                .OrderBy().SetMaxTop(null)
                .AddRouteComponents(
                routePrefix: "odata",
                model: modelBuilder.GetEdmModel()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

//app.UseRouting();
app.UseAuthorization();
//app.UseEndpoints(endpoints => endpoints.MapControllers());
app.MapControllers();

app.Run();
