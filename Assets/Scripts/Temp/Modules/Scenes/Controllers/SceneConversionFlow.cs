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
            this.IStageRuntimeValueObject.StageID = nextStageID;
            // ���� Scene���� ��ȯ.
            this.ISceneConverter.OperateSceneConversion(nextSceneName);
        }
    }
}
*/