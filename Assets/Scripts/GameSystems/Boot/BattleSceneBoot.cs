using UnityEngine;

using GameSystems.BootStrap;
using GameSystems.Repository;

using GameSystems.InputController;

namespace GameSystems.Boot
{
    [DefaultExecutionOrder(-90)]  // 숫자가 낮을수록 먼저 실행됨
    public class BattleSceneBoot : MonoBehaviour
    {
        [SerializeField] private SceneEntityRepository SceneEntityRepository;
        [SerializeField] private BattleScene_InputController InputController;

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
            IEntityRepository entityRepository = new EntityRepository();

            // 게임 실제 구현을 위한 흐름이 기록되는 GameFlow Repository
            IGameFlowRepository gameFlowRepository = new GameFlowRepository();

            IDomainModelManager domainModelManager = new BattleScene_DomainModelManager(domainModelRepository);
            IViewManager viewManager = new Lobby_ViewManager(viewRepository);
            IEntityLoaderAndBinder entityLoaderAndBinder = new LobbyScene_EntityLoaderAndBinder(entityRepository);
            IGameFlowManager gameFlowManager = new LobbyScene_GameFlowManager(gameFlowRepository);

        }
    }
}