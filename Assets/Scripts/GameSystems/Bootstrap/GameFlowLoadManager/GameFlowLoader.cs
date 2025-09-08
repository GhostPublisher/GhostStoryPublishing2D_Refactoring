using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public interface IGameFlowLoader
    {
        public void LoadGameFlows(
            IPlainServiceRepository PlainServiceRepository,
            IUnityServiceRepository UnityServiceRepository,
            IDomainModelRepository DomainModelRepository,
            IViewRepository ViewRepository,
            IHandlerRepository HandlerRepository,
            IGameFlowRepository GameFlowRepository);
    }

    public abstract class GameFlowLoader : IGameFlowLoader
    {
        // 여기서 해당 Scene에 필요한 GameFlow 들을 명시합니다.
        public abstract void LoadGameFlows(
            IPlainServiceRepository PlainServiceRepository,
            IUnityServiceRepository UnityServiceRepository,
            IDomainModelRepository DomainModelRepository,
            IViewRepository ViewRepository,
            IHandlerRepository HandlerRepository,
            IGameFlowRepository GameFlowRepository);
    }
}


