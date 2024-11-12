using BuildingBlocks.Exceptions.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssembly(typeof(Program).Assembly);
    opt.AddOpenBehavior(typeof(ValidationBehavior<,>));
    opt.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(_ => { });

app.Run();