using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.Configs
{
    public class SceneUIConfig : MonoBehaviour
    {
        [SerializeField] List<UIConfigData> SceneUIConfigDatas;

        public bool TryGetUIConfigData(UIKey UIKey_, out GameObject UIGameObject_)
        {
            UIGameObject_ = null;
            if (this.SceneUIConfigDatas == null) return false;

            foreach (var data in this.SceneUIConfigDatas)
            {
                if(data.UIKey == UIKey_)
                {
                    UIGameObject_ = data.UIGameObject;
                    return true;
                }
            }

            return false;
        }
    }

    [System.Serializable]
    [CreateAssetMenu(menuName = "Prefab/UI/DynamicUIConfigSO", fileName = "DynamicUIConfigSO")]
    public class DynamicUIConfigSO : ScriptableObject
    {
        [SerializeField] List<UIConfigData> DynamicUIConfigDatas;

        public bool TryGetUIConfigData(UIKey UIKey_, out GameObject UIGameObject_)
        {
            UIGameObject_ = null;
            if (this.DynamicUIConfigDatas == null) return false;

            foreach (var data in this.DynamicUIConfigDatas)
            {
                if (data.UIKey == UIKey_)
                {
                    UIGameObject_ = data.UIGameObject;
                    return true;
                }
            }

            return false;
        }
    }

    [System.Serializable]
    public class UIConfigData
    {
        // Dynaimc SO 등록.
        // 배치된 UI 목록 등록.
        [SerializeField] private UIKey UIKey_;
        [SerializeField] private GameObject UIGameObject_;

        public UIKey UIKey { get => UIKey_; }
        public GameObject UIGameObject { get => UIGameObject_; }
    }

    public enum UIKey
    {
        // Lobby Scene UI
        LobbyToBattleConvertUI,
        // Lobby Dynaic UI
        LobbyMessageUI,
    }
}