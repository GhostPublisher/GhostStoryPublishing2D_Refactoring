using UnityEngine;

using Foundations.Patterns.Singleton;

namespace Foundations.LazyReferenceRegistry
{
    public class GlobalReferenceRegistry : GlobalSingleton<GlobalReferenceRegistry>
    {
        private ILazyReferenceRepository LazyReferenceRepository;

        private void Awake()
        {
            base.Awake();

            this.LazyReferenceRepository = new LazyReferenceRepository(this.gameObject);
        }

        public T GetComponentModule<T>() where T : MonoBehaviour, IReferenceLink
        {
            return this.LazyReferenceRepository.GetOrCreateComponentModule<T>();
        }

        public T GetPlainModule<T>() where T : IReferenceLink, new()
        {
            return this.LazyReferenceRepository.GetOrCreatePlainModule<T>();
        }
    }
}