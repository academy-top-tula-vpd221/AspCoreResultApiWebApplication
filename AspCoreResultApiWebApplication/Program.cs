using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    //await Results.Text("First Middleware").ExecuteAsync(context);
//    await next.Invoke();
//});

//app.Run((context) => Results.Text("Hello World!").ExecuteAsync(context));

Employee tom = new() { Name = "Tom", Age = 28 };

app.Map("/", () =>
{
    //return Results.Content("<h1>Hello world</h1>", "text/html");
    return Results.Json(tom, 
        new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.WriteAsString,
            WriteIndented = true,
        }
        );
});

app.Map("/yandex", () => Results.Ok("All right"));
app.Map("/404", () => Results.NotFound());

app.Run();

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
}
