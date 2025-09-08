namespace GameSystems.Domain.Models
{
    public class InputStateModel : IDomainModel
    {
        private InputState currentInputState;

        public InputState CurrentInputState { get => currentInputState; set => currentInputState = value; }
    }

    public enum InputState
    {
        GamePlay, Dialog
    }
}
