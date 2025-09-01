using Foundations.ReferencesHandler;

using GameSystems.Shared.DataObject;
using GameSystems.Infrastructures.SceneConverterModule;
using GameSystems.Modules.Utilitys;

namespace GameSystems.Orchestrations.SceneConversionFlow
{
    public class SceneConversionFlow
    {
        private ISceneConverter ISceneConverter;
        private IStringParser IStringParser;

        private StageRuntimeData StageRuntimeData;

        public SceneConversionFlow()
        {
            var GlobalHandlerManager = LazyReferenceHandlerManager_Global.Instance;
            this.ISceneConverter = GlobalHandlerManager.GetDynamicHandler<SceneConverterHandler>().ISceneConverter;
            this.IStringParser = GlobalHandlerManager.GetUtilityHandler<StringParserHandler>().IStringParser;

            this.StageRuntimeData = GlobalHandlerManager.GetDynamicHandler<StageRuntimeDataHandler>().StageRuntimeData;
        }

        // Scene ���� Flow
        public void ConvertBattleScene(string inputRaw, string nextSceneName)
        {
            // String���� ���ڸ� ����. ( ���� �ν� ���� )
            // ���� ���� �� ����.
            if (!this.IStringParser.TryExtractInt(inputRaw, out int parsedValue)) return;

            // ����� StageID�� ����.
            this.ConvertBattleScene(parsedValue, nextSceneName);
        }

        // Scene ���� Flow
        public void ConvertBattleScene(int nextStageID, string nextSceneName)
        {
            // ����� StageID�� ����.
            this.StageRuntimeData.StageID = nextStageID;
            // ���� Scene���� ��ȯ.
            this.ISceneConverter.OperateSceneConversion(nextSceneName);
        }
    }
}
