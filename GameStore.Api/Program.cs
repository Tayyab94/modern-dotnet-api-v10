using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// this will add all the services required for validation to work properly in the application layer of the project 
builder.Services.AddValidation();

var app = builder.Build();

// Map Game EndPoints
app.MapGameEndPoints();

app.Run();
