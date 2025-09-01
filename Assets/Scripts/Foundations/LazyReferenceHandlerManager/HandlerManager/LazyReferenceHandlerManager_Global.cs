using Foundations.Patterns.Singleton;

using UnityEngine;

namespace Foundations.ReferencesHandler
{
    public class LazyReferenceHandlerManager_Global : GlobalSingleton<LazyReferenceHandlerManager_Global>
    {
        private LazyReferenceHandlerGroup<IStaticReferenceHandler> StaticLazyReferenceHandlerGroup;
        private LazyReferenceHandlerGroup<IDynamicReferenceHandler> DynamicLazyReferenceHandlerGroup;
        private LazyReferenceHandlerGroup<IUtilityReferenceHandler> UtilityLazyReferenceHandlerGroup;
        private LazyConponentHandlerGroup<IUtilityReferenceHandler> UtilityLazyConponentHandlerGroup;

        protected override void Awake()
        {
            // GlobalSingleton 먼저 Awake
            base.Awake();

            // LazyReferenceHandlerManager_Global 초기화
            this.StaticLazyReferenceHandlerGroup = new();
            this.DynamicLazyReferenceHandlerGroup = new();
            this.UtilityLazyReferenceHandlerGroup = new();
            this.UtilityLazyConponentHandlerGroup = new(true);
        }


        public T GetStaticHandler<T>() where T : IStaticReferenceHandler, new()
        {
            return StaticLazyReferenceHandlerGroup.GetOrCreate<T>();
        }

        public T GetDynamicHandler<T>() where T : IDynamicReferenceHandler, new()
        {
            return DynamicLazyReferenceHandlerGroup.GetOrCreate<T>();
        }

        public T GetUtilityHandler<T>() where T : IUtilityReferenceHandler, new()
        {
            return UtilityLazyReferenceHandlerGroup.GetOrCreate<T>();
        }

        public T GetUtilityComponentHandler<T>() where T : MonoBehaviour, IUtilityReferenceHandler
        {
            return UtilityLazyConponentHandlerGroup.GetOrCreateComponent<T>();
        }
    }
}