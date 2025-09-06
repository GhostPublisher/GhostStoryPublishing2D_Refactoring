using System;
using UnityEngine;
using GameSystems.Repository;

namespace GameSystems.BootStrap
{
    public interface IUnityServiceLoadManager
    {
        public bool TryLoadUnityServices();
    }

    // UnityServiceLoadManager는 모든 MainBoot의 Awake()에서 선언 및 정의됩니다. ( 필드 멤버로 존재하지 않는 것 )

    // TryLoad~~~()함수
    //  : Singleton으로 구현된 Unity Service Repository의 Instance의 참조를 수행.
    //  : Unity Service Repository가 처음 호출됬는지 확인.    <- 중복 등록 수행 방지.
    //  : Unity Service Repository에 필요한 사용할 Service 등록.
    public class UnityServiceLoadManager : IUnityServiceLoadManager
    {
        public bool TryLoadUnityServices()
        {
            IUnityServiceRepository unityServiceRepository = Repository.UnityServiceRepository.Instance;

            // UnityServices Repository의 초기 설정이 되어 있으면 바로 리턴.
            if (unityServiceRepository.IsInitialed) return false;

            // Unity Engine에 의존하기에, 기본적으로 MonoBehaviour를 상속한 기능들입니다.
            // Scene 변경에도 사라지지 않는 DontDestroyOnLoad 객체 밑에 존재할 필요가 있습니다.
            UnityEngine.GameObject UnityServiceGameObjectParent = new("UnityServices");
            UnityEngine.Object.DontDestroyOnLoad(UnityServiceGameObjectParent);

            // 여기서 Untiy Services 등록.
            // ~~~
            // ~~~

            // 초기 설정 완료 명시.
            unityServiceRepository.IsInitialed = true;
            return true;
        }

        // 새로운 UntiyService 등록 방식.
        private void RegisterUnityService<T>(UnityEngine.GameObject parent, IUnityServiceRepository unityServiceRepository) where T : MonoBehaviour, IUnityService
        {
            Type key = typeof(T);

            UnityEngine.GameObject newObject = new(key.Name);
            T service =  newObject.AddComponent<T>();

            newObject.transform.SetParent(parent.transform);

            unityServiceRepository.RegisterUnityService(key, service);
        }
    }
}


