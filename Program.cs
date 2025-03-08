using FastEndpoints;
using FastEndpoints.Swagger;
using TaskManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints(options => 
{
    options.IncludeAbstractValidators = true; // This is important for validation!
});
builder.Services.AddSingleton<ITaskService,TaskService>();

builder.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "TaskManagerAPI";
        s.Version = "v1";
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Configure FastEndpoints with validation
app.UseFastEndpoints(c => 
{
    c.Errors.UseProblemDetails();
});


app.UseSwaggerGen();

app.Run();