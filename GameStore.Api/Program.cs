using GameStore.Api.Dtos;
using System.Runtime.InteropServices.Marshalling;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);



var app = builder.Build();


List<GameDto> gamesList = [
       new GameDto(1, "The Witcher 3", "RPG", 39.99m, new DateOnly(2015, 5, 19)),
       new GameDto(2, "Cyberpunk 2077", "RPG", 59.99m, new DateOnly(2020, 12, 10)),
       new GameDto(3, "Minecraft", "Sandbox", 26.95m, new DateOnly(2011, 11, 18)),
       new GameDto(4, "Among Us", "Party", 4.99m, new DateOnly(2018, 6, 15)),
         new GameDto(5, "God of War", "Action", 49.99m, new DateOnly(2018, 4, 20)),
         new GameDto(6, "Hades", "Roguelike", 24.99m, new DateOnly(2020, 9, 17)),
           new GameDto(1, "The Last oneS", "RPG", 39.99m, new DateOnly(2015, 5, 19)),
    ];

// Get  / games
app.MapGet("/games", () => gamesList);


// Get / Get Game by Id

const string GetEndPointName = "GetGame";

app.MapGet("/games/{id}", (int id)=> {


    var data = gamesList.Find(game => game.Id == id);
  
    return data is null? Results.NotFound(): Results.Ok(data);
   
}).WithName(GetEndPointName);


// POT

app.MapPost("/games",(CreateGameDto mode)=>
{
        GameDto data = new GameDto(gamesList.Count + 1, mode.Name,
         mode.Genera,
         mode.Price,
        mode.ReleaseDate);

    gamesList.Add(data);

    return Results.CreatedAtRoute(GetEndPointName, new { id = data.Id });
});


// Update

app.MapPut("/games/{id}", (int id, CreateGameDto mode) =>
{
    var index = gamesList.FindIndex(game => game.Id == id);

    if (index == -1)
    {
        return Results.NotFound();
    }

    gamesList[index] = new GameDto(id, mode.Name,
         mode.Genera,
         mode.Price,
        mode.ReleaseDate);

    return Results.NoContent();

}).WithName("UpdateMovie");



app.MapDelete("/games/{id}", (int id) =>
{
    //var data = gamesList.Find(game => game.Id == id);
    //gamesList.Remove(data);

    //var index = gamesList.FindIndex(game => game.Id == id);
    //gamesList.RemoveAt(index);

   gamesList.RemoveAll(all => all.Id == id);
    return Results.NoContent();
}).WithName("DeleteMovie");

app.Run();
