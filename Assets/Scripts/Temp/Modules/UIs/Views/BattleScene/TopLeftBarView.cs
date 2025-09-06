/*using UnityEngine;

using Foundations.LazyReferenceRegistry;
using GameSystems.Modules.GameSystem;

namespace GameSystems.Modules.GameSystem
{
    public class TopLeftBarView : MonoBehaviour
    {
        private IGamePauseController GamePauseController;
        private void Awake()
        {
            this.GamePauseController = LocalReferenceRegistry.Instance.GetPlainModule<GamePauseController>();
        }

        public void OnClicked()
        {
            this.GamePauseController.PauseFlow();
        }
    }
}*/