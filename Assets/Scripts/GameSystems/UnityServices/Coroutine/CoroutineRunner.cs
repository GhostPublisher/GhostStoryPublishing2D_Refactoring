using System.Collections;
using UnityEngine;

namespace GameSystems.UnityServices
{
    public interface ICoroutineRunner : IUnityService
    {
        public YieldInstruction WaitSeconds(float second);
        public Coroutine Run(IEnumerator routine);
        public void Stop(Coroutine coroutine);
    }

    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public YieldInstruction WaitSeconds(float second)
        {
            return new WaitForSeconds(second);
        }

        public Coroutine Run(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void Stop(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }

/*    public interface ICoroutineRunner : IUnityService
    {
        public Coroutine RunForObjectType(CoroutineObjectType coroutineObjectType, CoroutineType coroutineType, IEnumerator routine);
        public void StopForObjectType(CoroutineObjectType coroutineObjectType, CoroutineType coroutineType);
        public void StopAllForObjectType(CoroutineObjectType coroutineObjectType);

        public Coroutine RunForInstanceID(int objectInstanceID, CoroutineType coroutineType, IEnumerator routine);
        public void StopForInstanceID(int objectInstanceID, CoroutineType coroutineType);
        public void StopAllForInstanceID(int objectInstanceID);
    }

    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private Dictionary<CoroutineObjectType, HashSet<CoroutineConfig>> CoroutineConfigContainer_ForObjectType = new();
        private Dictionary<int, HashSet<CoroutineConfig>> CoroutineConfigContainer_ForInstanceID = new();


        public Coroutine RunForObjectType(CoroutineObjectType coroutineObjectType, CoroutineType coroutineType, IEnumerator routine)
        {
            if (!this.CoroutineConfigContainer_ForObjectType.ContainsKey(coroutineObjectType))
            {
                this.CoroutineConfigContainer_ForObjectType.Add(coroutineObjectType, new HashSet<CoroutineConfig>());
            }

            var newCoroutine = StartCoroutine(routine);
            this.CoroutineConfigContainer_ForObjectType[coroutineObjectType].Add(new CoroutineConfig(coroutineType, newCoroutine));

            return newCoroutine;
        }
        public void StopForObjectType(CoroutineObjectType coroutineObjectType, CoroutineType coroutineType)
        {
            if (!this.CoroutineConfigContainer_ForObjectType.TryGetValue(coroutineObjectType, out var coroutineConfigs)) return;

            foreach (var config in coroutineConfigs)
            {
                if (config.CoroutineType == coroutineType)
                {
                    StopCoroutine(config.Coroutine);
                    coroutineConfigs.Remove(config);
                }
            }

            if (coroutineConfigs.Count == 0)
            {
                this.CoroutineConfigContainer_ForObjectType.Remove(coroutineObjectType);
            }
        }
        public void StopAllForObjectType(CoroutineObjectType coroutineObjectType)
        {
            if (!this.CoroutineConfigContainer_ForObjectType.TryGetValue(coroutineObjectType, out var coroutineConfigs)) return;

            foreach (var config in coroutineConfigs)
            {
                StopCoroutine(config.Coroutine);
                coroutineConfigs.Remove(config);
            }

            if (coroutineConfigs.Count == 0)
            {
                this.CoroutineConfigContainer_ForObjectType.Remove(coroutineObjectType);
            }
        }

        public Coroutine RunForInstanceID(int objectInstanceID, CoroutineType coroutineType, IEnumerator routine)
        {
            if (!this.CoroutineConfigContainer_ForInstanceID.ContainsKey(objectInstanceID))
            {
                this.CoroutineConfigContainer_ForInstanceID.Add(objectInstanceID, new HashSet<CoroutineConfig>());
            }

            var newCoroutine = StartCoroutine(routine);
            this.CoroutineConfigContainer_ForInstanceID[objectInstanceID].Add(new CoroutineConfig(coroutineType, newCoroutine));

            return newCoroutine;
        }
        public void StopForInstanceID(int objectInstanceID, CoroutineType coroutineType)
        {
            if (!this.CoroutineConfigContainer_ForInstanceID.TryGetValue(objectInstanceID, out var coroutineConfigs)) return;

            foreach (var config in coroutineConfigs)
            {
                if (config.CoroutineType == coroutineType)
                {
                    StopCoroutine(config.Coroutine);
                    coroutineConfigs.Remove(config);
                }
            }

            if (coroutineConfigs.Count == 0)
            {
                this.CoroutineConfigContainer_ForInstanceID.Remove(objectInstanceID);
            }
        }
        public void StopAllForInstanceID(int objectInstanceID)
        {
            if (!this.CoroutineConfigContainer_ForInstanceID.TryGetValue(objectInstanceID, out var coroutineConfigs)) return;

            foreach (var config in coroutineConfigs)
            {
                StopCoroutine(config.Coroutine);
                coroutineConfigs.Remove(config);
            }

            if (coroutineConfigs.Count == 0)
            {
                this.CoroutineConfigContainer_ForInstanceID.Remove(objectInstanceID);
            }
        }
    }

    public class CoroutineConfig
    {
        public CoroutineType CoroutineType { get; private set; }
        public Coroutine Coroutine { get; private set; }

        public CoroutineConfig(CoroutineType coroutineType, Coroutine coroutine)
        {
            this.CoroutineType = coroutineType;
            this.Coroutine = coroutine;
        }
    }

    public enum CoroutineObjectType
    {

    }

    public enum CoroutineType
    {

    }*/
}