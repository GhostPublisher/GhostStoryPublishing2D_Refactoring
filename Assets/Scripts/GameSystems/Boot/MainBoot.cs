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
            // Singleton PlainService & UnityService ����� ���� �� ����
            IPlainServiceRepository plainServiceRepository = Repository.PlainServiceRepository.Instance;
            IUnityServiceRepository unityServiceRepository = Repository.UnityServiceRepository.Instance;

            // �ʱ� Load�� �Ǿ� ���� ������, PlainService & UnityService ��� �ε�.

            if (!plainServiceRepository.IsInitialed)
            {
                // Unity Engine �� �������� �ʴ� Service ��ɵ��� �ε��մϴ�.
                IPlainServiceManager plainServiceLoadManager = new PlainServiceManager(plainServiceRepository);
                plainServiceLoadManager.LoadPlainServices();

                // �ʱ� ���� �Ϸ� ���.
                plainServiceRepository.IsInitialed = true;
            }

            if (!unityServiceRepository.IsInitialed)
            {
                // Unity Engine �� �����Ͽ� �۵��ϴ� Service ��ɵ� �ε�.
                IUnityServiceLoader unityServiceLoader = new UnityServiceLoader(unityServiceRepository);
                unityServiceLoader.LoadUnityServices();

                // �ʱ� ���� �Ϸ� ���.
                unityServiceRepository.IsInitialed = true;
            }
        }
    }
}