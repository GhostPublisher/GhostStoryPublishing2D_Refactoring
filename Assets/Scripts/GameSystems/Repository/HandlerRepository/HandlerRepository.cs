using System;
using System.Collections.Generic;


namespace GameSystems.Repository
{
    public interface IHandlerRepository
    {
        public bool TryGetHandler(Type key, out IHandler handler);
        public void RegisterHandler(Type type, IHandler handler);
        public void RemoveHandler(Type type);
        public void RemoveAllHandler();
    }

    // Model과 View를 Bind해서 관리.
    public class HandlerRepository : IHandlerRepository
    {
        private Dictionary<Type, IHandler> Handlers;

        public HandlerRepository()
        {
            this.Handlers = new();
        }


        public bool TryGetHandler(Type key, out IHandler handler)
        {
            handler = null;
            if (this.Handlers == null) return false;

            return this.Handlers.TryGetValue(key, out handler);
        }

        public void RegisterHandler(Type type, IHandler handler)
        {
            if (this.Handlers.ContainsKey(type))
                UnityEngine.Debug.Log($"이미 포함하고 있는 Handler 입니다. ( 등록 무시 )");

            this.Handlers.Add(type, handler);
        }

        public void RemoveHandler(Type type)
        {
            if (!this.Handlers.ContainsKey(type))
                UnityEngine.Debug.Log($"포함되지 않은 Handler 입니다. ( 제거 무시 )");

            this.Handlers.Remove(type);
        }
        public void RemoveAllHandler()
        {
            foreach (var handler in this.Handlers)
            {
                this.Handlers.Remove(handler.Key);
            }
        }
    }

    public interface IHandler { }
    public interface IViewShell { }
}


