using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using System.Runtime.InteropServices.Marshalling;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Map Game EndPoints
app.MapGameEndPoints();

app.Run();
