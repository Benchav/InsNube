using FirebaseExamenple2.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<FirebaseService>();
var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
