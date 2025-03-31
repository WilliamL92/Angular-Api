using Angular_Api.Domain.Repositories;
using Angular_Api.Application.Services;
using Angular_Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services au conteneur
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurer CORS pour autoriser les requêtes de l'application Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1.fr:8080") // Remplacez par l'URL de votre application Angular
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Enregistrer les services et les dépôts
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configurer le pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Utiliser la politique CORS définie
app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
