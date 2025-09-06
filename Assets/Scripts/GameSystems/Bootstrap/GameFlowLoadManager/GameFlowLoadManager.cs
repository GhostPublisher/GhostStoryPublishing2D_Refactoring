using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public interface IGameFlowLoadManager
    {
        public IGameFlowRepository GameFlowRepository { get; }
        public void LoadGameFlows(IHandlerRepository HandlerRepository, IUnityServiceRepository UnityServiceRepository);
    }

    public abstract class GameFlowLoadManager : IGameFlowLoadManager
    {
        private IGameFlowRepository  gameFlowRepository;

        public GameFlowLoadManager()
        {
            this.gameFlowRepository = new GameFlowRepository();
        }

        public IGameFlowRepository GameFlowRepository { get => gameFlowRepository; }

        // 여기서 해당 Scene에 필요한 GameFlow 들을 명시합니다.
        public abstract void LoadGameFlows(IHandlerRepository HandlerRepository, IUnityServiceRepository UnityServiceRepository);
    }
}


