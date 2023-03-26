using CsvHelper.Configuration;

namespace PrepayPower.Infrastructure.Files.Maps;

public sealed class VegetableMap : ClassMap<(string, double)>
{
    public VegetableMap()
    {
        Map(m => m.Item1).Name("PRODUCT");
        Map(m => m.Item2).Name("PRICE");
    }
}