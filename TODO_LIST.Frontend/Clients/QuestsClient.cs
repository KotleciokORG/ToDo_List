using TODO_LIST.Frontend.Models;

namespace TODO_LIST.Frontend.Clients;

public class QuestsClient{
    private readonly List<QuestSummary> quests = [
        new() {
            Id = 1,
            Name = "Poucz sie",
            Description = "Informatyka",
            Genre = "Nauka",
            Importance = 6,
            StartTime = new TimeOnly(2,30)
        },
        new() {
            Id = 2,
            Name = "Wysypiaj sie",
            Description = "Najlepiej 8h",
            Genre = "Codzienne",
            Importance = 10,
            StartTime = new TimeOnly(8,0)
        },
        new() {
            Id = 3,
            Name = "Zjedz Sniadanie",
            Description = "Platki na mleku",
            Genre = "Żywienie",
            Importance = 3,
            StartTime = new TimeOnly(1,30)
        }
    ];
    private int IdCounter = 3;
    private readonly Genre[] genres = new GenresClient().GetGenres();
    public QuestSummary[] GetQuestSummaries() => quests.ToArray();
    public void AddQuest(QuestDetails quest)
    {
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
    }

    public void UpdateQuest(QuestDetails updatedQuest){
        QuestSummary existingQuest = GetQuestSummaryById(updatedQuest.Id);
        var genre = GetGenreById(updatedQuest.GenreId);

        existingQuest.Name = updatedQuest.Name;
        existingQuest.Description = updatedQuest.Description;
        existingQuest.Genre = genre.GenreName;
        existingQuest.Importance = updatedQuest.Importance;
        existingQuest.StartTime = updatedQuest.StartTime;
    }

    public void DeleteQuest(int id){
        var quest = GetQuestSummaryById(id);
        quests.Remove(quest);
    } 

    public QuestDetails GetQuest(int ID)
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

    private QuestSummary GetQuestSummaryById(int ID)
    {
        QuestSummary? quest = quests.Find(quest_sum => quest_sum.Id == ID); //quest summary o ktory chodzi
        ArgumentNullException.ThrowIfNull(quest);
        return quest;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
    }
    
}

