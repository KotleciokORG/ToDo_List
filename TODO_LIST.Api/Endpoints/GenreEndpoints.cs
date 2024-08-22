using Microsoft.EntityFrameworkCore;
using TODO_LIST.Api.Data;
using TODO_LIST.Api.Mapping;

namespace TODO_LIST.Api.Endpoints;

public static class GenreEndpoints{
    public static WebApplication MapGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        group.MapGet("/", async (ToDoListContext dbContext) =>
        {
            return await dbContext.Genres
                           .Select(genre => genre.ToDto())
                           .AsNoTracking()
                           .ToListAsync();
        });


        return app;
    }

}