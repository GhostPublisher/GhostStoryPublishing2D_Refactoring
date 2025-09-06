/*using System;
using System.Collections.Generic;
using GameSystems.Modules;

namespace GameSystems.Datas
{
    public interface IModuleReferenceHandler
    {
        public void RegisterModuleReference<T>(IModule module);
        public void RemoveModuleReference<T>();
        public void RemoveAllModuleReference();
    }

    public class ModuleReferenceHandler : IModuleReferenceHandler
    {
        private Dictionary<Type, IModule> Modules;

        public ModuleReferenceHandler()
        {
            this.Modules = new();
        }

        public void RegisterModuleReference<T>(IModule module)
        {
            Type type = typeof(T);

            if (this.Modules.ContainsKey(type))
                UnityEngine.Debug.Log($"이미 포함하고 있는 Module 입니다. ( 등록 무시 )");

            this.Modules.Add(type, module);
        }

        public void RemoveModuleReference<T>()
        {
            Type type = typeof(T);

            if (!this.Modules.ContainsKey(type))
                UnityEngine.Debug.Log($"포함되지 않은 Module 입니다. ( 제거 무시 )");

            this.Modules.Remove(type);
        }

        public void RemoveAllModuleReference()
        {
            foreach (var data in this.Modules)
            {
                this.Modules.Remove(data.Key);
            }
        }
    }
}
*/