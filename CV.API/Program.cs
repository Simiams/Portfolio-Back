using CV.SRV;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(Profil_SRV), new Profil_SRV());
builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();