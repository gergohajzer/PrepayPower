using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using PrepayPower.Application.Common.Interfaces;
using PrepayPower.Infrastructure.Files.Maps;

namespace PrepayPower.Infrastructure.Files;

public class VegetablesCsvReader : IVegetablesFileReader
{
    /// <summary>
    /// Reads a csv file containing vegetables.
    /// </summary>
    /// <param name="path">File path to the csv file.</param>
    /// <returns>A list of vegetable's name and price from the csv file.</returns>
    public IList<(string, double)> Read(string path)
    {
        using var reader = new StreamReader(path);
        var conf = new CsvConfiguration(new CultureInfo("en-IE", false))
        {
            Delimiter = ",",
        };
        using var csv = new CsvReader(reader, conf);
        csv.Context.RegisterClassMap<VegetableMap>();
        return csv.GetRecords<(string, double)>().ToList();
    }
}