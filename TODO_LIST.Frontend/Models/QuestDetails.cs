using System.ComponentModel.DataAnnotations;

namespace TODO_LIST.Frontend.Models;
public class QuestDetails{
    public int Id { get; set; }
    [Required(ErrorMessage = "Nazwa zadania wymagana")]
    public required string QuestName { get; set; }
    public string? Description { get; set; }
    [Required(ErrorMessage = "Gatunek zadania wymagany")]
    public string? QuestGenreId { get; set; }
    [Range(0,10)]
    public int Importance { get; set; }
    public TimeOnly StartTime { get; set; }

}