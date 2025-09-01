using System;
using System.Collections.Generic;

using UnityEngine;

namespace Foundations.ReferencesHandler
{
    public class LazyConponentHandlerGroup<HandlerType> where HandlerType : class
    {
        private Dictionary<Type, HandlerType> handlerContainer = new();

        private GameObject rootGameObject;

        // isGlobalScope true : 게임 전체에서 사용, false : 씬에서만 사용
        public LazyConponentHandlerGroup(bool isGlobalScope = false)
        {
            this.handlerContainer = new();

            this.InitialSetRootGameObject(isGlobalScope);
        }

        private void InitialSetRootGameObject(bool isGlobalScope)
        {
            if (rootGameObject != null) return;

            rootGameObject = GameObject.Find("ComponentHandlers");
            if (rootGameObject == null)
            {
                rootGameObject = new GameObject("ComponentHandlers");
                if (isGlobalScope)
                    UnityEngine.Object.DontDestroyOnLoad(rootGameObject);
            }
        }

        public T GetOrCreateComponent<T>() where T : MonoBehaviour, HandlerType
        {
            Type key = typeof(T);

            if (!handlerContainer.TryGetValue(key, out var value))
            {
                value = rootGameObject.GetComponent<T>();
                if (value == null)
                    value = rootGameObject.AddComponent<T>();

                handlerContainer[key] = value;
            }

            return (T)value;
        }
    }
}