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
    // MainBoot는 모든 Scene에 존재합니다.
    //  : 이는 부분 Scene 테스트 수행성을 높이기 위함입니다.
    //  : 모든 Scene에서 Awake()를 수행하여도, '초기화여부' boolean 값을 통하여 중복 수행 및 정의는 방지합니다.
    public class MainBoot : MonoBehaviour
    {
        private void Awake()
        {
            // Unity Engine 에 의존하여 작동하는 Service 기능들을 로드합니다.
            // 해당 기능들은 전역으로 사용된다는 특지이 있습니다.
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