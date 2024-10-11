using Business;
using Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var conexion = builder.Configuration.GetConnectionString("conexion");

builder.Services.AddScoped<PersonalDAO>(provider => new PersonalDAO(conexion));
builder.Services.AddScoped<HijosDAO>(provider => new HijosDAO(conexion));
builder.Services.AddScoped<PersonalService>();
builder.Services.AddScoped<HijosService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurar el pipeline HTTP
app.UseRouting();

// Configuramos el cors para permitir todas las rutas
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
