using MediatR;
using PrepayPower.Application.Common.Interfaces;
using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.Purchases.Commands;

/// <summary>
/// Imports a purchase from a file and persists it.
/// </summary>
/// <param name="Path">Path to a file contains a purchase.</param>
public record ImportPurchaseCommand(string Path) : IRequest<Purchase>;

public class ImportPurchaseCommandHandler : IRequestHandler<ImportPurchaseCommand, Purchase>
{
    private readonly IPurchaseElementsFileReader _fileReader;
    private readonly IPersistenceContext _context;

    public ImportPurchaseCommandHandler(IPurchaseElementsFileReader fileReader, IPersistenceContext context)
    {
        _fileReader = fileReader;
        _context = context;
    }


    public Task<Purchase> Handle(ImportPurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchaseElements = new List<PurchaseElement>();
        var purchaseElementTuples = _fileReader.Read(request.Path);

        foreach (var purchaseElementTuple in purchaseElementTuples)
        {
            purchaseElements.Add(new PurchaseElement(_context.Vegetables.Single(x => x.Name == purchaseElementTuple.Item1), purchaseElementTuple.Item2));
        }

        var purchase = new Purchase(purchaseElements);

        _context.Purchases = _context.Purchases.Append(purchase);

        return Task.FromResult<Purchase>(purchase);
    }
}