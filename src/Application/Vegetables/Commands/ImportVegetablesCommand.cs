using MediatR;
using PrepayPower.Application.Common.Interfaces;
using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.Vegetables.Commands;

/// <summary>
/// Imports vegetables from a file and persists it.
/// </summary>
/// <param name="Path">Path to a file contains vegetables.</param>
public record ImportVegetablesCommand(string Path) : IRequest;

public class ImportVegetablesCommandHandler : IRequestHandler<ImportVegetablesCommand>
{
    private readonly IVegetablesFileReader _fileReader;
    private readonly IPersistenceContext _context;

    public ImportVegetablesCommandHandler(IVegetablesFileReader fileReader, IPersistenceContext context)
    {
        _fileReader = fileReader;
        _context = context;
    }


    public Task Handle(ImportVegetablesCommand request, CancellationToken cancellationToken)
    {
        var vegetableTuples = _fileReader.Read(request.Path);

        foreach (var vegetableTuple in vegetableTuples)
        {
            _context.Vegetables = _context.Vegetables.Append(new Vegetable(vegetableTuple.Item1, vegetableTuple.Item2));
        }
        return Task.CompletedTask;
    }
}