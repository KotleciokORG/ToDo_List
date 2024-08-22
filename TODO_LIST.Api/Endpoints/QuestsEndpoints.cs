using Microsoft.EntityFrameworkCore;
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
        questsGroup.MapGet("/", async (ToDoListContext dbContext) => 
        {
            return await dbContext.Quests
                            .Include((Quest q) => q.Genre)
                            .Select((Quest q) => q.ToQuestSummaryDto())
                            .AsNoTracking()
                            .ToListAsync();
        });

        //GET /quests/1
        questsGroup.MapGet("/{id}", async (int id, ToDoListContext dbContext) => 
        {
            Quest? quest = await dbContext.Quests.FindAsync(id);

            return quest is null ? 
                Results.NotFound() : Results.Ok(quest.ToQuestDetailsDto());
        }
        ).WithName(GetGameEndpointName);

        //POST /quests
        questsGroup.MapPost("/", async (CreateQuestDto newQuest, ToDoListContext dbContext) => 
        {
            Quest quest = newQuest.ToEntity();
            
            dbContext.Quests.Add(quest);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetGameEndpointName,new {id = quest.Id},quest.ToQuestDetailsDto());
        });

        //PUT /quests/1
        questsGroup.MapPut("/{id}", async (int id, UpdateQuestDto putQuest, ToDoListContext dbContext) => 
        {
            var existingQuest = await dbContext.Quests.FindAsync(id);
            if(existingQuest is null)
                return Results.NotFound();

            dbContext.Entry(existingQuest)
                     .CurrentValues
                     .SetValues(putQuest.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /quests/1
        questsGroup.MapDelete("/{id}", async (int id, ToDoListContext dbContext) => 
        {
            await dbContext.Quests
                     .Where((Quest q) => q.Id == id)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return app; //Should I return group?
    }
}