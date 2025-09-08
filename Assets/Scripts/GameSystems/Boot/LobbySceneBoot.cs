using UnityEngine;

using GameSystems.BootStrap;

using GameSystems.Repository;

using GameSystems.InputController;

namespace GameSystems.Boot
{
    [DefaultExecutionOrder(-90)]  // 숫자가 낮을수록 먼저 실행됨
    public class LobbySceneBoot : MonoBehaviour
    {
        [SerializeField] private LobbyScene_InputController InputController;

        private void Awake()
        {
            // 기능 Service Repository
            IPlainServiceRepository PlainServiceRepository = Repository.PlainServiceRepository.Instance;
            IUnityServiceRepository UnityServiceRepository = Repository.UnityServiceRepository.Instance;

            // 객체 Model 및 View Repository
            IDomainModelRepository DomainModelRepository = new DomainModelRepository();
            IViewRepository ViewRepository = new ViewRepository();

            // Model 및 View를 바인딩하여 관리되는 객체를 위한 Handler Repository
            IHandlerRepository HandlerRepository = new HandlerRepository();

            // 게임 실제 구현을 위한 흐름이 기록되는 GameFlow Repository
            IGameFlowRepository GameFlowRepository = new GameFlowRepository();

            // 각 분류 Load 진행.

            // 각 Scene에 필요한 GameFlow 생성.
            IGameFlowLoader GameFlowLoader = new LobbyScene_GameFlowLoader();
            GameFlowLoader.LoadGameFlows(PlainServiceRepository, UnityServiceRepository,
                DomainModelRepository, ViewRepository, HandlerRepository, GameFlowRepository);

            // 각 객체 참조 등록.

            InputController.InitialSetting(PlainServiceRepository, UnityServiceRepository, GameFlowRepository, DomainModelRepository);
        }
    }
}