using UnityEngine;

using GameSystems.BootStrap;
using GameSystems.Repository;

namespace GameSystems.Boot
{
    // MainBoot�� ��� Scene�� �����մϴ�.
    //  : �̴� �κ� Scene �׽�Ʈ ���༺�� ���̱� �����Դϴ�.
    //  : ��� Scene���� Awake()�� �����Ͽ���, '�ʱ�ȭ����' boolean ���� ���Ͽ� �ߺ� ���� �� ���Ǵ� �����մϴ�.
    [DefaultExecutionOrder(-100)]  // ���ڰ� �������� ���� �����
    public class MainBoot : MonoBehaviour
    {
        private void Awake()
        {
            IPlainServiceRepository plainServiceRepository = Repository.PlainServiceRepository.Instance;
            if (!plainServiceRepository.IsInitialed)
            {
                // Unity Engine �� �������� �ʴ� Service ��ɵ��� �ε��մϴ�.

                IPlainServiceLoader plainServiceLoadManager = new PlainServiceLoader();
                plainServiceLoadManager.LoadPlainServices(plainServiceRepository);

                // �ʱ� ���� �Ϸ� ���.
                plainServiceRepository.IsInitialed = true;
            }

            // Singleton UnityService ����� ����
            IUnityServiceRepository unityServiceRepository = Repository.UnityServiceRepository.Instance;
            // �ʱ� ������ �Ǿ� ���� ������, �ʱ� ���� ����.
            if (!unityServiceRepository.IsInitialed)
            {
                // ��Ÿ�� �� ������ GameObject ���.
                UnityEngine.GameObject UnityServiceGameObjectParent = new("UnityServices");
                UnityEngine.Object.DontDestroyOnLoad(UnityServiceGameObjectParent);

                // Unity Engine �� �����Ͽ� �۵��ϴ� Service ��ɵ� �ε�.
                IUnityServiceLoader unityServiceLoader = new UnityServiceLoader();
                unityServiceLoader.LoadUnityServices(unityServiceRepository, UnityServiceGameObjectParent);

                // �ʱ� ���� �Ϸ� ���.
                unityServiceRepository.IsInitialed = true;
            }

        }
    }
}