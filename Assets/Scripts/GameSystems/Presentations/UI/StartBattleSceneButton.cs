using UnityEngine;

using TMPro;

using GameSystems.Orchestrations.SceneConversionFlow;

namespace GameSystems.Presentations.UI
{
    public class StartBattleSceneButton : MonoBehaviour
    {
        [SerializeField] private TMP_InputField stageInputField;

        private SceneConversionFlow SceneConversionFlow;

        private void Awake()
        {
            this.SceneConversionFlow = new SceneConversionFlow();
        }

        public void OnClicked()
        {
            this.SceneConversionFlow.ConvertBattleScene(stageInputField.text, "BattleScene");
        }
    }
}