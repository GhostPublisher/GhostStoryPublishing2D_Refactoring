namespace GameSystems.Modules.Input
{
    public interface IInputRouterTransitions
    {
        public InputRouterType CurrentInputRouterType { get; }
        public bool TryTransitInputRouter(InputRouterType inputRouterType, out IInputRouter inputRouter);
    }

    public class InputRouterTransitions : IInputRouterTransitions
    {
        private InputRouterType currentInputRouterType;

        public InputRouterType CurrentInputRouterType { get => currentInputRouterType; }
        public bool TryTransitInputRouter(InputRouterType inputRouterType, out IInputRouter inputRouter)
        {
            inputRouter = null;

            switch (inputRouterType)
            {
                case InputRouterType.LobbyScene:
                    inputRouter = new Lobby_InputRouterController();
                    break;
                case InputRouterType.BattleScene:
                    inputRouter = new Battle_InputRouterController();
                    break;
                default:
                    break;
            }

            if (inputRouter == null) return false;
            else                     return true;
        }
    }

    public enum InputRouterType
    {
        None,
        LobbyScene,
        BattleScene
    }
}