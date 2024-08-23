
# To Do (Quest) List

A simple implementation of To Do List with ASP.NET 


## Deployment

To deploy this project:

Copy project in a new catalog
```bash
  git clone https://github.com/KotleciokORG/ToDo_List.git
```
Go to To Do List catalog, then, first go to Api catalog and run 
```bash
  dotnet run
```
If something is wrong, try installing dependecies with
```bash
  dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.8
  dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.8
  dotnet add package MinimalApis.Extensions --version 0.11.0
  dotnet run
```
This will run API for your app, then go back and switch to Frontend catalog and run
```bash
  dotnet run
```
Now your browser should run with To Do List opened

If it's not, go to Frontend and Properties catalog, and in launchSettings.json find something like

```json
  "profiles": {
      "http": {
        "commandName": "Project",
        "dotnetRunMessages": true,
        "launchBrowser": true,
        "_comment": "This URL below is your link to website",
        "applicationUrl": "http://localhost:5149",
        "environmentVariables": {
          "ASPNETCORE_ENVIRONMENT": "Development"
        }
      }
```
This applicationUrl is the URL you should use in your browser

Hope it works!

## Acknowledgements

 - [Tutorial I followed, Thanks Julio Casal](https://youtu.be/RBVIclt4sOo?si=STTPlbJy5mLeQBGd)
 