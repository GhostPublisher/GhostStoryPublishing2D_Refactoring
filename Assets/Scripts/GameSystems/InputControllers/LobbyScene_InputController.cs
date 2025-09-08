namespace GameSystems.InputController
{
    using Domain.Models;

    public class LobbyScene_InputController : InputController
    {
        private void Update()
        {
            switch (this.InputStateModel.CurrentInputState)
            {
                case InputState.GamePlay:
                    break;
                default:
                    break;
            }
        }
    }
}