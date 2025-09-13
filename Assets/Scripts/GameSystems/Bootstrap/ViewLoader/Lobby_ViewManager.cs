using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public class Lobby_ViewManager : ViewLoader
    {
        public Lobby_ViewManager(IViewRepository viewRepository) : base(viewRepository) { }

        public override void LoadView()
        {

        }
        public override void InitialBinds(IGameFlowRepository GameFlowRepository)
        {

        }
    }
}