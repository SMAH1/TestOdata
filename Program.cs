using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using TestOdata.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookLists"));
services.AddControllers().AddOData(opt =>
{
    opt
    .Count().Filter().Expand().Select().OrderBy().SetMaxTop(5)
    .AddRouteComponents("odata", GetEdmOdataModel())
    ;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseODataRouteDebug();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

IEdmModel GetEdmOdataModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

    builder.EntitySet<Author>("Authors");
    builder.EntitySet<Book>("Books");

    return builder.GetEdmModel();
}
