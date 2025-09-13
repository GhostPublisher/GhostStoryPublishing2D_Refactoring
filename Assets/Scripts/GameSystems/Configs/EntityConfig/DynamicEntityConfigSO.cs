using System.Collections.Generic;
using UnityEngine;

namespace GameSystems.Entities
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Prefab/UIEntity/DynamicEntityConfigSO", fileName = "DynamicEntityConfigSO")]
    public class DynamicEntityConfigSO : ScriptableObject
    {
        [SerializeField] List<EntityConfigData> EntityConfigDatas;

        public bool TryGetEntityConfigData(EntityTypeKey key, out GameObject UIGameObject_)
        {
            UIGameObject_ = null;
            if (this.EntityConfigDatas == null)
            {
                UnityEngine.Debug.Log($"DynamicEntityConfigSO에 {key.ToString()} 객체가 없습니다.");
                return false;
            }

            foreach (var data in this.EntityConfigDatas)
            {
                if (data.EntityTypeKey == key)
                {
                    UIGameObject_ = data.GameObject;
                    return true;
                }
            }

            return false;
        }
    }

    [System.Serializable]
    public class EntityConfigData
    {
        [SerializeField] private EntityTypeKey entityTypeKey;

        [SerializeField] private GameObject gameObject;

        public EntityTypeKey EntityTypeKey { get => entityTypeKey; }
        public GameObject GameObject { get => gameObject; }
    }

    public enum EntityTypeKey
    {
        LobbyScenePanelUIEntity,
        MessageUIEntity
    }
}