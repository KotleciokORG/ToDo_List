using ToDo_List.Models;

namespace ToDo_List.Clients;

public class TasksClient{
    private readonly List<TaskSummary> tasks = [
        new() {
            Id = 1,
            TaskName = "Poucz sie",
            Description = "Informatyka",
            TaskGenre = "Nauka",
            Importance = 6,
            StartTime = new TimeOnly(2,30)
        },
        new() {
            Id = 2,
            TaskName = "Wysypiaj sie",
            Description = "Najlepiej 8h",
            TaskGenre = "Codzienne",
            Importance = 10,
            StartTime = new TimeOnly(8,0)
        },
        new() {
            Id = 3,
            TaskName = "Zjedz Sniadanie",
            Description = "Platki na mleku",
            TaskGenre = "Żywienie",
            Importance = 3,
            StartTime = new TimeOnly(1,30)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();
    public TaskSummary[] GetTaskSummaries() => tasks.ToArray();
    public void AddTask(TaskDetails task){
        ArgumentException.ThrowIfNullOrWhiteSpace(task.TaskGenreId);
        TaskSummary taskSummary = new(){
            Id = tasks.Count+1,
            TaskName = task.TaskName,
            Description = task.Description,
            TaskGenre = genres.Single(genre => genre.Id == int.Parse(task.TaskGenreId)).GenreName,
            Importance = task.Importance,
            StartTime = task.StartTime
        };

        tasks.Add(taskSummary);
    }
}

