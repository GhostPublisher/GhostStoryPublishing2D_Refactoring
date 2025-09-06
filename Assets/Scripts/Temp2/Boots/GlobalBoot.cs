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
    // ���� ���� ��, ���� ���� ȣ��Ǿ�� �ϴ� ��ü.
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
            // �� Module ���� �ε� : ������
            this.ModuleLifeCycleManager.LoadMoudles(lifeCycleType);

            // �� Flow ���� : Module�� �ʼ��� ������.
            // MonoBehaviour�� ����ϴ� Flow�� ��쿡��, �ش� Flow�� ����� MonoBehaviour�� ��ӹ޴� SubFlow�� ���� �ش� Flow�� ����� ���� ���ӽ�Ű�� ������ ����.
            this.FlowLifeCycleManager.LoadFlows(lifeCycleType, this.ModuleLifeCycleManager.ModuleReferenceHandler);

            // �� Input ���� : Flow�� �ʼ��� ������.
//            this.InputRouterManager.LoadInputRouter(lifeCycleType);

            // �� View ���� : ���(��ư�� ����)�� ���� Flow�� ������.
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

    public interface ISceneConverter
    {
        public void OperateSceneConversion(string nextSceneName);
    }

    public class SceneConverter : ISceneConverter
    {
        private string EmptySceneName = "EmptyScene";
        private string NextSceneName;

        private bool isConverting = false;

        // Scene ���� ��û��, EmptyScene�� �ѹ� ���ļ� ����.
        public void OperateSceneConversion(string nextSceneName)
        {
            // �۾����� ��� ����.
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

            // Empty Scene�� ���� ��, �ٷ� NextScene �ε�.
            if (scene.name.Equals(this.EmptySceneName))
            {
                SceneManager.LoadScene(this.NextSceneName, LoadSceneMode.Single);
            }
            // ���� Scene�� �����Ͽ��� ���, Scene ���� ����. �� ���� �� ����.
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