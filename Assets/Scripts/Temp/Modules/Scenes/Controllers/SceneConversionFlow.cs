/*using Foundations.LazyReferenceRegistry;

namespace GameSystems.Modules.Scene
{
    public class SceneConversionFlow
    {
        private ISceneConverter ISceneConverter;
        private IStringParser IStringParser;
        private IStageRuntimeValueObject IStageRuntimeValueObject;

        public SceneConversionFlow()
        {
            var referenceRegistry = GlobalReferenceRegistry.Instance;
            this.ISceneConverter = referenceRegistry.GetPlainModule<SceneConverter>();
            this.IStringParser = referenceRegistry.GetPlainModule<StringParser>();
            this.IStageRuntimeValueObject = referenceRegistry.GetPlainModule<StageRuntimeValueObject>();
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
            this.IStageRuntimeValueObject.StageID = nextStageID;
            // 다음 Scene으로 전환.
            this.ISceneConverter.OperateSceneConversion(nextSceneName);
        }
    }
}
*/