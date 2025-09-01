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

        // Scene 변경 Flow
        public void ConvertBattleScene(string inputRaw, string nextSceneName)
        {
            // String에서 숫자만 추출. ( 음수 인식 안함 )
            // 추출 실패 시 리턴.
            if (!this.IStringParser.TryExtractInt(inputRaw, out int parsedValue)) return;

            // 추출된 StageID를 저장.
            this.ConvertBattleScene(parsedValue, nextSceneName);
        }

        // Scene 변경 Flow
        public void ConvertBattleScene(int nextStageID, string nextSceneName)
        {
            // 추출된 StageID를 저장.
            this.StageRuntimeData.StageID = nextStageID;
            // 다음 Scene으로 전환.
            this.ISceneConverter.OperateSceneConversion(nextSceneName);
        }
    }
}
