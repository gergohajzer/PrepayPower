using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.Common.Interfaces;

public interface IVegetablesFileReader
{
    /// <summary>
    /// Reads vegetable data from file.
    /// </summary>
    /// <param name="path">File path to a csv file that contains vegetables and their prices.</param>
    /// <returns>Tuple containing vegetables and their prices.</returns>
    public IList<(string, double)> Read(string path);
}