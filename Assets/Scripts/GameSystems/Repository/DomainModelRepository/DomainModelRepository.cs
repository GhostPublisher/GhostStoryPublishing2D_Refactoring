using System;
using System.Collections.Generic;


namespace GameSystems.Repository
{
    public interface IDomainModelRepository
    {
        public bool TryGetDomainModel(Type key, out IDomainModel domainModel);
        public void RegisterDomainModel(Type key, IDomainModel domainModel);
        public void RemoveDomainModel(Type key);
        public void RemoveAllDomainModel();
    }

    public interface IDomainModel { }

    public class DomainModelRepository : IDomainModelRepository
    {
        private Dictionary<Type, IDomainModel> DomainModels;

        public DomainModelRepository()
        {
            this.DomainModels = new();
        }

        public bool TryGetDomainModel(Type key, out IDomainModel domainModel)
        {
            domainModel = null;
            if (this.DomainModels == null) return false;

            return this.DomainModels.TryGetValue(key, out domainModel);
        }

        public void RegisterDomainModel(Type key, IDomainModel domainModel)
        {
            if (this.DomainModels.ContainsKey(key))
                UnityEngine.Debug.Log($"이미 포함하고 있는 DomainModel 입니다. ( 등록 무시 )");

            this.DomainModels.Add(key, domainModel);
        }

        public void RemoveDomainModel(Type key)
        {
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


