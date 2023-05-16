

using System.Text.Json;

namespace LibraryApp.Entities.Extensions;

public static class EntitiyExtensions
    {
        public static T? Copy<T>(this T itemToCopy) where T : IEntity
        {
            var json = JsonSerializer.Serialize(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);
        }
    }

