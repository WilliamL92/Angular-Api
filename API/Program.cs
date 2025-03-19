using Angular_Api.Domain.Repositories;
using Angular_Api.Application.Services;
using Angular_Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services au conteneur
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurer CORS pour autoriser toutes les origines, méthodes et headers
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
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

// Activer CORS avant l'authentification/autorisation
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
