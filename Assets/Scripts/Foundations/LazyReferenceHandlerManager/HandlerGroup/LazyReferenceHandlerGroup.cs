using System;
using System.Collections.Generic;

namespace Foundations.ReferencesHandler
{
    public class LazyReferenceHandlerGroup<HandlerType> where HandlerType : class
    {
        private Dictionary<Type, HandlerType> handlerContainer = new();

        public LazyReferenceHandlerGroup() { }

        public T GetOrCreate<T>() where T : HandlerType, new()
        {
            Type key = typeof(T);

            if (!this.handlerContainer.TryGetValue(key, out var value))
            {
                value = new T();
                this.handlerContainer[key] = value;
            }

            return (T)value;
        }
    }

    public interface IStaticReferenceHandler { }
    public interface IDynamicReferenceHandler { }
    public interface IUtilityReferenceHandler { }
}