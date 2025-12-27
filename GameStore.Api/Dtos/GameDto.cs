using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos
{

    // Dto is the contract between the client and the server it present the share 
    // aggrement about the data that will be transferred and used by both sides.

    public record GameDto(
        int Id,string Name, string Genera,
        decimal Price, DateOnly ReleaseDate
        );

    public record CreateGameDto(
    [Required][StringLength(maximumLength:50)] string Name, [Required][StringLength(maximumLength: 20)] string Genera,
    [Range(1,1000)]decimal Price, DateOnly ReleaseDate
    );
}
