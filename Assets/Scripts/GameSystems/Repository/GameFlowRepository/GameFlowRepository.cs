using System;
using System.Collections.Generic;

namespace GameSystems.Repository
{
    public interface IGameFlowRepository
    {
        public void RegisterGameFlow(Type type, IGameFlow gameFlow);
        public void RemoveGameFlow(Type type);
        public void RemoveAllGameFlow();
    }

    public interface IGameFlow { }

    // GameFlow 참조를 관리하는 저장소.
    public class GameFlowRepository : IGameFlowRepository
    {
        private Dictionary<Type, IGameFlow> GameFlows;

        public GameFlowRepository()
        {
            this.GameFlows = new();
        }

        public void RegisterGameFlow(Type type, IGameFlow gameFlow)
        {
            if(this.GameFlows.ContainsKey(type))
                UnityEngine.Debug.Log($"이미 포함하고 있는 GameFlow 입니다. ( 등록 무시 )");

            this.GameFlows.Add(type, gameFlow);
        }

        public void RemoveGameFlow(Type type)
        {
            if (!this.GameFlows.ContainsKey(type))
                UnityEngine.Debug.Log($"포함되지 않은 GameFlow 입니다. ( 제거 무시 )");

            this.GameFlows.Remove(type);
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


