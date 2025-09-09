using GameSystems.Repository;

using GameSystems.GameFlows;

namespace GameSystems.BootStrap
{
    public class LobbyScene_GameFlowManager : GameFlowManager
    {
        public LobbyScene_GameFlowManager(IGameFlowRepository gameFlowRepository) : base(gameFlowRepository) { }

        public override void LoadGameFlows()
        {
            this.GameFlowRepository.RegisterGameFlow<SceneConvertGameFlow>(new SceneConvertGameFlow());
        }

        public override void InitialBinds(IPlainServiceRepository PlainServiceRepository, IUnityServiceRepository UnityServiceRepository,
            IDomainModelRepository DomainModelRepository, IViewRepository ViewRepository, IHandlerRepository HandlerRepository)
        {
            // SceneConvert GameFlow 등록.
            if(this.GameFlowRepository.TryGetGameFlow<SceneConvertGameFlow>(out var flow))
                flow.InitialBinds(PlainServiceRepository, UnityServiceRepository);


        }

    }
}