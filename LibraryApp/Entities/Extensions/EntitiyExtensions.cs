

using System.Text.Json;

namespace LibraryApp.Entities.Extensions;

public static class EntitiyExtensions
{
    public static T? Copy<T>(this T itemToCopy) where T : IEntity
    {
        var json = JsonSerializer.Serialize(itemToCopy);
        string sciezkaPliku = @"C:\Sciezka\Do\Readers.txt";
        try
        {
            using (StreamWriter writer = new StreamWriter(sciezkaPliku))
            {
                writer.WriteLine(json);
            }
            Console.WriteLine("Dane zostały zapisane do pliku.");
        }
        catch (IOException e)
        {
            Console.WriteLine("Wystąpił błąd podczas zapisu do pliku: " + e.Message);
        }
        return JsonSerializer.Deserialize<T>(json);
    }
}

