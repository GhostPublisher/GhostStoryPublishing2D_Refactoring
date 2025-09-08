using System;
using System.Collections.Generic;

using Foundations.Patterns.Singleton;
using GameSystems.PlainServices;


namespace GameSystems.Repository
{
    public interface IPlainServiceRepository
    {
        public bool TryGetPlainService<T>(out T plainService) where T : IPlainService;
        public void RegisterPlainService<T>(T plainService) where T : IPlainService;
        public void RemovePlainService<T>() where T : IPlainService;
        public void RemoveAllPlainService();
        public bool IsInitialed { get; set; }
    }

    public class PlainServiceRepository : Singleton<PlainServiceRepository>, IPlainServiceRepository
    {
        private Dictionary<Type, IPlainService> PlainServiceContainer;

        private bool isInitialed;

        public PlainServiceRepository()
        {
            this.PlainServiceContainer = new();
            this.isInitialed = false;
        }

        public bool IsInitialed { get => isInitialed; set => isInitialed = value; }

        public bool TryGetPlainService<T>(out T plainService) where T : IPlainService
        {
            plainService = default;
            if (this.PlainServiceContainer == null) return false;

            Type key = typeof(T);
            if (!this.PlainServiceContainer.TryGetValue(key, out var service)) return false;

            plainService = (T)service;
            return true;
        }

        public void RegisterPlainService<T>(T plainService) where T : IPlainService
        {
            Type key = typeof(T);
            if (this.PlainServiceContainer.ContainsKey(key))
                UnityEngine.Debug.Log($"이미 포함하고 있는 PlainService 입니다. ( 등록 무시 )");

            this.PlainServiceContainer.Add(key, plainService);
        }

        public void RemovePlainService<T>() where T : IPlainService
        {
            Type key = typeof(T);
            if (!this.PlainServiceContainer.ContainsKey(key))
                UnityEngine.Debug.Log($"포함되지 않은 PlainService 입니다. ( 제거 무시 )");

            this.PlainServiceContainer.Remove(key);
        }
        public void RemoveAllPlainService()
        {
            foreach (var flow in this.PlainServiceContainer)
            {
                this.PlainServiceContainer.Remove(flow.Key);
            }
        }
    }
}


