using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TODO_LIST.Api.Data;
using TODO_LIST.Api.Dtos;
using TODO_LIST.Api.Entities;
using TODO_LIST.Api.Mapping;

namespace TODO_LIST.Api.Endpoints;

public static class QuestsEndpoints{
    private static string GetGameEndpointName = "GetGame";
    public static WebApplication MapQuestsEndpoints(this WebApplication app){
        
        var questsGroup = app.MapGroup("quests")
                          .WithParameterValidation();

        //GET /quests
        questsGroup.MapGet("/", (ToDoListContext dbContext) => 
        {
            return dbContext.Quests
                            .Include((Quest q) => q.Genre)
                            .Select((Quest q) => q.ToQuestSummaryDto())
                            .AsNoTracking();
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
        questsGroup.MapPut("/{id}", (int id, UpdateQuestDto putQuest, ToDoListContext dbContext) => 
        {
            var existingQuest = dbContext.Quests.Find(id);
            if(existingQuest is null)
                return Results.NotFound();

            dbContext.Entry(existingQuest)
                     .CurrentValues
                     .SetValues(putQuest.ToEntity(id));

            dbContext.SaveChanges();

            return Results.NoContent();
        });

        //DELETE /quests/1
        questsGroup.MapDelete("/{id}", (int id, ToDoListContext dbContext) => 
        {
            dbContext.Quests
                     .Where((Quest q) => q.Id == id)
                     .ExecuteDelete();

            return Results.NoContent();
        });

        return app; //Should I return group?
    }
}