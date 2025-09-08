using System.Text;

namespace GameSystems.PlainServices
{
    public interface IStringParser : IPlainService
    {
        public bool TryExtractInt(string rawData, out int parsedValue);
    }

    public class StringParser : IStringParser
    {
        public bool TryExtractInt(string rawData, out int parsedValue)
        {
            parsedValue = 0;

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
                //                UnityEngine.Debug.Log($"정수로 바꾼 Value : {parsedValue}");
                return true;
            }

            return false;
        }
    }
}
