namespace PrepayPower.Application.Common.Interfaces;

public interface IPurchaseElementsFileReader
{
    /// <summary>
    /// Reads purchase data from file.
    /// </summary>
    /// <param name="path">File path to a csv file that contains vegetables and their quantity.</param>
    /// <returns>Tuple containing vegetables and their quantity.</returns>
    public IList<(string, int)> Read(string path);
}