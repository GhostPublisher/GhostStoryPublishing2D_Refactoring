using GameSystems.Domain.Models;
namespace GameSystems.InputController
{
    public class BattleScene_InputController : InputController
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