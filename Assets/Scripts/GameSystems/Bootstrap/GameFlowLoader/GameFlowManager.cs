using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public interface IGameFlowManager
    {
        public abstract void LoadGameFlows();
        public abstract void InitialBinds(
            IPlainServiceRepository PlainServiceRepository,
            IUnityServiceRepository UnityServiceRepository,
            IDomainModelRepository DomainModelRepository,
            IViewRepository ViewRepository,
            IHandlerRepository HandlerRepository);
    }

    public abstract class GameFlowManager : IGameFlowManager
    {
        protected IGameFlowRepository GameFlowRepository;

        public GameFlowManager(IGameFlowRepository gameFlowRepository)
        {
            this.GameFlowRepository = gameFlowRepository;
        }

        // 여기서 해당 Scene에 필요한 GameFlow 들을 명시합니다.
        public abstract void LoadGameFlows();

        public abstract void InitialBinds(
            IPlainServiceRepository PlainServiceRepository,
            IUnityServiceRepository UnityServiceRepository,
            IDomainModelRepository DomainModelRepository,
            IViewRepository ViewRepository,
            IHandlerRepository HandlerRepository);
    }
}


