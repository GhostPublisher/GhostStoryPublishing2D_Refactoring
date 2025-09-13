using GameSystems.PlainServices;
using GameSystems.UnityServices;

using GameSystems.Repository;

using GameSystems.GameFlows;

namespace GameSystems.BootStrap
{
    public class BattleScene_GameFlowManager : GameFlowManager
    {
        public BattleScene_GameFlowManager(IGameFlowRepository gameFlowRepository) : base(gameFlowRepository) { }

        public override void LoadGameFlows()
        {
            this.GameFlowRepository.RegisterGameFlow<LobbyToBattle_SceneConvertGameFlow>(new LobbyToBattle_SceneConvertGameFlow());
        }

        public override void InitialBinds(IPlainServiceRepository PlainServiceRepository, IUnityServiceRepository UnityServiceRepository,
            IDomainModelRepository DomainModelRepository, IViewRepository ViewRepository, IEntityRepository HandlerRepository)
        {

        }
    }
}


