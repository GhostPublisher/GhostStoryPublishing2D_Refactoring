using System.Collections.Generic;
using UnityEngine;

using GameSystems.Entities;

namespace GameSystems.BootStrap
{
    [System.Serializable]
    public class SceneEntityRepository
    {
        [SerializeField] GameObject sceneEntityRepositoryGameObject;

        public IEnumerable<IEntity> GatherAll_IEnumerable()
        {
            foreach(var entity in this.sceneEntityRepositoryGameObject.GetComponents<IEntity>())
            {
                UnityEngine.Debug.Log($"{entity.EntityType} IEntity 반환");

                yield return entity;
            }
        }
    }
}