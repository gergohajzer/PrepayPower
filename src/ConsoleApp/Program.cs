using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrepayPower.Application.Offers;
using PrepayPower.Application.Purchases.Commands;
using PrepayPower.Application.Purchases.Queries;
using PrepayPower.Application.Vegetables.Commands;
using PrepayPower.Domain.Entities;

if (args.Length < 2)
{
    Console.Error.WriteLine("Please provide a file containing vegetables, a file containing a purchase and a directory where you want to export your receipt.");
    return -1;
}
if (!File.Exists(args[0]))
{
    Console.Error.WriteLine($"File does not exist at path: '{args[0]}'.");
    return -1;
}
if (!File.Exists(args[1]))
{
    Console.Error.WriteLine($"File does not exist at path: '{args[1]}'.");
    return -1;
}
if (!Directory.Exists(args[2]))
{
    Console.Error.WriteLine($"Directory does not exist at path: '{args[2]}'.");
    return -1;
}

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices();
    })
    .Build();

using IServiceScope serviceScope = host.Services.CreateScope();
var provider = serviceScope.ServiceProvider;
var mediator = provider.GetRequiredService<IMediator>();

await mediator.Send(new ImportVegetablesCommand(args[0]));

var purchase = await mediator.Send(new ImportPurchaseCommand(args[1]));

var offers = new List<Offer>
{
    new ("TO001", "If you buy at least 5 tomato, we will give you one for free.", TomatoOffers.OneFreeAfterFive),
    new ("PO001", "Every third potato is free.", PotatoOffers.EveryThirdIsFree),
    new ("CO001", "For every 5€ spent on Tomatoes, we will deduct one euro.", CarrotOffers.AfterEvery5EurDeduct1Eur)
};

await mediator.Send(new ApplyOffersOnPurchaseCommand(offers, purchase));

var receipt = await mediator.Send(new GetReceiptForPurchaseCommand(purchase));

await using var writer = new StreamWriter(Path.Combine(args[2], $"{purchase.Date:yyyy-MM-dd-HH-mm-ss}_{Guid.NewGuid()}.txt"));
writer.Write(receipt);

return 0;
