using CV.DAL;
using CV.SRV;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddSingleton(typeof(Profil_SRV));
builder.Services.AddSingleton(typeof(Competence_SRV));
builder.Services.AddSingleton(typeof(School_SRV));
builder.Services.AddSingleton(typeof(Experience_SRV));
builder.Services.AddSingleton(typeof(Project_SRV));
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();



// using CV.DAL;
// using CV.SRV;
//
// var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// var builder = WebApplication.CreateBuilder(args);
//
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: MyAllowSpecificOrigins,
//         builder  =>
//         {
//             builder.WithOrigins("http://localhost:3000/")
//                 .AllowAnyHeader()
//                 .AllowAnyMethod();
//         });
// });
//
// builder.Services.AddSingleton(typeof(Profil_SRV), new Profil_SRV());
// builder.Services.AddSingleton(typeof(Competence_SRV), new Competence_SRV());
// builder.Services.AddSingleton(typeof(School_SRV), new School_SRV());
// builder.Services.AddSingleton(typeof(Experience_SRV), new Experience_SRV());
// builder.Services.AddControllers();
//
//
//
//
// var app = builder.Build();
//
// app.UseRouting();
// app.UseCors(MyAllowSpecificOrigins);
// app.UseAuthorization();
// app.MapControllers();
//
// app.Use(async (context, next) =>
// {
//     context.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
//     await next();
// });
//
//
// app.Run();  