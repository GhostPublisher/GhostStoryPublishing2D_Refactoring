using System;
using System.Collections.Generic;

using GameSystems.Entities;

namespace GameSystems.Repository
{
    public interface IEntityRepository
    {
        public bool TryGetEntity<T>(out T returnEntity) where T : class, IEntity;
        public void RegisterEntity<T>(IEntity entity) where T : class, IEntity;
        public void RegisterEntity(Type key, IEntity entity);
        public void RemoveEntity<T>() where T : class, IEntity;
        public void RemoveAll();
    }

    public class EntityRepository : IEntityRepository
    {
        private Dictionary<Type, IEntity> Entities;

        public EntityRepository()
        {
            this.Entities = new();
        }

        public bool TryGetEntity<T>(out T returnEntity) where T : class, IEntity
        {
            returnEntity = null;

            Type key = typeof(T);
            if (!this.Entities.TryGetValue(key, out var entity)) return false;

            returnEntity = (T)entity;
            return true;
        }
        public void RegisterEntity<T>(IEntity entity) where T : class, IEntity
        {
            Type key = typeof(T);
            if (this.Entities.ContainsKey(key))
            {
                UnityEngine.Debug.Log($"{key.Name} Entity는 이미 포함되어 있습니다. (등록 요청 무시)");
                return;
            }

            this.Entities.Add(key, entity);
        }
        public void RegisterEntity(Type key, IEntity entity)
        {
            if (this.Entities.ContainsKey(key))
            {
                UnityEngine.Debug.Log($"{key.Name} Entity는 이미 포함되어 있습니다. (등록 요청 무시)");
                return;
            }

            this.Entities.Add(key, entity);
        }
        public void RemoveEntity<T>() where T : class, IEntity
        {
            Type key = typeof(T);
            if (!this.Entities.ContainsKey(key))
            {
                UnityEngine.Debug.Log($"{key.Name} Entity는 포함되어 있지 않습니다. (삭제 요청 수행 불가)");
                return;
            }

            this.Entities.Remove(key);
        }
        public void RemoveAll()
        {
            this.Entities.Clear();
        }
    }

    public interface IEntityGroupRepository
    {
        public bool TryGetEntityGroup(Type key, out HashSet<IEntity> returnEntityGroup);
        public bool TryGetEntity(Type GroupKey, string key, out IEntity returnEntity);
    }

    public class EntityGroupRepository : IEntityGroupRepository
    {
        private Dictionary<Type, HashSet<IEntity>> EntityGroups;

        public EntityGroupRepository()
        {
            this.EntityGroups = new();
        }

        public bool TryGetEntityGroup(Type key, out HashSet<IEntity> returnEntityGroup)
        {
            returnEntityGroup = default;

            if (!this.EntityGroups.TryGetValue(key, out var tempEntityGroup) || tempEntityGroup == null || tempEntityGroup.Count == 0) return false;

            returnEntityGroup = tempEntityGroup;
            return true;
        }
        public bool TryGetEntity(Type GroupKey, string key, out IEntity returnEntity)
        {
            returnEntity = default;

            if (!this.EntityGroups.TryGetValue(GroupKey, out var tempEntityGroup) || tempEntityGroup == null || tempEntityGroup.Count == 0) return false;

            foreach (var tempEntity in tempEntityGroup)
            {
                if (tempEntity.EntityID == key)
                {
                    returnEntity = tempEntity;
                    return true;
                }
            }

            return false;
        }
    }
}