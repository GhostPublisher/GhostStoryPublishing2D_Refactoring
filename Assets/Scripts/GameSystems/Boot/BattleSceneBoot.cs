using UnityEngine;

using GameSystems.BootStrap;
using GameSystems.Repository;

namespace GameSystems.Boot
{
    [DefaultExecutionOrder(-90)]  // 숫자가 낮을수록 먼저 실행됨
    public class BattleSceneBoot : MonoBehaviour
    {
        private void Awake()
        {
            IGameFlowLoader GameFlowLoadManager = new BattleScene_GameFlowLoader();
            IHandlerRepository HandlerRepository = new HandlerRepository();
            IUnityServiceRepository UnityServiceRepository = Repository.UnityServiceRepository.Instance;
            IPlainServiceRepository PlainServiceRepository = Repository.PlainServiceRepository.Instance;
        }
    }
}