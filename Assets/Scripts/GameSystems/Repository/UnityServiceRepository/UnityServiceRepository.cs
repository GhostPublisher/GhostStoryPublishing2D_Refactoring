using System;
using System.Collections.Generic;

using Foundations.Patterns.Singleton;

using GameSystems.UnityServices;


namespace GameSystems.Repository
{
    public interface IUnityServiceRepository
    {
        public bool TryGetUnityService<T>(out T unityService) where T : IUnityService;
        public void RegisterUnityService<T>(T unityService) where T : IUnityService;
        public void RemoveUnityService<T>() where T : IUnityService;
        public void RemoveAllUnityService();
        public bool IsInitialed { get; set; }
    }

    // 게임 기능 중, Unity Engine에 의존하여 작동하는 기능들의 저장소.
    // Singleton을 통하여, 각 SceneBoot에서 접근합니다.
    public class UnityServiceRepository : Singleton<UnityServiceRepository>, IUnityServiceRepository
    {
        private Dictionary<Type, IUnityService> UnityServiceContainer;

        private bool isInitialed;

        public UnityServiceRepository()
        {
            this.UnityServiceContainer = new();
            this.isInitialed = false;
        }

        public bool IsInitialed { get => isInitialed; set => isInitialed = value; }

        public bool TryGetUnityService<T>(out T unityService) where T : IUnityService
        {
            unityService = default;
            if (this.UnityServiceContainer == null) return false;

            Type key = typeof(T);

            if (!this.UnityServiceContainer.TryGetValue(key, out var service)) return false;

            unityService = (T)service;
            return true;
        }

        public void RegisterUnityService<T>(T unityService) where T : IUnityService
        {
            Type key = typeof(T);

            if (this.UnityServiceContainer.ContainsKey(key))
                UnityEngine.Debug.Log($"이미 포함하고 있는 UnityService 입니다. ( 등록 무시 )");

            this.UnityServiceContainer.Add(key, unityService);
        }

        public void RemoveUnityService<T>() where T : IUnityService
        {
            Type key = typeof(T);

            if (!this.UnityServiceContainer.ContainsKey(key))
                UnityEngine.Debug.Log($"포함되지 않은 UnityService 입니다. ( 제거 무시 )");

            this.UnityServiceContainer.Remove(key);
        }
        public void RemoveAllUnityService()
        {
            foreach (var flow in this.UnityServiceContainer)
            {
                this.UnityServiceContainer.Remove(flow.Key);
            }
        }
    }
}


