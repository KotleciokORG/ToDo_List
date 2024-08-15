using TODO_LIST.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapQuestsEndpoints();

app.Run();
