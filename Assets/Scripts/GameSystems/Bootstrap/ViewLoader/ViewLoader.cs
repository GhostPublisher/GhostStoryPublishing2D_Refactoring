using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public interface IViewManager 
    {
        // 필요한 기능 Load
        public void LoadView();
        // 각 기능 참조를 위한 Bind
        public void InitialBinds(IGameFlowRepository GameFlowRepository);
    }


    public abstract class ViewLoader : IViewManager
    {
        protected IViewRepository ViewRepository;

        public ViewLoader(IViewRepository ViewRepository)
        {
            this.ViewRepository = ViewRepository;
        }

        public abstract void LoadView();
        public abstract void InitialBinds(IGameFlowRepository GameFlowRepository);
    }
}