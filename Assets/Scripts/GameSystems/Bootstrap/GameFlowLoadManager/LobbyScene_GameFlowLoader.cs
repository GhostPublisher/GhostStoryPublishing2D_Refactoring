using GameSystems.Repository;

using GameSystems.GameFlows;

namespace GameSystems.BootStrap
{
    public class LobbyScene_GameFlowLoader : GameFlowLoader
    {
        public override void LoadGameFlows(IPlainServiceRepository PlainServiceRepository, IUnityServiceRepository UnityServiceRepository,
            IDomainModelRepository DomainModelRepository, IViewRepository ViewRepository, IHandlerRepository HandlerRepository, IGameFlowRepository GameFlowRepository)
        {
            // SceneConvert GameFlow 등록.
            SceneConvertGameFlow sceneConvertGameFlow = new SceneConvertGameFlow(PlainServiceRepository, UnityServiceRepository);
            GameFlowRepository.RegisterGameFlow<SceneConvertGameFlow>(sceneConvertGameFlow);
        }
    }
}