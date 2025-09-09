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
            // 1. 각 객체들의 기능 참조가 담길 저장소 생성 및 참조
            // 기능 Service Repository
            IPlainServiceRepository plainServiceRepository = Repository.PlainServiceRepository.Instance;
            IUnityServiceRepository unityServiceRepository = Repository.UnityServiceRepository.Instance;

            // 객체 Model 및 View Repository
            IDomainModelRepository domainModelRepository = new DomainModelRepository();
            IViewRepository viewRepository = new ViewRepository();

            // Model 및 View를 바인딩하여 관리되는 객체를 위한 Handler Repository
            IHandlerRepository handlerRepository = new HandlerRepository();

            // 게임 실제 구현을 위한 흐름이 기록되는 GameFlow Repository
            IGameFlowRepository gameFlowRepository = new GameFlowRepository();

            // 2. 각 객체들의 Load와 Bind를 담당할 Manager 객체 생성.
            IDomainModelManager domainModelManager = new LobbyScene_DomainModelManager(domainModelRepository);
            IViewManager viewManager = new Lobby_ViewManager(viewRepository);
            IGameFlowManager gameFlowManager = new LobbyScene_GameFlowManager(gameFlowRepository);

            // 3-1. 현재 Scene에 필요한 객체 등록 전, 이전 Scene에서 넘어온 값들을 현재 Scene의 Model에 적용.
            domainModelManager.LoadDomainModelsWithPayload(plainServiceRepository);

            // 3-2. 각 Scene에 필요한 객체들 Load 진행.
            domainModelManager.LoadDomainModels();
            viewManager.LoadView();
            gameFlowManager.LoadGameFlows();


            // 4. 각 객체간의 참조 관계 등록.
            viewManager.InitialBinds(gameFlowRepository);
            gameFlowManager.InitialBinds(plainServiceRepository, unityServiceRepository,
                domainModelRepository, viewRepository, handlerRepository);


            InputController.InitialBinds(plainServiceRepository, unityServiceRepository, domainModelRepository, gameFlowRepository);
        }
    }
}