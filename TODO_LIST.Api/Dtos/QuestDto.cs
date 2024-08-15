namespace TODO_LIST.Api.Dtos;

public record class QuestDto(
    int ID,
    string Name,
    string? Description,
    string Genre,
    int Importance,
    TimeOnly StartTime
);