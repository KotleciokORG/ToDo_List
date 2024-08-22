using TODO_LIST.Api.Data;
using TODO_LIST.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("ToDoList");
builder.Services.AddSqlite<ToDoListContext>(connString);

var app = builder.Build();

app.MapQuestsEndpoints();
app.MapGenreEndpoints();

await app.MigrateDbAsync();

app.Run();
