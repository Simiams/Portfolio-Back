using CV.DAL;
using CV.SRV;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(Profil_SRV), new Profil_SRV());
builder.Services.AddSingleton(typeof(Competence_SRV), new Competence_SRV());
builder.Services.AddSingleton(typeof(School_SRV), new School_SRV());
builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();  