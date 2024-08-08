using ToDo_List.Models;

namespace ToDo_List.Clients;

public class QuestsClient{
    private readonly List<QuestSummary> quests = [
        new() {
            Id = 1,
            QuestName = "Poucz sie",
            Description = "Informatyka",
            QuestGenre = "Nauka",
            Importance = 6,
            StartTime = new TimeOnly(2,30)
        },
        new() {
            Id = 2,
            QuestName = "Wysypiaj sie",
            Description = "Najlepiej 8h",
            QuestGenre = "Codzienne",
            Importance = 10,
            StartTime = new TimeOnly(8,0)
        },
        new() {
            Id = 3,
            QuestName = "Zjedz Sniadanie",
            Description = "Platki na mleku",
            QuestGenre = "Żywienie",
            Importance = 3,
            StartTime = new TimeOnly(1,30)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();
    public QuestSummary[] GetQuestSummaries() => quests.ToArray();
    public void AddQuest(QuestDetails quest){
        ArgumentException.ThrowIfNullOrWhiteSpace(quest.QuestGenreId);
        QuestSummary questSummary = new(){
            Id = quests.Count+1,
            QuestName = quest.QuestName,
            Description = quest.Description,
            QuestGenre = genres.Single(genre => genre.Id == int.Parse(quest.QuestGenreId)).GenreName,
            Importance = quest.Importance,
            StartTime = quest.StartTime
        };

        quests.Add(questSummary);
    }
}

