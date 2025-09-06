using System;
using System.Collections.Generic;


namespace GameSystems.Repository
{
    public interface IViewRepository
    {
        public bool TryGetView(Type key, out IView view);
        public void RegisterView(Type key, IView view);
        public void RemoveView(Type key);
        public void RemoveAllView();
    }
    public interface IView { }

    public class ViewRepository : IViewRepository
    {
        private Dictionary<Type, IView> Views;

        public ViewRepository()
        {
            this.Views = new();
        }

        public bool TryGetView(Type key, out IView view)
        {
            view = null;
            if (this.Views == null) return false;

            return this.Views.TryGetValue(key, out view);
        }

        public void RegisterView(Type key, IView view)
        {
            if (this.Views.ContainsKey(key))
                UnityEngine.Debug.Log($"이미 포함하고 있는 View 입니다. ( 등록 무시 )");

            this.Views.Add(key, view);
        }

        public void RemoveView(Type key)
        {
            if (!this.Views.ContainsKey(key))
                UnityEngine.Debug.Log($"포함되지 않은 View 입니다. ( 제거 무시 )");

            this.Views.Remove(key);
        }
        public void RemoveAllView()
        {
            foreach (var view in this.Views)
            {
                this.Views.Remove(view.Key);
            }
        }
    }
}


