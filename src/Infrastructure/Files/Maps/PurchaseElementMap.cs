using CsvHelper.Configuration;

namespace PrepayPower.Infrastructure.Files.Maps;

public sealed class PurchaseElementMap : ClassMap<(string, int)>
{
    public PurchaseElementMap()
    {
        Map(m => m.Item1).Name("PRODUCT");
        Map(m => m.Item2).Name("QUANTITY");
    }
}