
using Foundations.LazyReferenceRegistry;

namespace GameSystems.Modules.Inputs
{
    public class Battle_InputRouter : IInputRouter, IReferenceLink
    {
        // Battle Scene에서 사용하는 모든 Input Controller
        private IInputController Battle_GameSystemInputController;

        private BattleSceneInputState currentInputState;
        public Battle_InputRouter()
        {
            this.Battle_GameSystemInputController = new Battle_GameSystemInputController();
        }

        public BattleSceneInputState CurrentInputState { get => currentInputState; set => currentInputState = value; }


        // 현재 상태에 따라 해다 InputController 활성 비활성.
        public void UpdateInputController()
        {
            switch (this.currentInputState)
            {
                case BattleSceneInputState.GamePlay:
                    this.Battle_GameSystemInputController.ActivateUnityEventFlow();
                    break;
                default:
                    break;
            }
        }
    }

    public enum BattleSceneInputState
    {
        GamePlay,
    }
}