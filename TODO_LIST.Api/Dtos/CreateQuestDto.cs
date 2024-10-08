using System.ComponentModel.DataAnnotations;

namespace TODO_LIST.Api.Dtos;

public record class CreateQuestDto(
    [Required][StringLength(50)] string Name,
    string? Description,
    int GenreId,
    [Required][Range(0,10)]int Importance,
    [Required]TimeOnly StartTime
);
