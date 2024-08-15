using System.ComponentModel.DataAnnotations;

namespace TODO_LIST.Api.Dtos;

public record class UpdateQuestDto(
    [Required][StringLength(50)] string Name,
    string? Description,
    [Required]string Genre,
    [Required][Range(0,10)]int Importance,
    [Required]TimeOnly StartTime
);
