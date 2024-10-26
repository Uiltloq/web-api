using Sandbox.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

#region services Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion services Swagger

builder.Services.AddTransient<ITimeService, ShortTimeService>();
builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
});

app.Run();
