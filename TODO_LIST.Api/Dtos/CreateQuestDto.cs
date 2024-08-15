namespace TODO_LIST.Api.Dtos;

public record class CreateQuestDto(
    string Name,
    string Description,
    string Genre,
    int Importance,
    TimeOnly StartTime
);
