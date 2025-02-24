using Angular_Api.Domain.Repositories;
using Angular_Api.Application.Services;
using Angular_Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services au conteneur
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
