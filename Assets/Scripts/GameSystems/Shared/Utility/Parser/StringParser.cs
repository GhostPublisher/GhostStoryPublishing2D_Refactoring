using System.Text;

using Foundations.ReferencesHandler;

namespace GameSystems.Modules.Utilitys
{
    public class StringParser : IStringParser
    {
        public StringParser()
        {
            var HandlerManager = LazyReferenceHandlerManagera_Local.Instance;
            HandlerManager.GetUtilityHandler<StringParserHandler>().IStringParser = this;
        }

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
                return true;
            }

            return false;
        }
    }
}