using System;

namespace DriverExplorer.UI.Localization
{
    public static class Humanizer
    {
        public static string Humanize(this Enum @enum)
        {
            var name = @enum.ToString();
            var key = $"Enum_{@enum.GetType().Name}_{name}";
            return Resource.ResourceManager.GetString(key) ?? name;
        }
    }
}
