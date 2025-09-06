using System;
using System.Collections;
using UnityEngine;

using GameSystems.BootStrap;
using GameSystems.Repository;

namespace GameSystems.Inputs
{

}

namespace GameSystems.DomainModel.Input
{
    public class InputDomainModel : IDomainModel
    {
        private InputState currentInputState;

        public InputState CurrentInputState { get => currentInputState; set => currentInputState = value; }
    }

    public enum InputState
    {
        GamePlay, Dialog
    }
}

namespace GameSystems.Boot
{
    // MainBoot�� ��� Scene�� �����մϴ�.
    //  : �̴� �κ� Scene �׽�Ʈ ���༺�� ���̱� �����Դϴ�.
    //  : ��� Scene���� Awake()�� �����Ͽ���, '�ʱ�ȭ����' boolean ���� ���Ͽ� �ߺ� ���� �� ���Ǵ� �����մϴ�.
    public class MainBoot : MonoBehaviour
    {
        private void Awake()
        {
            // Unity Engine �� �����Ͽ� �۵��ϴ� Service ��ɵ��� �ε��մϴ�.
            // �ش� ��ɵ��� �������� ���ȴٴ� Ư���� �ֽ��ϴ�.
            IUnityServiceLoadManager UnityServiceRepository = new UnityServiceLoadManager();
            UnityServiceRepository.TryLoadUnityServices();
        }
    }

    public class LobbySceneBoot : MonoBehaviour
    {
        private void Awake()
        {
            IGameFlowLoadManager GameFlowLoadManager = new LobbyScene_GameFlowLoadManager();
            IHandlerRepository HandlerRepository = new HandlerRepository();
            IUnityServiceRepository UnityServiceRepository = Repository.UnityServiceRepository.Instance;

            GameFlowLoadManager.LoadGameFlows(HandlerRepository, UnityServiceRepository);
        }
    }

    public class BattleSceneBoot : MonoBehaviour
    {
        private void Awake()
        {
            IGameFlowLoadManager GameFlowLoadManager = new BattleScene_GameFlowLoadManager();
            IHandlerRepository HandlerRepository = new HandlerRepository();
            IUnityServiceRepository UnityServiceRepository = Repository.UnityServiceRepository.Instance;

            GameFlowLoadManager.LoadGameFlows(HandlerRepository, UnityServiceRepository);
        }
    }
}