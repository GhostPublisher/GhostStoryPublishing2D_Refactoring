using System.Text;

using Foundations.LazyReferenceRegistry;

namespace GameSystems.Modules.Scene
{
    public interface IStringParser
    {
        public bool TryExtractInt(string rawData, out int parsedValue);
    }

    public class StringParser : IStringParser, IReferenceLink
    {
        public bool TryExtractInt(string rawData, out int parsedValue)
        {
            parsedValue = -1;

            if (string.IsNullOrEmpty(rawData)) return false;

            var filteredString = new StringBuilder(rawData.Length);

            foreach (var ch in rawData)
            {
                if (ch >= '0' && ch <= '9') filteredString.Append(ch);
            }

            if (filteredString.Length == 0) return false;

            if (int.TryParse(filteredString.ToString(), out var parsed))
            {
                parsedValue = parsed;
//                UnityEngine.Debug.Log($"Á¤¼ö·Î ¹Ù²Û Value : {parsedValue}");
                return true;
            }

            return false;
        }
    }
}