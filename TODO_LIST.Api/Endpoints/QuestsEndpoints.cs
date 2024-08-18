using TODO_LIST.Api.Data;
using TODO_LIST.Api.Dtos;
using TODO_LIST.Api.Entities;

namespace TODO_LIST.Api.Endpoints;

public static class QuestsEndpoints{
    private static string GetGameEndpointName = "GetGame";

    private static readonly List<QuestDto> quests = [
        new (
            1,
            "Zadanie domowe",
            "Matematyka oraz informatyka",
            "Nauka",
            6,
            new TimeOnly(10,20)
        ),
        new (
            2,
            "Miłość",
            "Zadowolona dziewczyna",
            "Praca w domu",
            10,
            new TimeOnly(20,0)
        ),
        new (
            3,
            "Masaż plecków dziewczyny",
            "Dla Elizy",
            "Codzienne",
            8,
            new TimeOnly(22,0)
        ),
        new (
            4,
            "Randka z Elizą",
            "Przed spaniem",
            "Znajomości",
            6,
            new TimeOnly(10,20)
        ),
    ];
    public static WebApplication MapQuestsEndpoints(this WebApplication app){
        var questsGroup = app.MapGroup("quests")
                          .WithParameterValidation();

        //GET /quests
        questsGroup.MapGet("/", () => quests);

        //GET /quests/1
        questsGroup.MapGet("/{id}", (int id) => quests.Find((q) => q.ID == id))
            .WithName(GetGameEndpointName);

        //POST /quests
        questsGroup.MapPost("/", (CreateQuestDto quest, ToDoListContext dbContext) => 
        {
            Quest newQuest = new()
            {
                Name = quest.Name,
                Description = quest.Description,
                GenreId = quest.GenreId,
                Genre = dbContext.Genres.Find(quest.GenreId),
                Importance = quest.Importance,
                StartTime = quest.StartTime
            };

            dbContext.Quests.Add(newQuest);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndpointName,new {id = newQuest.Id},newQuest);
        });

        //PUT /quests/1
        questsGroup.MapPut("/{id}", (int id, UpdateQuestDto putQuest) => 
        {
            int replIndex = quests.FindIndex((QuestDto q) => q.ID == id);
            ArgumentException.Equals(replIndex,-1);
            QuestDto updatedQuest = new(
                id,
                putQuest.Name,
                putQuest.Description,
                putQuest.Genre,
                putQuest.Importance,
                putQuest.StartTime
            );
            quests[replIndex] = updatedQuest;
            return Results.NoContent();
        });

        //DELETE /quests/1
        questsGroup.MapDelete("/{id}", (int id) => 
        {
            quests.RemoveAll((QuestDto q) => q.ID == id);
            return Results.NoContent();
        });

        return app; //Should I return group?
    }
}