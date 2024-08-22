using TODO_LIST.Api.Dtos;
using TODO_LIST.Api.Entities;

namespace TODO_LIST.Api.Mapping;

public static class QuestMapping
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

    public static Quest ToEntity(this UpdateQuestDto quest, int id){
        return new Quest()
        {
            Id = id,
            Name = quest.Name,
            Description = quest.Description,
            GenreId = quest.GenreId,
            Importance = quest.Importance,
            StartTime = quest.StartTime
        };
    }
    public static QuestSummaryDto ToQuestSummaryDto(this Quest quest){
        return new(
            quest.Id,
            quest.Name,
            quest.Description,
            quest.Genre!.Name,
            quest.Importance,
            quest.StartTime
        );
    }

    public static QuestDetailsDto ToQuestDetailsDto(this Quest quest){
        return new(
            quest.Id,
            quest.Name,
            quest.Description,
            quest.GenreId,
            quest.Importance,
            quest.StartTime
        );
    }
}
