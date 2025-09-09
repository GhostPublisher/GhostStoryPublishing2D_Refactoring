using GameSystems.Repository;

using GameSystems.Domain.Models;

namespace GameSystems.BootStrap
{
    public class LobbyScene_DomainModelManager : DomainModelManager
    {
        public LobbyScene_DomainModelManager(IDomainModelRepository DomainModelRepository) : base(DomainModelRepository) { }

        public override void LoadDomainModels()
        {
            this.domainModelRepository.RegisterDomainModel<InputStateModel>(new InputStateModel());
        }

        // Scene 전환 시, 이전 Scene의 Data를 전달 받는 기능.
        public override void LoadDomainModelsWithPayload(IPlainServiceRepository plainServiceRepository)
        {
            // 전달받은 payload가 없는 경우.
            if (!plainServiceRepository.TryGetPlainService<PlainServices.ScenePayloadService>(out var service))
            {
                UnityEngine.Debug.Log($"Payload 서비스가 등록되지 않았습니다.");
                return;
            }

            // Payload가 등록되지 않은 경우.
            if (service.TryGetPayload<DTO.BattleToLobbyScenePayload>(out var payload) || payload == null)
            {
                UnityEngine.Debug.Log($"전달받은 Payload가 없습니다.");
                return;
            }

            // 전달 받은 Payload를 현재 Scene의 Model에 로드.


            // 전부 등록한 후, 전달을 위한 Payload 초기화
            service.ClearPayload();
        }
    }
}