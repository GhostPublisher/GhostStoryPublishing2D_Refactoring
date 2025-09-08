using System;
using System.Collections.Generic;

using GameSystems.Domain.Models;

namespace GameSystems.Repository
{
    public interface IDomainModelRepository
    {
        public bool TryGetDomainModel<T>(out T domainModel) where T : IDomainModel;
        public void RegisterDomainModel<T>(IDomainModel domainModel) where T : IDomainModel;
        public void RemoveDomainModel<T>() where T : IDomainModel;
        public void RemoveAllDomainModel();
    }

    public class DomainModelRepository : IDomainModelRepository
    {
        private Dictionary<Type, IDomainModel> DomainModels;

        public DomainModelRepository()
        {
            this.DomainModels = new();
        }

        public bool TryGetDomainModel<T>(out T domainModel) where T : IDomainModel
        {
            domainModel = default;
            if (this.DomainModels == null) return false;

            Type key = typeof(T);
            if (!this.DomainModels.TryGetValue(key, out var model)) return false;

            domainModel = (T)model;
            return true;
        }

        public void RegisterDomainModel<T>(IDomainModel domainModel) where T : IDomainModel
        {
            Type key = typeof(T);

            if (this.DomainModels.ContainsKey(key))
                UnityEngine.Debug.Log($"이미 포함하고 있는 DomainModel 입니다. ( 등록 무시 )");

            this.DomainModels.Add(key, domainModel);
        }

        public void RemoveDomainModel<T>() where T : IDomainModel
        {
            Type key = typeof(T);

            if (!this.DomainModels.ContainsKey(key))
                UnityEngine.Debug.Log($"포함되지 않은 DomainModel 입니다. ( 제거 무시 )");

            this.DomainModels.Remove(key);
        }
        public void RemoveAllDomainModel()
        {
            foreach (var model in this.DomainModels)
            {
                this.DomainModels.Remove(model.Key);
            }
        }
    }
}


