using Microsoft.AspNetCore.Http.HttpResults;
using TODO_LIST.Frontend.Models;

namespace TODO_LIST.Frontend.Clients;

public class QuestsClient(HttpClient httpClient)
{
    public async Task<QuestSummary[]> GetQuestAsync() => 
           await httpClient.GetFromJsonAsync<QuestSummary[]>("quests/") ?? [];
    public async Task<QuestDetails> GetQuestAsync(int ID) =>
        await httpClient.GetFromJsonAsync<QuestDetails>($"quests/ID") ?? 
        throw new Exception("Quest not found");

    /*
    { //to jest ID questa nie genre
        QuestSummary? quest = GetQuestSummaryById(ID);
        //trzeba zamienic w quest detail
        //czyli z opisu na liczbe
        Genre genre = genres.Single(genre => string.Equals(
            genre.GenreName,
            quest.Genre,
            StringComparison.OrdinalIgnoreCase));


        return new()
        {
            Id = ID,
            Name = quest.Name,
            Description = quest.Description,
            GenreId = genre.Id.ToString(),
            Importance = quest.Importance,
            StartTime = quest.StartTime
        };
    }
    */
    
    public async Task AddQuestAsync(QuestDetails quest) =>
           await httpClient.PostAsJsonAsync("quests/",quest);
    
    /*
    Genre genre = GetGenreById(quest.GenreId);
    QuestSummary questSummary = new()
    {
        Id = IdCounter + 1,
        Name = quest.Name,
        Description = quest.Description,
        Genre = genre.GenreName,
        Importance = quest.Importance,
        StartTime = quest.StartTime
    };
    IdCounter++;
    quests.Add(questSummary);
    */

    public async Task UpdateQuestAsync(QuestDetails updatedQuest) =>
           await httpClient.PutAsJsonAsync($"quests/{updatedQuest.Id}",updatedQuest);
    
    /*
    QuestSummary existingQuest = GetQuestSummaryById(updatedQuest.Id);
    var genre = GetGenreById(updatedQuest.GenreId);
    existingQuest.Name = updatedQuest.Name;
    existingQuest.Description = updatedQuest.Description;
    existingQuest.Genre = genre.GenreName;
    existingQuest.Importance = updatedQuest.Importance;
    existingQuest.StartTime = updatedQuest.StartTime;
    */

    public async Task DeleteQuestAsync(int id) =>
        await httpClient.DeleteAsync($"quests/{id}");


    
    
}

