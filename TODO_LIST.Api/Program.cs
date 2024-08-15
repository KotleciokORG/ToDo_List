using TODO_LIST.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

string GetGameEndpointName = "GetGame";

List<QuestDto> quests = [
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

//GET /quests
app.MapGet("quests", () => quests);

//GET /quests/1
app.MapGet("quests/{id}", (int id) => quests.Find((q) => q.ID == id))
    .WithName(GetGameEndpointName);

//POST /quests
app.MapPost("quests", (CreateQuestDto quest) => 
{
    QuestDto newQuest = new(
        quests.Count + 1,
        quest.Name,
        quest.Description,
        quest.Genre,
        quest.Importance,
        quest.StartTime
    );
    quests.Add(newQuest);

    return Results.CreatedAtRoute(GetGameEndpointName,new {id = newQuest.ID},newQuest);
});

//PUT /quests/1
app.MapPut("quests/{id}", (int id, UpdateQuestDto putQuest) => 
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
app.MapDelete("quests/{id}", (int id) => 
{
    quests.RemoveAll((QuestDto q) => q.ID == id);
    return Results.NoContent();
});

app.Run();
