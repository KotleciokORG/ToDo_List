namespace TODO_LIST.Api.Dtos;

public record class QuestDetailsDto(
    int ID,
    string Name,
    string? Description,
    int GenreId,
    int Importance,
    TimeOnly StartTime
);