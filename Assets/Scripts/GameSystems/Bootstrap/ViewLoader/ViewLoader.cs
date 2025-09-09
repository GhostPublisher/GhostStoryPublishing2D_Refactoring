using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public interface IViewManager 
    {
        // �ʿ��� ��� Load
        public void LoadView();
        // �� ��� ������ ���� Bind
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