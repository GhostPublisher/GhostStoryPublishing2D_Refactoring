using UnityEngine;

using GameSystems.Repository;
using GameSystems.UnityServices;

namespace GameSystems.BootStrap
{
    public interface IUnityServiceLoader
    {
        public void LoadUnityServices();
    }

    // Unity Engine을 의존하는 기능들을 등록하는 장소입니다.
    public class UnityServiceLoader : IUnityServiceLoader
    {
        private IUnityServiceRepository unityServiceRepository;

        private UnityEngine.GameObject UnityServiceGameObjectParent;

        public UnityServiceLoader(IUnityServiceRepository unityServiceRepository)
        {
            this.unityServiceRepository = unityServiceRepository;

            // 런타임 내 유일한 GameObject 명시.
            this.UnityServiceGameObjectParent = new("UnityServices");
            UnityEngine.Object.DontDestroyOnLoad(UnityServiceGameObjectParent);
        }

        public void LoadUnityServices()
        {
            // 사용되는 UnityService 명시.
            // 새로운 UntiyService 등록 방식.
            // unityServiceRepository.RegisterUnityService<T>(gameObject.AddComponent<T>());
            // unityServiceRepository.RegisterUnityService<T>(new T());

            // Scene 전환 유니티 서비스 등록.
            this.unityServiceRepository.RegisterUnityService<SceneService>(new SceneService());
            this.unityServiceRepository.RegisterUnityService<CoroutineRunner>(this.UnityServiceGameObjectParent.AddComponent<CoroutineRunner>());

            this.unityServiceRepository.RegisterUnityService<TransformMovementService>(new TransformMovementService());
            this.unityServiceRepository.RegisterUnityService<RectTransformMovementService>(new RectTransformMovementService());
        }
    }
}


