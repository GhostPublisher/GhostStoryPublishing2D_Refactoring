using System;
using System.Collections.Generic;

using GameSystems.GameFlows;

namespace GameSystems.Repository
{
    public interface IGameFlowRepository
    {
        public bool TryGetGameFlow<T>(out T gameFlow) where T : IGameFlow;
        public void RegisterGameFlow<T>(T gameFlow) where T : IGameFlow;
        public void RemoveGameFlow<T>() where T : IGameFlow;
        public void RemoveAllGameFlow();
    }

    // GameFlow 참조를 관리하는 저장소.
    public class GameFlowRepository : IGameFlowRepository
    {
        private Dictionary<Type, IGameFlow> GameFlows;

        public GameFlowRepository()
        {
            this.GameFlows = new();
        }

        public bool TryGetGameFlow<T>(out T gameFlow) where T : IGameFlow
        {
            gameFlow = default;

            Type key = typeof(T);

            if (this.GameFlows == null || !this.GameFlows.TryGetValue(key, out var flow))
            {
                UnityEngine.Debug.Log($"포함되지 않은 GameFlow 입니다.");
                return false;
            }

            gameFlow = (T)flow;
            return true;
        }

        public void RegisterGameFlow<T>(T gameFlow) where T : IGameFlow
        {
            Type key = typeof(T);

            if (this.GameFlows == null || this.GameFlows.ContainsKey(key))
            {
                UnityEngine.Debug.Log($"이미 포함하고 있는 GameFlow 입니다. ( 등록 무시 )");
                return;
            }

            this.GameFlows.Add(key, gameFlow);
        }

        public void RemoveGameFlow<T>() where T : IGameFlow
        {
            Type key = typeof(T);

            if (this.GameFlows == null || !this.GameFlows.ContainsKey(key))
            {
                UnityEngine.Debug.Log($"포함되지 않은 GameFlow 입니다. ( 제거 무시 )");
                return;
            }

            this.GameFlows.Remove(key);
        }

        public void RemoveAllGameFlow()
        {
            foreach (var flow in this.GameFlows)
            {
                this.GameFlows.Remove(flow.Key);
            }
        }
    }
}


