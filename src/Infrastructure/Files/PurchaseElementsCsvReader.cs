using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using PrepayPower.Application.Common.Interfaces;
using PrepayPower.Infrastructure.Files.Maps;

namespace PrepayPower.Infrastructure.Files;

public class PurchaseElementsCsvReader : IPurchaseElementsFileReader
{
    /// <summary>
    /// Reads a csv file containing a purchase.
    /// </summary>
    /// <param name="path">File path to the csv file.</param>
    /// <returns>A list of vegetable's name and quantity from the csv file.</returns>
    public IList<(string, int)> Read(string path)
    {
        using var reader = new StreamReader(path);
        var conf = new CsvConfiguration(new CultureInfo("en-IE", false))
        {
            Delimiter = ",",
        };
        using var csv = new CsvReader(reader, conf);
        csv.Context.RegisterClassMap<PurchaseElementMap>();
        return csv.GetRecords<(string,int)>().ToList();
    }
}