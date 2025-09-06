/*using System;
using System.Collections.Generic;
using GameSystems.Flows;

namespace GameSystems.Datas
{
    public interface IFlowReferencHandler
    {
        public void RegisterFlowReference<T>(IFlow flow);
        public void RemoveFlowReference<T>();
        public void RemoveAllFlowReference();
    }

    public class FlowReferencHandler : IFlowReferencHandler
    {
        private Dictionary<Type, IFlow> Flows;

        public FlowReferencHandler()
        {
            this.Flows = new();
        }
        public void RegisterFlowReference<T>(IFlow flow)
        {
            Type type = typeof(T);

            if (this.Flows.ContainsKey(type))
                UnityEngine.Debug.Log($"이미 포함하고 있는 Flow 입니다. ( 등록 무시 )");

            this.Flows.Add(type, flow);
        }

        public void RemoveFlowReference<T>()
        {
            Type type = typeof(T);

            if (!this.Flows.ContainsKey(type))
                UnityEngine.Debug.Log($"포함되지 않은 Flow 입니다. ( 제거 무시 )");

            this.Flows.Remove(type);
        }

        public void RemoveAllFlowReference()
        {
            foreach(var data in this.Flows)
            {
                this.Flows.Remove(data.Key);
            }
        }
    }
}
*/