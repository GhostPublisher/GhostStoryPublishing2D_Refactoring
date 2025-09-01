using Foundations.ReferencesHandler;

namespace GameSystems.Infrastructures.SceneConverterModule
{
    public class SceneConverterHandler : IDynamicReferenceHandler
    {
        public ISceneConverter ISceneConverter { get; set; }
    }

    public interface ISceneConverter
    {
        public void OperateSceneConversion(string nextSceneName);
    }
}