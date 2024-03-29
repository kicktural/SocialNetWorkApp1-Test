using MassTransit;
using SocialNetwork.Business.Consumer;
using SocialNetwork.Business.DependencyResolvers;
using SocialNotework.Entities.SharedModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Create();
// Add services to the container.

builder.Services.AddMassTransit(config=>
{
    config.AddConsumer<ReciveEmailCommand>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost");

        //cfg.Message<SendEmailCommand>(x => x.SetEntityName("SendEmailCommand"));
        //cfg.ReceiveEndpoint("send-email-command", c =>
        //{
        //    c.ConfigureConsumer<ReciveEmailCommand>(ctx);
        //});
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
