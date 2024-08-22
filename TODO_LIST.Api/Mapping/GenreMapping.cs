using TODO_LIST.Api.Dtos;
using TODO_LIST.Api.Entities;

namespace TODO_LIST.Api.Mapping;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre){
        return new GenreDto(genre.Id, genre.Name);
        
    }
}