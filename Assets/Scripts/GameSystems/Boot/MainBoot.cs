using UnityEngine;

using GameSystems.BootStrap;
using GameSystems.Repository;

namespace GameSystems.Boot
{
    // MainBoot는 모든 Scene에 존재합니다.
    //  : 이는 부분 Scene 테스트 수행성을 높이기 위함입니다.
    //  : 모든 Scene에서 Awake()를 수행하여도, '초기화여부' boolean 값을 통하여 중복 수행 및 정의는 방지합니다.
    [DefaultExecutionOrder(-100)]  // 숫자가 낮을수록 먼저 실행됨
    public class MainBoot : MonoBehaviour
    {
        private void Awake()
        {
            IPlainServiceRepository plainServiceRepository = Repository.PlainServiceRepository.Instance;
            if (!plainServiceRepository.IsInitialed)
            {
                // Unity Engine 에 의존하지 않는 Service 기능들을 로드합니다.

                IPlainServiceLoader plainServiceLoadManager = new PlainServiceLoader();
                plainServiceLoadManager.LoadPlainServices(plainServiceRepository);

                // 초기 설정 완료 명시.
                plainServiceRepository.IsInitialed = true;
            }

            // Singleton UnityService 저장소 참조
            IUnityServiceRepository unityServiceRepository = Repository.UnityServiceRepository.Instance;
            // 초기 설정이 되어 있지 않으면, 초기 설정 수행.
            if (!unityServiceRepository.IsInitialed)
            {
                // 런타임 내 유일한 GameObject 명시.
                UnityEngine.GameObject UnityServiceGameObjectParent = new("UnityServices");
                UnityEngine.Object.DontDestroyOnLoad(UnityServiceGameObjectParent);

                // Unity Engine 에 의존하여 작동하는 Service 기능들 로드.
                IUnityServiceLoader unityServiceLoader = new UnityServiceLoader();
                unityServiceLoader.LoadUnityServices(unityServiceRepository, UnityServiceGameObjectParent);

                // 초기 설정 완료 명시.
                unityServiceRepository.IsInitialed = true;
            }

        }
    }
}