using GameSystems.PlainServices;
using GameSystems.UnityServices;

using GameSystems.Repository;

using GameSystems.GameFlows;

namespace GameSystems.BootStrap
{
    public class LobbyScene_GameFlowManager : GameFlowManager
    {
        public LobbyScene_GameFlowManager(IGameFlowRepository gameFlowRepository) : base(gameFlowRepository) { }

        public override void LoadGameFlows()
        {
            this.GameFlowRepository.RegisterGameFlow<Lobby_InitialGameFlow>(new Lobby_InitialGameFlow());
            this.GameFlowRepository.RegisterGameFlow<LobbyToBattle_SceneConvertGameFlow>(new LobbyToBattle_SceneConvertGameFlow());
        }

        public override void InitialBinds(IPlainServiceRepository PlainServiceRepository, IUnityServiceRepository UnityServiceRepository,
            IDomainModelRepository DomainModelRepository, IViewRepository ViewRepository, IEntityRepository EntityRepository)
        {
            // SceneConvert GameFlow 등록.
            // 해당 방식이 좋을 것 같아 보이지만, GameFlow가 변경될 가능성이 있을 때는 Repository를 넘긴 후 나중에 위의 방식으로 변경하자.
            /*            if (this.GameFlowRepository.TryGetGameFlow<LobbyToBattle_SceneConvertGameFlow>(out var flow)
                            && PlainServiceRepository.TryGetPlainService<ScenePayloadService>(out var scenePayloadService)
                            && UnityServiceRepository.TryGetUnityService<SceneService>(out var sceneService))
                        {
                            flow.InitialBinds(scenePayloadService, sceneService);
                        }*/

            // GameFlow가 변경될 가능성이 있을 때는 Repository를 넘긴 후 나중에 위의 방식으로 변경하자.
            if (this.GameFlowRepository.TryGetGameFlow<Lobby_InitialGameFlow>(out var lobby_InitialGameFlow))
            {
                lobby_InitialGameFlow.InitialBinds(UnityServiceRepository, EntityRepository);
            }

            if (this.GameFlowRepository.TryGetGameFlow<LobbyToBattle_SceneConvertGameFlow>(out var lobbyToBattle_SceneConvertGameFlow))
            {
                lobbyToBattle_SceneConvertGameFlow.InitialBinds(PlainServiceRepository, UnityServiceRepository, EntityRepository);
            }

        }

    }
}