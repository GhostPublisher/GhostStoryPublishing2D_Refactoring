/*using System.Collections;
using UnityEngine;

using GameSystems.Datas;
using GameSystems.Flows;
using GameSystems.Modules;
using GameSystems.Inputs;

using UnityEngine.SceneManagement;

namespace GameSystems.Inputs
{
    public interface IInputRouterManager
    {
        public IInputRouter CurrentInputRouter { get; }
        public void LoadInputRouter(LifeCycleType lifeCycleType, IFlowReferencHandler FlowReferencHandler);
        public void UnLoadInputRouter();
    }

    public class InputRouterManager : IInputRouterManager
    {
        private IInputRouter currentInputRouter;
        private InputState currentInputState;

        public IInputRouter CurrentInputRouter { get => currentInputRouter; }
        public InputState CurrentInputState { get => currentInputState; }

        public void LoadInputRouter(LifeCycleType lifeCycleType, IFlowReferencHandler FlowReferencHandler)
        {
            switch (lifeCycleType)
            {
                case LifeCycleType.LobbyScene:
                    //                    this.inputRouter = new Lobby_InputRouter(FlowReferencHandler);
                    break;
                case LifeCycleType.BattleScene:
                    //                    this.inputRouter = new Battle_InputRouter(FlowReferencHandler);
                    break;
                default:
                    break;
            }
        }

        public void UnLoadInputRouter()
        {
            this.currentInputRouter = null;
        }

        public void UpdateInputState()
        {
            this.currentInputRouter.UpdateInputState();
        }
    }

    public interface IInputRouter
    {
        public void UpdateInputState();
    }
    public enum InputState
    {
        None, GamePlay, Dialog
    }
}

namespace GameSystems.Boots
{
    // 게임 실행 시, 가장 먼저 호출되어야 하는 객체.
    public class MainBoot : MonoBehaviour
    {
        private IModuleLifeCycleManager ModuleLifeCycleManager;
        private IFlowLifeCycleManager FlowLifeCycleManager;
        private IInputRouterManager InputRouterManager;
        private void Awake()
        {
            this.ModuleLifeCycleManager = new ModuleLifeCycleManager();
            this.FlowLifeCycleManager = new FlowLifeCycleManager();
            this.InputRouterManager = new InputRouterManager();
        }
        public void LoadReference(LifeCycleType lifeCycleType)
        {
            // 각 Module 참조 로드 : 독립적
            this.ModuleLifeCycleManager.LoadMoudles(lifeCycleType);

            // 각 Flow 정의 : Module을 필수로 가져감.
            // MonoBehaviour를 상속하는 Flow의 경우에는, 해당 Flow의 멤버로 MonoBehaviour를 상속받는 SubFlow를 만들어서 해당 Flow로 연결된 일을 위임시키는 식으로 수행.
            this.FlowLifeCycleManager.LoadFlows(lifeCycleType, this.ModuleLifeCycleManager.ModuleReferenceHandler);

            // 각 Input 정의 : Flow를 필수로 가져감.
//            this.InputRouterManager.LoadInputRouter(lifeCycleType);

            // 각 View 정의 : 경우(버튼의 유무)에 따라서 Flow를 가져감.
        }

        public void UnLoadReference(LifeCycleType lifeCycleType)
        {
            this.ModuleLifeCycleManager.UnLoadModules(lifeCycleType);
            this.FlowLifeCycleManager.UnLoadFlows(lifeCycleType);
            this.InputRouterManager.UnLoadInputRouter();
        }
        private void Update()
        {
//            this.InputRouterManager.UpdateInput();
        }
    }


}

*//*
namespace GameSystems.Flows.Scene
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

    public interface ISceneConverter
    {
        public void OperateSceneConversion(string nextSceneName);
    }

    public class SceneConverter : ISceneConverter
    {
        private string EmptySceneName = "EmptyScene";
        private string NextSceneName;

        private bool isConverting = false;

        // Scene 변경 요청시, EmptyScene을 한번 거쳐서 진행.
        public void OperateSceneConversion(string nextSceneName)
        {
            // 작업중일 경우 무시.
            if (this.isConverting) return;

            //            UnityEngine.Debug.Log($"current Scene Name : {SceneManager.GetActiveScene().name}");

            this.isConverting = true;
            this.NextSceneName = nextSceneName;
            SceneManager.sceneLoaded += OnSceneLoaded;

            SceneManager.LoadScene(this.EmptySceneName, LoadSceneMode.Single);
        }

        public void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
            //            UnityEngine.Debug.Log($"current Scene Name : {SceneManager.GetActiveScene().name}");

            // Empty Scene에 도착 후, 바로 NextScene 로드.
            if (scene.name.Equals(this.EmptySceneName))
            {
                SceneManager.LoadScene(this.NextSceneName, LoadSceneMode.Single);
            }
            // 목적 Scene에 도착하였을 경우, Scene 변경 중지. 및 관련 값 설정.
            else if (scene.name.Equals(this.NextSceneName))
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                this.NextSceneName = null;
                this.isConverting = false;
                return;
            }
        }
    }
}
*/