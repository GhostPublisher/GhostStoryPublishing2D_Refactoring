using UnityEngine;

using GameSystems.Repository;
using GameSystems.UnityServices;

namespace GameSystems.BootStrap
{
    public interface IUnityServiceLoader
    {
        public void LoadUnityServices(IUnityServiceRepository unityServiceRepository, GameObject UnityServiceGameObject);
    }

    // Unity Engine을 의존하는 기능들을 등록하는 장소입니다.
    public class UnityServiceLoader : IUnityServiceLoader
    {
        public void LoadUnityServices(IUnityServiceRepository unityServiceRepository, GameObject UnityServiceGameObject)
        {
            // 사용되는 UnityService 명시.
            // 새로운 UntiyService 등록 방식.
            // unityServiceRepository.RegisterUnityService<T>(gameObject.AddComponent<T>());
            // unityServiceRepository.RegisterUnityService<T>(new T());

            // Scene 전환 유니티 서비스 등록.
            unityServiceRepository.RegisterUnityService<SceneService>(new SceneService());
        }
    }
}


