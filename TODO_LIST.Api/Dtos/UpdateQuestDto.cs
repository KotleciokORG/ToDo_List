namespace TODO_LIST.Api.Dtos;

public record class UpdateQuestDto(
    string Name,
    string Description,
    string Genre,
    int Importance,
    TimeOnly StartTime
);
