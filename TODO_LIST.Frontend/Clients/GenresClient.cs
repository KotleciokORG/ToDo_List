using TODO_LIST.Frontend.Models;

namespace TODO_LIST.Frontend.Clients;

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
        },
        new() {
            Id = 5,
            GenreName = "Hobby"
        },
        new() {
            Id = 6,
            GenreName = "Znajomości"
        }
    ];

    public Genre[] GetGenres() => genres.ToArray();
}