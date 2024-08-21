using Microsoft.EntityFrameworkCore.Infrastructure;
using TODO_LIST.Api.Data;
using TODO_LIST.Api.Dtos;
using TODO_LIST.Api.Entities;
using TODO_LIST.Api.Mapping;

namespace TODO_LIST.Api.Endpoints;

public static class QuestsEndpoints{
    private static string GetGameEndpointName = "GetGame";

    private static readonly List<QuestSummaryDto> quests = [
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
        questsGroup.MapGet("/", (ToDoListContext dbContext) => 
        {
            return dbContext.Quests.
                Select<Quest,QuestDetailsDto>
                    ((Quest q) => q.ToQuestDetailsDto());
        });

        //GET /quests/1
        questsGroup.MapGet("/{id}", (int id, ToDoListContext dbContext) => 
            {
                Quest? quest = dbContext.Quests.Find(id);

                return quest is null ? 
                    Results.NotFound() : Results.Ok(quest.ToQuestDetailsDto());
            }
        ).WithName(GetGameEndpointName);

        //POST /quests
        questsGroup.MapPost("/", (CreateQuestDto newQuest, ToDoListContext dbContext) => 
        {
            Quest quest = newQuest.ToEntity();
            
            dbContext.Quests.Add(quest);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetGameEndpointName,new {id = quest.Id},quest.ToQuestDetailsDto());
        });

        //PUT /quests/1
        questsGroup.MapPut("/{id}", (int id, UpdateQuestDto putQuest) => 
        {
            int replIndex = quests.FindIndex((QuestSummaryDto q) => q.ID == id);
            ArgumentException.Equals(replIndex,-1);
            QuestSummaryDto updatedQuest = new(
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
            quests.RemoveAll((QuestSummaryDto q) => q.ID == id);
            return Results.NoContent();
        });

        return app; //Should I return group?
    }
}