using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TODO_LIST.Frontend.Converters;

namespace TODO_LIST.Frontend.Models;
public class QuestDetails{
    public int Id { get; set; }
    [Required(ErrorMessage = "Nazwa zadania wymagana")]
    public required string Name { get; set; }
    public string? Description { get; set; }
    [Required(ErrorMessage = "Gatunek zadania wymagany")]
    [JsonConverter(typeof(StringConverter))]
    public string? GenreId { get; set; }
    [Range(0,10)]
    public int Importance { get; set; }
    public TimeOnly StartTime { get; set; }

}