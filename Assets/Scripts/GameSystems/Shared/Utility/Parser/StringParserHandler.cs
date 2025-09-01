
using Foundations.ReferencesHandler;

namespace GameSystems.Modules.Utilitys
{
    public class StringParserHandler : IUtilityReferenceHandler
    {
        public IStringParser IStringParser { get; set; }
    }

    public interface IStringParser
    {
        public bool TryExtractInt(string rawData, out int parsedValue);
    }
}