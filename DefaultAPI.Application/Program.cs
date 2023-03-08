using DefaultAPI.Application.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDataBase(builder.Configuration).AddServicesDependency().AddRepositoriesDependency();
builder.Services.ConfigureAPI().ConfigureMediatR().ConfigureAutoMapper().AddSwagger().AddCorsAllowAll();

var app = builder.Build();

app.UseSwaggerGen().UseCorsAllowAll().UseHttpAuthorization();
app.MapControllers();

app.Run();