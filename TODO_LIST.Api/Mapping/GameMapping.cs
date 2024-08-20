using TODO_LIST.Api.Dtos;
using TODO_LIST.Api.Entities;

namespace TODO_LIST.Api.Mapping;

public static class GameMapping
{
    public static Quest ToEntity(this CreateQuestDto quest){
        return new Quest()
        {
            Name = quest.Name,
            Description = quest.Description,
            GenreId = quest.GenreId,
            Importance = quest.Importance,
            StartTime = quest.StartTime
        };
    }
    public static QuestDto ToDto(this Quest quest){
        return new(
            quest.Id,
            quest.Name,
            quest.Description,
            quest.Genre!.Name,
            quest.Importance,
            quest.StartTime
        );
    }
}
