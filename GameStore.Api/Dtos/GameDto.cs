namespace GameStore.Api.Dtos
{

    // Dto is the contract between the client and the server it present the share 
    // aggrement about the data that will be transferred and used by both sides.

    public record GameDto(
        int Id,string Name, string Genera,
        decimal Price, DateOnly ReleaseDate
        );

    public record CreateGameDto(
     string Name, string Genera,
    decimal Price, DateOnly ReleaseDate
    );
}
