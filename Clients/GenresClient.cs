using ToDo_List.Models;

namespace ToDo_List.Clients;

public class GenresClient{
    private readonly List<Genre> genres = [
        new() {
            Id = 1,
            GenreName = "Codzienne"
        },
        new() {
            Id = 2,
            GenreName = "Praca w domu"
        },
        new() {
            Id = 3,
            GenreName = "Nauka"
        },
        new() {
            Id = 4,
            GenreName = "Żywienie"
        }
    ];

    public Genre[] GetGenres() => genres.ToArray();
    public Genre? GetGenre(int id) => genres.Find(genre => id == genre.Id);
}