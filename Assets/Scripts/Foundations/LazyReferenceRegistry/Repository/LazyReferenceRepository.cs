using System;
using System.Collections.Generic;
using UnityEngine;

namespace Foundations.LazyReferenceRegistry
{
    public interface IReferenceLink { }

    public interface ILazyReferenceRepository
    {
        public T GetOrCreateComponentModule<T>() where T : MonoBehaviour, IReferenceLink;
        public T GetOrCreatePlainModule<T>() where T : IReferenceLink, new();
    }

    public class LazyReferenceRepository : ILazyReferenceRepository
    {
        private Dictionary<Type, IReferenceLink> referenceLinks;
        private GameObject RootGameObject;

        public LazyReferenceRepository(GameObject gameObject)
        {
            this.referenceLinks = new();
            this.RootGameObject = gameObject;
        }

        public T GetOrCreateComponentModule<T>() where T : MonoBehaviour, IReferenceLink
        {
            Type key = typeof(T);

            if (!referenceLinks.TryGetValue(key, out var value))
            {
                value = this.RootGameObject.GetComponent<T>();

                if (value == null)
                    value = this.RootGameObject.AddComponent<T>();

                referenceLinks.Add(key, value);
            }

            return (T)value;
        }

        public T GetOrCreatePlainModule<T>() where T : IReferenceLink, new()
        {
            Type key = typeof(T);

            if (!this.referenceLinks.TryGetValue(key, out var value))
            {
                value = new T();
                this.referenceLinks[key] = value;
            }

            return (T)value;
        }
    }
}