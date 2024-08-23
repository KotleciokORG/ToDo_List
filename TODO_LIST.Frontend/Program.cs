using TODO_LIST.Frontend.Clients;
using TODO_LIST.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

var todoListApiUrl = builder.Configuration["ToDoListApiUrl"] ??
                     throw new Exception("ToDoListApiUrl is not set in configurations");

builder.Services.AddHttpClient<QuestsClient>(client =>
                 client.BaseAddress = new Uri(todoListApiUrl));
builder.Services.AddHttpClient<GenresClient>(client => 
                 client.BaseAddress = new Uri(todoListApiUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
